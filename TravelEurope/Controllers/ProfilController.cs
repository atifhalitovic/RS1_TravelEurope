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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;

namespace TravelEurope.Controllers
{
    public class ProfilController : Controller
    {
        private readonly IHostingEnvironment hosting;
        private ApplicationDbContext _db;
        private ImgUploadHelper _imgHelper;
        private UserManagementHelper _userManagementHelper;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AccountController> _logger;
        private readonly UrlEncoder _urlEncoder;

        public int brojac = 0;

        public ProfilController(ApplicationDbContext db, IHostingEnvironment environment, IFileManager manager, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager, UrlEncoder urlEncoder, ILogger<AccountController> logger)
        {
            _db = db;
            hosting = environment;
            _imgHelper = new ImgUploadHelper(hosting, manager);
            _userManagementHelper = new UserManagementHelper(_db);
            _userManager = userManager;
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _urlEncoder = urlEncoder;
            _logger = logger;
        }

        public IActionResult Kreiraj()
        {
            KorisniciVM model = _userManagementHelper.prepRadnika();
            return View("Kreiraj", model);
        }

        [HttpPost]
        public async Task<IActionResult> Kreiraj(KorisniciVM model)
        {
            bool x = await _roleManager.RoleExistsAsync("Klijent");

            if (!x)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = "Klijent"
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

            await _userManager.AddToRoleAsync(user, "Klijent");

            Klijent klijent = new Klijent
            {
                KlijentId = user.Id,
                BrojPasosa = model.BrojPasosa,
                BrVozackeDozvole = model.BrVozackeDozvole
            };

            _db.Klijent.Add(klijent);
            _db.SaveChanges();

            return RedirectToAction("RegistracijaSucceedLogin", "Account");
        }

        public IActionResult Detalji(string id)
        {
            KlijentProfilVM vm = new KlijentProfilVM
            {
                Klijent = _db.Klijent.Include(a => a.ApplicationUser).Where(x => x.KlijentId == id).FirstOrDefault(),
                Grad = _db.Grad.Where(x => x.GradId == (_db.Klijent.Include(a => a.ApplicationUser).Where(b => b.KlijentId == id).FirstOrDefault().ApplicationUser.GradId)).FirstOrDefault().Naziv,
            };
            return View(vm);
        }
    }
}