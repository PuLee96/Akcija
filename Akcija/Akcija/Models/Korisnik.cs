using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Akcija.Models
{
    [Table("korisnik")]
    public class Korisnik
    {
        [Key]
        [DisplayName("ID korisnika")]
        public int id_korisnik { get; set; }

        [DisplayName("ID poduzeæa")]
        public int id_poduzece { get; set; }

        [DisplayName("Ime korisnika")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        public string ime { get; set; }

        [DisplayName("Prezime korisnika")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        public string prezime { get; set; }

        [DataType(DataType.EmailAddress)]
        [DisplayName("E-mail adresa")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        public string email { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Lozinka")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        public string lozinka { get; set; }



    }
}