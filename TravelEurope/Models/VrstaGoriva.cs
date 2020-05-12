using System.ComponentModel.DataAnnotations;

namespace TravelEurope.Models
{
    public class VrstaGoriva
    {
        [Key]
        public int GorivoId { get; set; }
        public string Naziv { get; set; }
    }
}
