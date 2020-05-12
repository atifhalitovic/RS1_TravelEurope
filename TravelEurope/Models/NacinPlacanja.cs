using System.ComponentModel.DataAnnotations;

namespace TravelEurope.Models
{
    public class NacinPlacanja
    {
        [Key]
        public int NacinPlacanjaId { get; set; }
        public string Naziv { get; set; }
    }
}
