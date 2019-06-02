using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Akcija.Models

    {
        [Table("kategorija")]
        public class Kategorija
        {
        [Key]
        [Required]
        [DisplayName("ID kategorije")]
        public int id_kategorija { get; set; }

        [DisplayName("Naziv kategorije")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        public string naziv_kategorije { get; set; }



    }
    }