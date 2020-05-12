using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelEurope.Models
{
    public class Klijent
    {
        [ForeignKey("ApplicationUser")]
        public string KlijentId { get; set; }
        public string BrojPasosa { get; set; }
        public string BrVozackeDozvole { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
