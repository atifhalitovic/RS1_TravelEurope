using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelEurope.ViewModels
{
    public class Login2FaVM
    {
        [Required(ErrorMessage = "Korisnicko ime je obavezno.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password je obavezan.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
