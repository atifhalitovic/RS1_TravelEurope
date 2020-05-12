using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelEurope.Models;

namespace TravelEurope.Areas.RadnikPanel.ViewModels
{
    public class RadnikProfilVM
    {
        public Radnik Radnik { get; set; }
        public string Grad { get; set; }
    }
}
