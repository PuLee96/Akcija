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
    public class Sesija 
    {
        public int KorisnikId { get; set; }

        public static Sesija Tren
        {
            get
            {
                Sesija ses = (Sesija)HttpContext.Current.Session["id_korisnik"];
                HttpContext.Current.Session.Timeout = 60;
                if (ses == null)
                {
                    ses = new Sesija();
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