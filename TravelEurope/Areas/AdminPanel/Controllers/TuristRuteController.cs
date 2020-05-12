using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelEurope.Areas.AdminPanel.ViewModels;
using TravelEurope.Data;
using TravelEurope.Models;

namespace TravelEurope.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("AdminPanel")]
    public class TuristRuteController : Controller
    {
        private ApplicationDbContext _context;

        public TuristRuteController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            TuristRuteIndexVM vm = new TuristRuteIndexVM()
            {
                Rows = _context.TuristRuta.Select(x => new TuristRuteIndexVM.Row()
                {
                    TuristRutaId = x.TuristRutaId,
                    Naziv = x.Naziv,
                    Opis = x.Opis,
                    TuristickiVodic = x.TuristickiVodic.Ime + " " + x.TuristickiVodic.Prezime,
                    Drzava = x.Drzava.Naziv,
                    CijenaPoDanu = x.CijenaPoDanu
                }).ToList()
            };
            return View(vm);
        }
    }
}