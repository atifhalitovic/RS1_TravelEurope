using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelEurope.Models;

namespace TravelEurope.Areas.RadnikPanel.ViewModels
{
    public class TuristRuteDodajVM
    {
        public int TuristRutaId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public List<SelectListItem> VodiciList { get; set; }
        public int TuristickiVodicId { get; set; }
        public List<SelectListItem> DrzaveList { get; set; }
        public int DrzavaId { get; set; }
        public double CijenaPoDanu { get; set; }
    }
}
