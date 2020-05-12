using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelEurope.Areas.RadnikPanel.ViewModels
{
    public class VozilaIndexVM
    {
        public List<Row> Rows { get; set; }

        public class Row
        {
            public int VoziloId { get; set; }
            public string Naziv { get; set; }
            public string TipVozila { get; set; }
            public int GodinaProizvodnje { get; set; }
            public string MarkaVozila { get; set; }
            public string StatusVozila { get; set; }
            public string VrstaGoriva { get; set; }
            public int BrojSjedista { get; set; }
            public string Boja { get; set; }
            public int BrojVrata { get; set; }
            public double CijenaPoDanu { get; set; }
        }
    }
}