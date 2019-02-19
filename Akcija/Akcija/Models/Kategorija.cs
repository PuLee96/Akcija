using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Akcija.Models

    {
        [Table("kategorija")]
        public class Kategorija
        {
            [Required]
            [Key]
	        [Column(Order = 1)]
            public int id_kategorija { get; set; }

	        [Display(Name = "Naziv kategorije")]
            public string Naziv { get; set; }
	
            [Required]
            [ForeignKey("Poduzece")]
            public int id_poduzece { get; set; }
            public Poduzece poduzece{ get; set; }



            
        }
    }