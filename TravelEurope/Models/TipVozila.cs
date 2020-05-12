using System.ComponentModel.DataAnnotations;

namespace TravelEurope.Models
{
    public class TipVozila
    {
        [Key]
        public int TipId { get; set; }
        public string Naziv { get; set; }
    }
}
