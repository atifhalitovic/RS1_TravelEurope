using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelEurope.Models
{
    public class Racun
    {
        [Key]
        public int RacunId { get; set; }
        [ForeignKey("Rezervacija")]
        public int RezervacijaId { get; set; }
        public Rezervacija Rezervacija { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public int TrajanjeRentanjaDani { get; set; }
        [ForeignKey("NacinPlacanja")]
        public int NacinPlacanjaId { get; set; }
        public NacinPlacanja NacinPlacanja { get; set; }
        public int CijenaUslugeSaPDVom { get; set; }

    }
}
