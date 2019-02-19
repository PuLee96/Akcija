using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Akcija.Models
{
    [Table("korisnik")]
    public class Korisnik
    {
        [Required]
        [Key]
        public int id_korisnik { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Ime i Prezime")]
        public string ime_prezime { get; set; }

	    [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "ID poduzeæe")]
        public int id_poduzece { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Upisali ste nevaljanu e-mail adresu")]
        [Display(Name = "Email adresa")]
        public string email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Lozinka")]
        [DataType(DataType.Password)]
        public string lozinka { get; set; }


        
    }
}