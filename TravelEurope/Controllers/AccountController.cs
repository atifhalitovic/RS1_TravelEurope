using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using TravelEurope.Data;
using TravelEurope.Models;
using TravelEurope.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Encodings.Web;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TravelEurope.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AccountController> _logger;
        private readonly UrlEncoder _urlEncoder;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager, UrlEncoder urlEncoder,
            ApplicationDbContext context, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _logger = logger;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _urlEncoder = urlEncoder;
            _context = context;
        }

        public IActionResult Login()
        {
            LoginVM model = new LoginVM();
            return View(model);
        }

        public IActionResult RegistracijaSucceedLogin()
        {
            LoginVM model = new LoginVM();
            return View(model);
        }

        [HttpPost]
        async public Task<IActionResult> Login(LoginVM model)
        {

            ApplicationUser user = _context.Users.FirstOrDefault(u => u.UserName == model.Username);
            if (user == null) return RedirectToAction("AccessDenied");

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (result.Succeeded)
            {

                var userRole = _userManager.GetRolesAsync(user).Result.Single();

                if (userRole == "Administrator")
                    return RedirectToAction("Index", "Home", new { area = "AdminPanel" });

                else if (userRole == "Radnik")
                    return RedirectToAction("Index", "Home", new { area = "RadnikPanel" });

                else if (userRole == "Klijent")
                    return RedirectToAction("Index", "Home");
            }
            else if (result.RequiresTwoFactor)
            {
                return LocalRedirect("/Identity/Account/LoginWith2fa");
            }

            return View(model);
        }

        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
        #endregion
    }
}
