using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelEurope.Models
{
    public class Administrator
    {
        [ForeignKey("ApplicationUser")]
        public string AdministratorId { get; set; }
        public string IzjavaZastitaPodataka { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
