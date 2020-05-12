using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelEurope.Models;

namespace TravelEurope.Areas.RadnikPanel.ViewModels
{
    public class VozaciIndexVM
    {
        public List<Row> Rows { get; set; }

        public class Row
        {
            public int VozacId { get; set; }
            public string ImePrezime { get; set; }
            public string BrVozackeDozvole { get; set; }
            public string StatusVozaca { get; set; }
            public double CijenaPoDanu { get; set; }
        }
    }
}
