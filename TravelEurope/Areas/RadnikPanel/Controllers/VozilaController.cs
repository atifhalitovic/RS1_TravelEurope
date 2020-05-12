using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TravelEurope.Data;
using TravelEurope.Areas.RadnikPanel.ViewModels;
using TravelEurope.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace TravelEurope.Areas.RadnikPanel.Controllers
{
    [Authorize(Roles = "Radnik")]
    [Area("RadnikPanel")]
    public class VozilaController : Controller
    {
        private ApplicationDbContext _context;

        public VozilaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            VozilaIndexVM vm = new VozilaIndexVM()
            {
                Rows = _context.Vozilo.Select(x => new VozilaIndexVM.Row()
                {
                    VoziloId = x.VoziloId,
                    Naziv = x.Naziv,
                    TipVozila = x.TipVozila.Naziv,
                    GodinaProizvodnje = x.GodinaProizvodnje,
                    MarkaVozila = x.MarkaVozila.Naziv,
                    BrojSjedista = x.BrojSjedista,
                    Boja = x.Boja,
                    BrojVrata = x.BrojVrata,
                    StatusVozila = x.StatusVozila.Status,
                    VrstaGoriva = x.VrstaGoriva.Naziv,
                    CijenaPoDanu = x.CijenaPoDanu,
                }).ToList()
            };
            return View(vm);
        }

        public IActionResult Dodaj()
        {
            VozilaDodajVM vm = new VozilaDodajVM()
            {
                TipVozilaLista = _context.TipVozila.Select(x => new SelectListItem
                {
                    Value = x.TipId.ToString(),
                    Text = x.Naziv
                }).ToList(),
                MarkaVozilaLista = _context.MarkaVozila.Select(x => new SelectListItem
                {
                    Value = x.MarkaId.ToString(),
                    Text = x.Naziv
                }).ToList(),
                StatusVozilaLista = _context.StatusVozila.Select(x => new SelectListItem
                {
                    Value = x.StatusVozilaId.ToString(),
                    Text = x.Status
                }).ToList(),
                VrstaGorivaLista = _context.VrstaGoriva.Select(x => new SelectListItem
                {
                    Value = x.GorivoId.ToString(),
                    Text = x.Naziv
                }).ToList(),
            };
            return PartialView(vm);
        }

        [HttpPost]
        public IActionResult Dodaj(VozilaDodajVM vm)
        {
            Vozilo v = _context.Vozilo.Where(a => a.VoziloId == vm.VoziloId).SingleOrDefault();
            if (v == null)
            {
                Vozilo a = new Vozilo
                {
                    VoziloId = vm.VoziloId,
                    Naziv = vm.Naziv,
                    MarkaVozilaId = vm.MarkaVozilaId,
                    GodinaProizvodnje = vm.GodinaProizvodnje,
                    TipVozilaId = vm.TipVozilaId,
                    StatusVozilaId = vm.StatusVozilaId,
                    VrstaGorivaId = vm.VrstaGorivaId,
                    BrojSjedista = vm.BrojSjedista,
                    Boja = vm.Boja,
                    BrojVrata = vm.BrojVrata,
                    CijenaPoDanu = vm.CijenaPoDanu
                };

                _context.Vozilo.Add(a);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            v.VoziloId = vm.VoziloId;
            v.Naziv = vm.Naziv;
            v.MarkaVozilaId = vm.MarkaVozilaId;
            v.GodinaProizvodnje = vm.GodinaProizvodnje;
            v.TipVozilaId = vm.TipVozilaId;
            v.StatusVozilaId = vm.StatusVozilaId;
            v.VrstaGorivaId = vm.VrstaGorivaId;
            v.BrojSjedista = vm.BrojSjedista;
            v.Boja = vm.Boja;
            v.BrojVrata = vm.BrojVrata;
            v.CijenaPoDanu = vm.CijenaPoDanu;

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Uredi(int id)
        {
            VozilaDodajVM vm = new VozilaDodajVM();
            Vozilo v = _context.Vozilo.Where(a => a.VoziloId == id).SingleOrDefault();

            vm.TipVozilaLista = _context.TipVozila.Select(x => new SelectListItem
            {
                Value = x.TipId.ToString(),
                Text = x.Naziv
            }).ToList();
            vm.MarkaVozilaLista = _context.MarkaVozila.Select(x => new SelectListItem
            {
                Value = x.MarkaId.ToString(),
                Text = x.Naziv
            }).ToList();
            vm.StatusVozilaLista = _context.StatusVozila.Select(x => new SelectListItem
            {
                Value = x.StatusVozilaId.ToString(),
                Text = x.Status
            }).ToList();
            vm.VrstaGorivaLista = _context.VrstaGoriva.Select(x => new SelectListItem
            {
                Value = x.GorivoId.ToString(),
                Text = x.Naziv
            }).ToList();

            vm.VoziloId = id;
            vm.Naziv = v.Naziv;
            vm.MarkaVozilaId = v.MarkaVozilaId;
            vm.GodinaProizvodnje = v.GodinaProizvodnje;
            vm.TipVozilaId = v.TipVozilaId;
            vm.StatusVozilaId = v.StatusVozilaId;
            vm.VrstaGorivaId = v.VrstaGorivaId;
            vm.BrojSjedista = v.BrojSjedista;
            vm.Boja = v.Boja;
            vm.BrojVrata = v.BrojVrata;
            vm.CijenaPoDanu = v.CijenaPoDanu;
            
            return PartialView(vm);
        }

        public IActionResult Obrisi(int id)
        {
            Vozilo x = _context.Vozilo.Find(id);
            _context.Vozilo.Remove(x);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}