using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Akcija.Models
{
    [Table("poduzece")]
    public class Poduzece
    {
        [Key]
        [Required]
        [DisplayName("ID poduzeæa")]
        public int id_poduzece { get; set; }

        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [DisplayName("Naziv poduzeæa")]
        public string naziv_poduzece { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [DisplayName("Adresa")]
        public string adresa { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [DisplayName("Grad")]
        public string grad { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [DisplayName("Broj telefona")]
        public string telefon { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [DisplayName("E-mail adresa")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [DisplayName("Web adresa")]
        public string web_adresa { get; set; }

    }
}