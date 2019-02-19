using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Akcija.Models
{
    [Table("oglas")]
    public class Oglas
    {
        [Required]
        [Key]
        public int id_poduzece { get; set; }

        [Display(Name = "Naziv artikla")]
        public string naziv { get; set; }

	    [Display(Name = "Osnovna cijena artikla")]
        public float OsnovnaCijena { get; set; }

	    [Display(Name = "Mjerna jedinica (komad, kg,...")]
        public string mjernaJedinica { get; set; }

        [Display(Name = "Postotak popusta")]
        public int postotak { get; set; }

        [Display(Name = "Akcijska cijena artikla")]
        public float AkcijskaCijena { get; set; }

        [Display(Name = "Kratki Opis")]
        public string KratkiOpis{ get; set; }

        [Display(Name = "Dugi Opis")]
        public string DugoOpis{ get; set; }

        [Display(Name = "Slika proizvoda")]
        public string slika { get; set; }

        
    }
}