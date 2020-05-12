using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TravelEurope.Models;

namespace TravelEurope.Models
{
    public class Rezervacija
    {
        [Key]
        public int RezervacijaId { get; set; }
        public DateTime DatumPreuzimanja { get; set; }
        public DateTime DatumVracanja { get; set; }
        public double CijenaUslugePoDanu { get; set; }
        public double CijenaOsiguranja { get; set; }
        [ForeignKey("Klijent")]
        public string KlijentId { get; set; }
        public Klijent Klijent { get; set; }
        [ForeignKey("Radnik")]
        public string RadnikId { get; set; }
        public Radnik Radnik { get; set; }
        [ForeignKey("Vozac")]
        public int? VozacId { get; set; }
        public Vozac Vozac { get; set; }
        [ForeignKey("Vozilo")]
        public int? VoziloId { get; set; }
        public Vozilo Vozilo { get; set; }
        [ForeignKey("TuristRuta")]
        public int? TuristRutaId { get; set; }
        public TuristRuta TuristRuta { get; set; }
    }
}
