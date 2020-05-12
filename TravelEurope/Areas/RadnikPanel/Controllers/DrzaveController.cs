using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TravelEurope.Data;
using TravelEurope.Models;
using TravelEurope.Areas.RadnikPanel.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace TravelEurope.Areas.RadnikPanel.Controllers
{
    [Authorize(Roles = "Radnik")]
    [Area("RadnikPanel")]
    public class DrzaveController : Controller
    {
        private ApplicationDbContext _context;

        public DrzaveController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            DrzaveIndexVM vm = new DrzaveIndexVM()
            {
                Rows = _context.Drzava.Select(x => new DrzaveIndexVM.Row()
                {
                    DrzavaId = x.DrzavaId,
                    Naziv = x.Naziv
                }).ToList()
            };
            return View(vm);
        }

        public IActionResult Dodaj()
        {
            DrzaveDodajVM vm = new DrzaveDodajVM(); 
            return View(vm);
        }

        [HttpPost]
        public IActionResult Dodaj(DrzaveDodajVM vm)
        {
            Drzava r = _context.Drzava.Where(a => a.DrzavaId == vm.DrzavaId).FirstOrDefault();

            if (r==null)
            {
                Drzava a = new Drzava
                {
                    DrzavaId = vm.DrzavaId,
                    Naziv = vm.Naziv
                };
                _context.Drzava.Add(a);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            r.DrzavaId = vm.DrzavaId;
            r.Naziv = vm.Naziv;


            _context.SaveChanges();
            _context.Dispose();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Uredi(int id)
        {
            DrzaveDodajVM vm = new DrzaveDodajVM();
            vm.DrzavaId = id;
            vm.Naziv = _context.Drzava.Where(a => a.DrzavaId == id).SingleOrDefault().Naziv;
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