using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelEurope.Models
{
    public class Vozac
    {
        [Key]
        public int VozacId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrVozackeDozvole { get; set; }
        [ForeignKey("StatusVozaca")]
        public int StatusVozacaId { get; set; }
        public StatusVozaca StatusVozaca { get; set; }
        public double CijenaPoDanu { get; set; }
    }
}
