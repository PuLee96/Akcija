using Akcija.Baza_povezivanje;
using Akcija.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Akcija.Controllers
{
    public class Provjera 
    {
        public int KorisnikId { get; set; }

        public static Provjera Tren
        {
            get
            {
                Provjera ses = (Provjera)HttpContext.Current.Session["id_korisnik"];
                HttpContext.Current.Session.Timeout = 60;
                if (ses == null)
                {
                    ses = new Provjera();
                    HttpContext.Current.Session["id_korisnik"] = ses;

                }
                return ses;
            }
        }

        public static void Odjava()
        {

            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();


        }
    }
}