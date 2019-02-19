using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Akcija.Models
{
    [Table("akcija")]
    public class Akcija
    {
        [Required]
        [Key]
        public int id_akcija { get; set; }

        [Display(Name = "Naziv")]
        public string naziv { get; set; }

	    [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Datum - poèetak")]
        [DataType(DataType.Date)]
        //ako ne napišemo fiksno ovaj format Google Chrome nece dobro prikazati datumsko polje
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime datumPocetak { get; set; }

	    [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Datum - završetak")]
        [DataType(DataType.Date)]
        //ako ne napišemo fiksno ovaj format Google Chrome nece dobro prikazati datumsko polje
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime datumZavrsetak { get; set; }

	    [Display(Name = "Opis")]
        public string opis { get; set; }
    }
}