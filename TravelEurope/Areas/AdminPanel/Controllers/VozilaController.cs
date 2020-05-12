using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TravelEurope.Data;
using TravelEurope.Areas.AdminPanel.ViewModels;
using TravelEurope.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace TravelEurope.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("AdminPanel")]
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
    }
}