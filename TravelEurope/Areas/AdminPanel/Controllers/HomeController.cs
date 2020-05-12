using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelEurope.ViewModels;
using TravelEurope.Data;
using TravelEurope.Models;
using Microsoft.AspNetCore.Hosting;
using TravelEurope.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using TravelEurope.Util.FileManager;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TravelEurope.Areas.AdminPanel.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace TravelEurope.Areas.AdminPanel.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("AdminPanel")]
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment hosting;
        private ApplicationDbContext _db;
        private ImgUploadHelper _imgHelper;
        private UserManagementHelper _userManagementHelper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public HomeController(ApplicationDbContext db, IHostingEnvironment environment, IFileManager manager, UserManager<ApplicationUser> userManager,
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
            return View();
        }

        public IActionResult Dodaj()
        {
            KorisniciVM model = _userManagementHelper.prepAdmina();
            return View("Dodaj", model);
        }

        [HttpPost]
        public async Task<IActionResult> Snimi(KorisniciVM model, IFormFile imgInp)
        {
            bool x = await _roleManager.RoleExistsAsync("Administrator");

            if (!x)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = "Administrator"
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
                Slika = await _imgHelper.GetImgLocationAsync(imgInp),
                UserName = model.Ime + '.' + model.Prezime,
                Email = model.Ime + "." + model.Prezime + "@traveleurope.ba",//,
                GradId = model.GradId
            };

            IdentityResult chkUser = await _userManager.CreateAsync(user, password);

            await _userManager.AddToRoleAsync(user, "Administrator");

            Administrator admin = new Administrator
            {
                AdministratorId = user.Id,
                IzjavaZastitaPodataka = model.IzjavaZastitaPodataka
            };

            _db.Add(admin);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Detalji(string id)
        {
            AdminProfilVM vm = new AdminProfilVM
            {
                Administrator = _db.Administrator.Include(a => a.ApplicationUser).Where(x => x.AdministratorId == id).FirstOrDefault(),
                Grad = _db.Grad.Where(x => x.GradId == (_db.Administrator.Include(a => a.ApplicationUser).Where(b => b.AdministratorId == id).FirstOrDefault().ApplicationUser.GradId)).FirstOrDefault().Naziv,
            };
            return View(vm);
        }
    }
}