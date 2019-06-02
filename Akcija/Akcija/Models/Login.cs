using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel;

namespace Akcija.Models
{
    public class Login
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DisplayName("E-mail adresa")]
        public string email { get; set; }



        [DisplayName("Lozinka")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        public string lozinka { get; set; }
    }
}