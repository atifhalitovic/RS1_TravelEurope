using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelEurope.Models
{
    public class Vozilo
    {
        [Key]
        public int VoziloId { get; set; }
        public string Naziv { get; set; }
        public int GodinaProizvodnje { get; set; }
        [ForeignKey("TipVozila")]
        public int TipVozilaId { get; set; }
        public virtual TipVozila TipVozila { get; set; }
        [ForeignKey("MarkaVozila")]
        public int MarkaVozilaId { get; set; }
        public MarkaVozila MarkaVozila { get; set; }
        [ForeignKey("StatusVozila")]
        public int StatusVozilaId { get; set; }
        public StatusVozila StatusVozila { get; set; }
        [ForeignKey("VrstaGoriva")]
        public int VrstaGorivaId { get; set; }
        public VrstaGoriva VrstaGoriva { get; set; }
        public int BrojSjedista { get; set; }
        public string Boja { get; set; }
        public int BrojVrata { get; set; }
        public double CijenaPoDanu { get; set; }
    }
}
