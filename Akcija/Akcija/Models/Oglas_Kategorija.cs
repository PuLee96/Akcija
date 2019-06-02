using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Akcija.Models
{
    public class Oglas_Kategorija
    {
        public Oglas oglas { get; set; }

        [DisplayName("Kategorija")]
        public string kategorija { get; set; }

        [DisplayName("artikl")]
        public string artikl { get; set; }
    }
}