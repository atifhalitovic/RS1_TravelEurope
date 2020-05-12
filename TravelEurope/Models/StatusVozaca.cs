using System.ComponentModel.DataAnnotations;

namespace TravelEurope.Models
{
    public class StatusVozaca
    {
        [Key]
        public int StatusVozacaId { get; set; }
        public bool Dostupan { get; set; }
    }
}
