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
    public class RezervacijeController : Controller
    {
        private ApplicationDbContext _context;

        public RezervacijeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            RezervacijeIndexVM vm = new RezervacijeIndexVM()
            {
                Rows = _context.Rezervacija.Select(x => new RezervacijeIndexVM.Row()
                {
                    Vozilo = x.Vozilo.Naziv,
                    Vozac = x.Vozac.Ime + " " + x.Vozac.Prezime,
                    TuristRuta = x.TuristRuta.Naziv,
                    RezervacijaId = x.RezervacijaId,
                    DatumPreuzimanja = x.DatumPreuzimanja,
                    DatumVracanja = x.DatumVracanja,
                    CijenaUslugePoDanu = x.CijenaUslugePoDanu,
                    CijenaOsiguranja = x.CijenaOsiguranja,
                    Radnik = x.Radnik.ApplicationUser.Ime + " " + x.Radnik.ApplicationUser.Prezime,
                    UkupnaCijena = x.CijenaOsiguranja + x.CijenaUslugePoDanu
                }).ToList()
            };
            return View(vm);
        }

        public IActionResult Vozila()
        {
            RezervacijeVozilaVM vm = new RezervacijeVozilaVM()
            {
                Rows = _context.Rezervacija.Select(x => new RezervacijeVozilaVM.Row()
                {
                    Vozilo = x.Vozilo.Naziv,
                    RezervacijaId = x.RezervacijaId,
                    DatumPreuzimanja = x.DatumPreuzimanja,
                    DatumVracanja = x.DatumVracanja,
                    CijenaUslugePoDanu = x.CijenaUslugePoDanu,
                    CijenaOsiguranja = x.CijenaOsiguranja,
                    Radnik = x.Radnik.ApplicationUser.Ime + " " + x.Radnik.ApplicationUser.Prezime,
                    Klijent = x.Klijent.ApplicationUser.Ime + " " + x.Klijent.ApplicationUser.Prezime,
                    UkupnaCijena = x.CijenaOsiguranja + x.CijenaUslugePoDanu
                }).ToList()
            };
            return View(vm);
        }

        public IActionResult Vozaci()
        {
            RezervacijeVozaciVM vm = new RezervacijeVozaciVM()
            {
                Rows = _context.Rezervacija.Select(x => new RezervacijeVozaciVM.Row()
                {
                    Vozac = x.Vozac.Ime + " " + x.Vozac.Prezime,
                    RezervacijaId = x.RezervacijaId,
                    DatumPreuzimanja = x.DatumPreuzimanja,
                    DatumVracanja = x.DatumVracanja,
                    CijenaUslugePoDanu = x.CijenaUslugePoDanu,
                    CijenaOsiguranja = x.CijenaOsiguranja,
                    Radnik = x.Radnik.ApplicationUser.Ime + " " + x.Radnik.ApplicationUser.Prezime,
                    Klijent = x.Klijent.ApplicationUser.Ime + " " + x.Klijent.ApplicationUser.Prezime,
                    UkupnaCijena = x.CijenaOsiguranja + x.CijenaUslugePoDanu
                }).ToList()
            };
            return View(vm);
        }

        public IActionResult TuristRute()
        {
            RezervacijeTuristRuteVM vm = new RezervacijeTuristRuteVM()
            {
                Rows = _context.Rezervacija.Select(x => new RezervacijeTuristRuteVM.Row()
                {
                    TuristRuta = x.TuristRuta.Naziv,
                    RezervacijaId = x.RezervacijaId,
                    DatumPreuzimanja = x.DatumPreuzimanja,
                    DatumVracanja = x.DatumVracanja,
                    CijenaUslugePoDanu = x.CijenaUslugePoDanu,
                    CijenaOsiguranja = x.CijenaOsiguranja,
                    Radnik = x.Radnik.ApplicationUser.Ime + " " + x.Radnik.ApplicationUser.Prezime,
                    Klijent = x.Klijent.ApplicationUser.Ime + " " + x.Klijent.ApplicationUser.Prezime,
                    UkupnaCijena = x.CijenaOsiguranja + x.CijenaUslugePoDanu
                }).ToList()
            };
            return View(vm);
        }
    }
}