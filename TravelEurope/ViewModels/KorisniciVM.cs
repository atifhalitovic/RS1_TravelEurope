using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelEurope.ViewModels
{
    public class KorisniciVM
    {
        //Podaci od svakog korisnika
        public int Id { get; set; }
        public string JMBG { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Telefon { get; set; }
        public string Adresa { get; set; }
        public string Slika { get; set; }

        public List<SelectListItem> Gradovi { get; set; }
        public int GradId { get; set; }

        public List<SelectListItem> Spolovi { get; set; }
        public string Spol { get; set; }

        //Administrator
        public string IzjavaZastitaPodataka { get; set; }


        //Radnik
        public string Pozicija { get; set; }
        public int GodineStaza { get; set; }

        //Klijent
        public string BrojPasosa { get; set; }
        public string BrVozackeDozvole { get; set; }
    }
}
