using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelEurope.Data;
using TravelEurope.Areas.AdminPanel.ViewModels;
using TravelEurope.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelEurope.Helper;
using Microsoft.AspNetCore.Authorization;

namespace TravelEurope.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("AdminPanel")]
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
            return View(vm);
        }
    }
}