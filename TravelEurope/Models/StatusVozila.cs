using System.ComponentModel.DataAnnotations;

namespace TravelEurope.Models
{
    public class StatusVozila
    {
        [Key]
        public int StatusVozilaId { get; set; }
        public string Status { get; set; }
        public bool Ispravnost { get; set; }
        public bool Rezervisano { get; set; }
    }
}
