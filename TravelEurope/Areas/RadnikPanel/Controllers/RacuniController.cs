using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelEurope.Areas.RadnikPanel.ViewModels;
using TravelEurope.Data;

namespace TravelEurope.Areas.RadnikPanel.Controllers
{
    [Authorize(Roles = "Radnik")]
    [Area("RadnikPanel")]
    public class RacuniController : Controller
    {
        private ApplicationDbContext _context;

        public RacuniController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            RacuniIndexVM vm = new RacuniIndexVM()
            {
                Rows = _context.Racun.Select(x => new RacuniIndexVM.Row()
                {
                    RacunId=x.RacunId,
                    RezervacijaId=x.RezervacijaId,
                    DatumIzdavanja=x.DatumIzdavanja.ToShortDateString(),
                    CijenaUslugeSaPDVom=x.CijenaUslugeSaPDVom,
                    TrajanjeRentanjaDani=x.TrajanjeRentanjaDani,
                    UkupnaCijena=x.CijenaUslugeSaPDVom * x.TrajanjeRentanjaDani,
                    NacinPlacanja=x.NacinPlacanja.Naziv
                }).ToList()
            };
            return View(vm);
        }
    }
}