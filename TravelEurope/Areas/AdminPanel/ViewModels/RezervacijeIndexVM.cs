using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelEurope.Models;

namespace TravelEurope.Areas.AdminPanel.ViewModels
{
    public class RezervacijeIndexVM
    {
        public List<Row> Rows { get; set; }

        public class Row
        {
            public int RezervacijaId { get; set; }
            public DateTime DatumPreuzimanja { get; set; }
            public DateTime DatumVracanja { get; set; }
            public double CijenaUslugePoDanu { get; set; }
            public double CijenaOsiguranja { get; set; }
            public string Klijent { get; set; }
            public string Radnik { get; set; }
            public string Vozac { get; set; }
            public string Vozilo { get; set; }
            public string TuristRuta { get; set; }
            public double UkupnaCijena { get; set; }
        }
    }
}
