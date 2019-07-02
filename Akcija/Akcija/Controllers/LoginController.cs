using Akcija.Baza_povezivanje;
using Akcija.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Akcija.Controllers
{
    public class LoginController : Controller
    {
        private akcija baza = new akcija();

        [HttpGet]
        public ActionResult Prijava()
        {


            Provjera.Tren.KorisnikId = 0;
            Korisnik kor = new Korisnik();

            return View(kor);
        }

        [HttpPost]
        public ActionResult Prijava(Korisnik k)
        {

            Korisnik korisnik = baza.korisnik.SingleOrDefault(kor => kor.email == k.email && kor.lozinka == k.lozinka);


            if (korisnik != null)
            {
                Provjera.Tren.KorisnikId = korisnik.id_korisnik;
                return RedirectToAction("Index", "Home");
            }

            else
            {
                {


                    return View("Prijava");
                }
            }
        }


        public ActionResult Odjava()
        {

            Provjera.Odjava();
            FormsAuthentication.SignOut();
            return RedirectToAction("Prijava", "Login");

        }
    }
}