using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using TravelEurope.Data;
using TravelEurope.Models;
using TravelEurope.Areas.RadnikPanel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace TravelEurope.Areas.RadnikPanel.Controllers
{
    [Authorize(Roles = "Radnik")]
    [Area("RadnikPanel")]
    public class GradoviController : Controller
    {
        private ApplicationDbContext _context;

        public GradoviController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            GradoviIndexVM vm = new GradoviIndexVM()
            {
                Rows = _context.Grad.Select(x => new GradoviIndexVM.Row()
                {
                    GradId = x.GradId,
                    Naziv = x.Naziv,
                    Drzava = x.Drzava.Naziv
                }).ToList()
            };
            return View(vm);
        }

        public IActionResult PrikaziPoDrzavi(int id)
        {
            GradoviIndexVM vm = new GradoviIndexVM()
            {
                Rows = _context.Grad.Include(a => a.Drzava).Select(x => new GradoviIndexVM.Row()
                {
                    GradId = x.GradId,
                    Naziv = x.Naziv,
                    Drzava = x.Drzava.Naziv
                }).ToList()
            };
            return PartialView(vm);
        }

        public IActionResult Dodaj()
        {
            GradoviDodajVM vm = new GradoviDodajVM()
            {
                DrzaveLista = _context.Drzava.Select(x => new SelectListItem
                {
                    Value = x.DrzavaId.ToString(),
                    Text = x.Naziv
                }).ToList()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Dodaj(GradoviDodajVM vm)
        {
            Grad g = _context.Grad.Where(a => a.GradId == vm.GradId).SingleOrDefault();
            if (g==null)
            {
                Grad a = new Grad
                {
                    GradId = vm.GradId,
                    DrzavaId = vm.DrzavaId,
                    Naziv = vm.Naziv
                };
                _context.Grad.Add(a);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            g.GradId = vm.GradId;
            g.Naziv = vm.Naziv;
            g.DrzavaId = vm.DrzavaId;

            _context.SaveChanges();
            _context.Dispose();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Uredi(int id)
        {
            GradoviDodajVM vm = new GradoviDodajVM();
            vm.GradId = id;
            vm.Naziv = _context.Grad.Where(a => a.GradId == id).SingleOrDefault().Naziv;
            vm.DrzavaId = _context.Grad.Where(a => a.GradId == id).SingleOrDefault().DrzavaId;
            vm.DrzaveLista = _context.Drzava.Select(x => new SelectListItem
            {
                Value = x.DrzavaId.ToString(),
                Text = x.Naziv
            }).ToList();
            return View(vm);
        }


        public IActionResult Obrisi(int id)
        {
            Drzava x = _context.Drzava.Find(id);
            _context.Drzava.Remove(x);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}