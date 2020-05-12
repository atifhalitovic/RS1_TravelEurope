using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelEurope.ViewModels;
using TravelEurope.Data;
using TravelEurope.Models;
using Microsoft.AspNetCore.Hosting;
using TravelEurope.Util;
using Microsoft.AspNetCore.Identity;
using TravelEurope.Util.FileManager;
using System.Collections.Generic;
using TravelEurope.Areas.AdminPanel.ViewModels;
using Microsoft.EntityFrameworkCore;
using static TravelEurope.Areas.AdminPanel.ViewModels.RadniciIndexVM;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace TravelEurope.Areas.AdminPanel.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("AdminPanel")]
    public class RadniciController : Controller
    {
        private readonly IHostingEnvironment hosting;
        private ApplicationDbContext _db;
        private ImgUploadHelper _imgHelper;
        private UserManagementHelper _userManagementHelper;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RadniciController(ApplicationDbContext db, IHostingEnvironment environment, IFileManager manager, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            hosting = environment;
            _imgHelper = new ImgUploadHelper(hosting, manager);
            _userManagementHelper = new UserManagementHelper(_db);
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var vm = new RadniciIndexVM() { Rows = new List<Row>() };
            var radnici = _db.Radnik.Include(a => a.ApplicationUser).ToList();

            foreach (var x in radnici)
            {
                var radnik = new Row();
                radnik.KorisnikId = x.ApplicationUser.Id;
                radnik.ImePrezime = x.ApplicationUser.Ime + " " + x.ApplicationUser.Prezime;
                radnik.JMBG = x.ApplicationUser.JMBG;
                radnik.Adresa = x.ApplicationUser.Adresa;
                radnik.Email = x.ApplicationUser.Email;
                radnik.Telefon = x.ApplicationUser.Telefon;
                radnik.Grad = _db.Grad.Where(c => c.GradId == x.ApplicationUser.GradId).SingleOrDefault().Naziv;
                radnik.Pozicija = _db.Radnik.Where(a => a.ApplicationUser.Id == x.RadnikId).FirstOrDefault().Pozicija;
                radnik.GodineStaza = _db.Radnik.Where(a => a.ApplicationUser.Id == x.RadnikId).FirstOrDefault().GodineStaza;
                vm.Rows.Add(radnik);
            };
            return PartialView(vm);
        }

        public IActionResult Obrisi(string id)
        {
            Radnik r = _db.Radnik.Where(x => x.RadnikId == id).FirstOrDefault();

            if (r != null)
            {
                _db.Radnik.Remove(r);
                var userForRemove = _db.Users.FirstOrDefault(x => x.Id == id);
                _db.Users.Remove(userForRemove);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Dodaj()
        {
            KorisniciVM model = _userManagementHelper.prepRadnika();
            return PartialView("Dodaj", model);
        }

        [HttpPost]
        public async Task<IActionResult> Dodaj(KorisniciVM model)
        {
            bool x = await _roleManager.RoleExistsAsync("Radnik");

            if (!x)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = "Radnik"
                });
            }

            //password must be strong enough in order for userManager.CreateAsync to work!!!
            string password = "myP@ssW0r@d123";

            ApplicationUser user = new ApplicationUser
            {
                JMBG = model.JMBG,
                Ime = model.Ime,
                Prezime = model.Prezime,
                DatumRodjenja = model.DatumRodjenja,
                Telefon = model.Telefon,
                Spol = model.Spol,
                Adresa = model.Adresa,
                GradId = model.GradId,
                UserName = model.Ime.ToLower() + '.' + model.Prezime.ToLower(),
                Email = model.Ime + "." + model.Prezime + "@traveleurope.ba"
            };

            await _userManager.CreateAsync(user, password);

            await _userManager.AddToRoleAsync(user, "Radnik");

            Radnik radnik = new Radnik
            {
                RadnikId = user.Id,
                GodineStaza = model.GodineStaza,
                Pozicija = model.Pozicija
            };

            _db.Add(radnik);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Detalji(string id)
        {
            RadniciDetaljiVM vm = new RadniciDetaljiVM();
            vm.Radnik = _db.Radnik.Include(a => a.ApplicationUser).Where(x => x.RadnikId == id).FirstOrDefault();
            return View(vm);
        }

        public IActionResult Uredi(string id)
        {
            Radnik model = _db.Radnik.Include(a => a.ApplicationUser).Where(x => x.RadnikId == id).FirstOrDefault();

            RadniciDodajVM user = new RadniciDodajVM();
            user.Radnik = model;
            user.Radnik.RadnikId = model.RadnikId;
            user.Radnik.ApplicationUser.JMBG = model.ApplicationUser.JMBG;
            user.Radnik.ApplicationUser.Ime = model.ApplicationUser.Ime;
            user.Radnik.ApplicationUser.Prezime = model.ApplicationUser.Prezime;
            user.Radnik.ApplicationUser.DatumRodjenja = model.ApplicationUser.DatumRodjenja;
            user.Radnik.ApplicationUser.Telefon = model.ApplicationUser.Telefon;
            user.Radnik.ApplicationUser.Spol = model.ApplicationUser.Spol;
            user.Radnik.ApplicationUser.Adresa = model.ApplicationUser.Adresa;
            user.Radnik.ApplicationUser.GradId = model.ApplicationUser.GradId;
            user.Radnik.ApplicationUser.UserName = model.ApplicationUser.Ime.ToLower() + '.' + model.ApplicationUser.Prezime.ToLower();
            user.Radnik.ApplicationUser.Email = model.ApplicationUser.Ime + "." + model.ApplicationUser.Prezime + "@traveleurope.ba";
            user.Radnik.GodineStaza = model.GodineStaza;
            user.Radnik.Pozicija = model.Pozicija;

            user.Gradovi = _db.Grad.Include(x => x.Drzava).Select(x => new SelectListItem()
            {
                Value = x.GradId.ToString(),
                Text = x.Naziv + ", " + x.Drzava.Naziv
            }).ToList();
            return PartialView(user);
        }

        [HttpPost]
        public IActionResult UrediSave(RadniciDodajVM model)
        {
            ApplicationUser user = new ApplicationUser();

            Radnik radnik = _db.Radnik.Where(a => a.RadnikId == model.Radnik.RadnikId).Include(b => b.ApplicationUser).SingleOrDefault();

            user = radnik.ApplicationUser;
            user.JMBG = model.Radnik.ApplicationUser.JMBG;
            user.Ime = model.Radnik.ApplicationUser.Ime;
            user.Prezime = model.Radnik.ApplicationUser.Prezime;
            user.DatumRodjenja = model.Radnik.ApplicationUser.DatumRodjenja;
            user.Telefon = model.Radnik.ApplicationUser.Telefon;
            user.Spol = model.Radnik.ApplicationUser.Spol;
            user.Adresa = model.Radnik.ApplicationUser.Adresa;
            user.GradId = model.Radnik.ApplicationUser.GradId;
            user.UserName = model.Radnik.ApplicationUser.Ime.ToLower() + '.' + model.Radnik.ApplicationUser.Prezime.ToLower();
            user.Email = model.Radnik.ApplicationUser.Ime + "." + model.Radnik.ApplicationUser.Prezime + "@traveleurope.ba";

            radnik.GodineStaza = model.Radnik.GodineStaza;
            radnik.Pozicija = model.Radnik.Pozicija;

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}