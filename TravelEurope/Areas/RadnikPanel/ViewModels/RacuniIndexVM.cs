using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelEurope.Models;

namespace TravelEurope.Areas.RadnikPanel.ViewModels
{
    public class RacuniIndexVM
    {
        public List<Row> Rows { get; set; }

        public class Row
        {
            public int RacunId { get; set; }
            public int RezervacijaId { get; set; }
            public string DatumIzdavanja { get; set; }
            public int CijenaUslugeSaPDVom { get; set; }
            public int TrajanjeRentanjaDani { get; set; }
            public double UkupnaCijena { get; set; }
            public string NacinPlacanja { get; set; }
        }
    }
}
