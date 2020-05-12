using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelEurope.Models;

namespace TravelEurope.Areas.RadnikPanel.ViewModels
{
    public class TuristRuteIndexVM
    {
        public List<Row> Rows { get; set; }

        public class Row
        {
            public int TuristRutaId { get; set; }
            public string Naziv { get; set; }
            public string Opis { get; set; }
            public string TuristickiVodic { get; set; }
            public string Drzava { get; set; }
            public double CijenaPoDanu { get; set; }
        }
    }
}
