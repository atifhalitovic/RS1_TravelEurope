using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelEurope.Data;
using TravelEurope.Areas.RadnikPanel.ViewModels;
using TravelEurope.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelEurope.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace TravelEurope.Areas.RadnikPanel.Controllers
{
    [Authorize(Roles = "Radnik")]
    [Area("RadnikPanel")]
    public class VozaciController : Controller
    {
        private ApplicationDbContext _context;

        public VozaciController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            VozaciIndexVM vm = new VozaciIndexVM()
            {
                Rows = _context.Vozac.Select(x => new VozaciIndexVM.Row()
                {
                    VozacId = x.VozacId,
                    ImePrezime = x.Ime + " " + x.Prezime,
                    BrVozackeDozvole=x.BrVozackeDozvole,
                    StatusVozaca=x.StatusVozaca.Dostupan.Dostupnost(),
                    CijenaPoDanu = x.CijenaPoDanu
                }).ToList()
            };
            return PartialView(vm);
        }

        public IActionResult Dodaj()
        {
            VozaciDodajVM vm = new VozaciDodajVM()
            {
                StatusVozacaList = _context.StatusVozaca.Select(x => new SelectListItem
                {
                    Value = x.StatusVozacaId.ToString(),
                    Text = x.Dostupan.Dostupnost()
                }).ToList()
            };

            return PartialView(vm);
        }

        [HttpPost]
        public IActionResult Dodaj(VozaciDodajVM vm)
        {
            Vozac v = _context.Vozac.Where(a => a.VozacId == vm.VozacId).SingleOrDefault();
            if (v == null)
            {
                Vozac a = new Vozac
                {
                    VozacId = vm.VozacId,
                    Ime = vm.Ime,
                    Prezime = vm.Prezime,
                    BrVozackeDozvole = vm.BrVozackeDozvole,
                    StatusVozacaId = vm.StatusVozacaId,
                    CijenaPoDanu = vm.CijenaPoDanu
                };

                _context.Vozac.Add(a);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            v.VozacId = vm.VozacId;
            v.Ime = vm.Ime;
            v.Prezime = vm.Prezime;
            v.BrVozackeDozvole = vm.BrVozackeDozvole;
            v.StatusVozacaId = vm.StatusVozacaId;
            v.CijenaPoDanu = vm.CijenaPoDanu;

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Uredi(int id)
        {
            VozaciDodajVM vm = new VozaciDodajVM();
            Vozac v = _context.Vozac.Where(a => a.VozacId == id).SingleOrDefault();

            vm.StatusVozacaList = _context.StatusVozaca.Select(x => new SelectListItem
            {
                Value = x.StatusVozacaId.ToString(),
                Text = x.Dostupan.DaNe()
            }).ToList();

            vm.VozacId = id;
            vm.Ime = v.Ime;
            vm.Prezime = v.Prezime;
            vm.BrVozackeDozvole = v.BrVozackeDozvole;
            vm.StatusVozacaId = v.StatusVozacaId;
            vm.CijenaPoDanu = v.CijenaPoDanu;

            return PartialView(vm);
        }

        public IActionResult VozacDostupan(int id)
        {
            Vozac v = _context.Vozac.Include(b => b.StatusVozaca).Where(a => a.VozacId == id).SingleOrDefault();
            if (v.StatusVozaca.Dostupan == true)
            {
                v.StatusVozaca.Dostupan = false;
            }
            _context.Vozac.Update(v);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult VozacNedostupan(int id)
        {
            Vozac v = _context.Vozac.Include(b=>b.StatusVozaca).Where(a => a.VozacId == id).SingleOrDefault();
            if (v.StatusVozaca.Dostupan == false)
            {
                v.StatusVozaca.Dostupan = true;
            }
            _context.Vozac.Update(v);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Obrisi(int id)
        {
            Vozac x = _context.Vozac.Find(id);
            _context.Vozac.Remove(x);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}