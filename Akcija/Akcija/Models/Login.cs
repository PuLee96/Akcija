using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data;

namespace Akcija.Models
{
    public class Login
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email adresa")]
        public string email { get; set; }

        [Display(Name = "Lozinka")]
        public string lozinka { get; set; }
    }
}