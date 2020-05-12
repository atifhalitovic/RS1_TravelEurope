using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelEurope.Areas.RadnikPanel.ViewModels;
using TravelEurope.Data;
using TravelEurope.Models;

namespace TravelEurope.Areas.RadnikPanel.Controllers
{
    [Authorize(Roles = "Radnik")]
    [Area("RadnikPanel")]
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

        public IActionResult Dodaj()
        {
            TuristRuteDodajVM vm = new TuristRuteDodajVM()
            {
                DrzaveList = _context.Drzava.Select(x => new SelectListItem
                {
                    Value = x.DrzavaId.ToString(),
                    Text = x.Naziv
                }).ToList(),
                VodiciList = _context.TuristickiVodic.Select(x => new SelectListItem
                {
                    Value = x.TuristickiVodicId.ToString(),
                    Text = x.Ime + " " + x.Prezime + ", " + x.StraniJezik
                }).ToList()
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Dodaj(TuristRuteDodajVM vm)
        {
            TuristRuta v = _context.TuristRuta.Where(a => a.TuristRutaId == vm.TuristRutaId).SingleOrDefault();
            if (v == null)
            {
                TuristRuta a = new TuristRuta
                {
                    TuristRutaId = vm.TuristRutaId,
                    Naziv = vm.Naziv,
                    Opis = vm.Opis,
                    DrzavaId = vm.DrzavaId,
                    TuristickiVodicId = vm.TuristickiVodicId,
                    CijenaPoDanu = vm.CijenaPoDanu
                };
                _context.TuristRuta.Add(a);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            v.TuristRutaId = vm.TuristRutaId;
            v.Naziv = vm.Naziv;
            v.Opis = vm.Opis;
            v.DrzavaId = vm.DrzavaId;
            v.TuristickiVodicId = vm.TuristickiVodicId;
            v.CijenaPoDanu = vm.CijenaPoDanu;

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Uredi(int id)
        {
            TuristRuteDodajVM vm = new TuristRuteDodajVM();
            TuristRuta v = _context.TuristRuta.Where(a => a.TuristRutaId == id).SingleOrDefault();

            vm.DrzaveList = _context.Drzava.Select(x => new SelectListItem
            {
                Value = x.DrzavaId.ToString(),
                Text = x.Naziv
            }).ToList();
            vm.VodiciList = _context.TuristickiVodic.Select(x => new SelectListItem
            {
                Value = x.TuristickiVodicId.ToString(),
                Text = x.Ime + " " + x.Prezime + ", " + x.StraniJezik
            }).ToList();


            vm.TuristRutaId = v.TuristRutaId;
            vm.Naziv = v.Naziv;
            vm.Opis = v.Opis;
            vm.DrzavaId = v.DrzavaId;
            vm.TuristickiVodicId = v.TuristickiVodicId;
            vm.CijenaPoDanu = v.CijenaPoDanu;

            return View(vm);
        }

        public IActionResult Obrisi(int id)
        {
            TuristRuta x = _context.TuristRuta.Find(id);
            _context.TuristRuta.Remove(x);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}