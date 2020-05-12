using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelEurope.Data;

namespace TravelEurope.Areas.RadnikPanel.Controllers
{
    [Authorize(Roles = "Radnik")]
    [Area("RadnikPanel")]
    public class IzvjestajiController : Controller
    {
        private ApplicationDbContext _context;

        public IzvjestajiController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}