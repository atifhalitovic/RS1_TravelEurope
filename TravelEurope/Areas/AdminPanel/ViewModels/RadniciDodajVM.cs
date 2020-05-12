using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using TravelEurope.Models;

namespace TravelEurope.Areas.AdminPanel.ViewModels
{
    public class RadniciDodajVM
    {
        public Radnik Radnik { get; set; }
        public List<SelectListItem> Gradovi { get; set; }
        public List<SelectListItem> Spolovi { get; set; }

    }
}
