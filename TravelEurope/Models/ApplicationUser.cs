using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TravelEurope.Models
{
    public class ApplicationUser : IdentityUser
    {
        //osoba je osnovni korisnik aplikacije
        public string JMBG { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Spol { get; set; }
        public string Telefon { get; set; }
        public string Adresa { get; set; }
        public string Slika { get; set; }
        [ForeignKey("Grad")]
        public int GradId { get; set; }
        public Grad Grad { get; set; }
    }
}
