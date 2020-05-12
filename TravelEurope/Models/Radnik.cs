using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelEurope.Models
{
    public class Radnik
    {
        [ForeignKey("ApplicationUser")]
        public string RadnikId { get; set; }
        public string Pozicija { get; set; }
        public int GodineStaza { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
