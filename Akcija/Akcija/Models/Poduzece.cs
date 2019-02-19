using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Akcija.Models
{
    [Table("poduzece")]
    public class Poduzece
    {
        [Required]
        [Key]
        public int id_poduzece { get; set; }

        [Display(Name = "Naziv")]
        public string naziv { get; set; }

        [Display(Name = "Adresa")]
        public string adresa { get; set; }

        [Display(Name = "Grad")]
        public string grad { get; set; }

        [Display(Name = "Telefon")]
        public string tel { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Upisali ste nevaljanu e-mail adresu")]
        [Display(Name = "Email adresa")]
        public string email { get; set; }

        [Display(Name = "Web adresa")]
        public string webadresa { get; set; }

    }
}