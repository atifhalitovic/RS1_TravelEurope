using System.ComponentModel.DataAnnotations;

namespace TravelEurope.Models
{
    public class TuristickiVodic
    {
        [Key]
        public int TuristickiVodicId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string StraniJezik { get; set; }
    }
}
