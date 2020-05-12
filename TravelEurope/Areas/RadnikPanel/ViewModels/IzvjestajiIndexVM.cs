using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelEurope.Models;

namespace TravelEurope.Areas.RadnikPanel.ViewModels
{
    public class IzvjestajiIndexVM
    {
        public List<Row> Rows { get; set; }

        public class Row
        {
            public int RadnikId { get; set; }
            public int KorisnikId { get; set; }
            public string ImePrezime { get; set; }
            public string JMBG { get; set; }
            public string Adresa { get; set; }
            public string Email { get; set; }
            public string Telefon { get; set; }
            public string Grad { get; set; }
            public int GodineStaza { get; set; }
        }
    }
}
