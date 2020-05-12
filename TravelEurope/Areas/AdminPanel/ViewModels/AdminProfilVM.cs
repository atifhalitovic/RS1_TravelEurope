using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelEurope.Models;

namespace TravelEurope.Areas.AdminPanel.ViewModels
{
    public class AdminProfilVM
    {
        public Administrator Administrator { get; set; }
        public string Grad { get; set; }
    }
}
