using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using TravelEurope.Models;

namespace TravelEurope.ViewModels
{
    public class RegistracijaDodajVM
    {
        public Klijent Klijent { get; set; }
        public List<SelectListItem> Gradovi { get; set; }
        public List<SelectListItem> Spolovi { get; set; }

    }
}
