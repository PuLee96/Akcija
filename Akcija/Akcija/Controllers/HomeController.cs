using Akcija.Baza_povezivanje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Akcija.Models;

namespace Akcija.Controllers
{
    public class HomeController : Controller
    {
        private akcija db = new akcija();

        public ActionResult Index()
        {
            return View();
        }

        

        [HttpGet]
        public ActionResult Prijava()
        {


            return View();
        }

        [HttpPost]

        public ActionResult Prijava(Korisnik user)
        {

            foreach (Korisnik stud in db.korisnik)
            {

                if (stud.lozinka == user.lozinka && stud.email == user.email)
                {
                    

                    
                    return Content("Logirao si se u sustav");
                }


            }

            return Content("Nisi pravilno unio korisnika");
        }
    }
}