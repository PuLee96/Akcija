using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Akcija.Models;
using System.Data.Entity;

namespace Akcija.Baza_povezivanje
{
    public class akcija :DbContext
    {
        public DbSet<Korisnik> korisnik { get; set; }

        public DbSet<Kategorija> kategorija { get; set; }
    }
}