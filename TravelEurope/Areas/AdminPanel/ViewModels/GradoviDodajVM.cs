using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelEurope.Models;

namespace TravelEurope.Areas.AdminPanel.ViewModels
{
    public class GradoviDodajVM
    {
        public int GradId { get; set; }
        public string Naziv { get; set; }
        public int DrzavaId { get; set; }
        public List<SelectListItem> DrzaveLista { get; set; }
    }
}
