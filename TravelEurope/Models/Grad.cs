﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelEurope.Models
{

    public class Grad
    {
        [Key]
        public int GradId { get; set; }
        public string Naziv { get; set; }
        [ForeignKey("Drzava")]
        public int DrzavaId { get; set; }
        public Drzava Drzava { get; set; }
    }
}


