using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelEurope.Models
{
    public class TuristRuta
    {
        [Key]
        public int TuristRutaId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        [ForeignKey("TuristickiVodic")]
        public int TuristickiVodicId { get; set; }
        public TuristickiVodic TuristickiVodic { get; set; }
        [ForeignKey("Drzava")]
        public int DrzavaId { get; set; }
        public Drzava Drzava { get; set; }
        public double CijenaPoDanu { get; set; }
    }
}
