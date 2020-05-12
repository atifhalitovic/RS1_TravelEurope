using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelEurope.Models;

namespace TravelEurope.Areas.AdminPanel.ViewModels
{
    public class VozaciDodajVM
    {
        public int VozacId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrVozackeDozvole { get; set; }
        public int StatusVozacaId { get; set; }
        public List<SelectListItem> StatusVozacaList { get; set; }
        public double CijenaPoDanu { get; set; }
    }
}
