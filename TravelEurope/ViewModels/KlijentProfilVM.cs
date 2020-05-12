using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelEurope.Models;

namespace TravelEurope.ViewModels
{
    public class KlijentProfilVM
    {
        public Klijent Klijent { get; set; }
        public string Grad { get; set; }
    }
}
