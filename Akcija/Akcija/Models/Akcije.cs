using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Akcija.Models
{
    [Table("akcija")]
    public class Akcije
    {
        [DisplayName("ID poduzeca")]
        public int id_poduzece { get; set; }

        [Key]
        [DisplayName("ID akcije")]
        public int id_akcija { get; set; }

        [DisplayName("ID oglasa")]
        public int id_oglas { get; set; }

        [DisplayName("Naziv akcije")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        public string naziv_akcija { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Datum po�etka")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        public DateTime? datum_pocetka { get; set; }

        [DataType(DataType.Date)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [DisplayName("Datum zavr�etka")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? datum_zavrsetka { get; set; }

        [DisplayName("Opis")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        public string opis { get; set; }
    }
}