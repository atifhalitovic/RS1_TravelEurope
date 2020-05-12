using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelEurope.Areas.RadnikPanel.ViewModels
{
    public class DrzaveIndexVM
    {
        public List<Row> Rows { get; set; }

        public class Row
        {
            public int DrzavaId { get; set; }
            public string Naziv { get; set; }
        }
    }
}
