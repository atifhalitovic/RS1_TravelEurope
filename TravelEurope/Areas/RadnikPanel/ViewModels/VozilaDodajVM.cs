using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelEurope.Areas.RadnikPanel.ViewModels
{
    public class VozilaDodajVM
    {
        public int VoziloId { get; set; }
        public string Naziv { get; set; }
        public int TipVozilaId { get; set; }
        public List<SelectListItem> TipVozilaLista { get; set; }
        public int GodinaProizvodnje { get; set; }
        public int MarkaVozilaId { get; set; }
        public List<SelectListItem> MarkaVozilaLista { get; set; }
        public int StatusVozilaId { get; set; }
        public List<SelectListItem> StatusVozilaLista { get; set; }
        public int VrstaGorivaId { get; set; }
        public List<SelectListItem> VrstaGorivaLista { get; set; }
        public int BrojSjedista { get; set; }
        public string Boja { get; set; }
        public int BrojVrata { get; set; }
        public byte[] Slika { get; set; }
        public int IsDeleted { get; set; }
        public double CijenaPoDanu { get; set; }
    }
}