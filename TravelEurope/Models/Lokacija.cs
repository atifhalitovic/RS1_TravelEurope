using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TravelEurope.Models
{
    public class Lokacija
    {
        [Key]
        public int LokacijaId { get; set; }
        public string Naziv { get; set; }
        [ForeignKey("Drzava")]
        public int DrzavaId { get; set; }
        public Drzava Drzava { get; set; }
    }
}
