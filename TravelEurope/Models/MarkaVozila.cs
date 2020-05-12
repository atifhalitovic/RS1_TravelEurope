using System.ComponentModel.DataAnnotations;

namespace TravelEurope.Models
{
    public class MarkaVozila
    {
        [Key]
        public int MarkaId { get; set; }
        public string Naziv { get; set; }
    }
}
