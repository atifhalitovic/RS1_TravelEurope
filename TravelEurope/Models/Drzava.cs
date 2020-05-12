using System.ComponentModel.DataAnnotations;

namespace TravelEurope.Models
{
    public class Drzava
    {
        [Key]
        public int DrzavaId { get; set; }
        public string Naziv { get; set; }
    }
}
