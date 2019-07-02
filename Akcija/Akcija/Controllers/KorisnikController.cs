using Akcija.Baza_povezivanje;
using Akcija.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Akcija.Controllers
{
    public class KorisnikController : Controller
    {
        akcija baza = new akcija();
        public ActionResult Index()
        {
            ViewBag.Korisnici = "Baza korisnika";
            return View();
        }
        public ActionResult PopisKorisnika(string naziv, string korisnik)
        {
            List<Korisnik> popis = baza.korisnik.ToList();

            if (!String.IsNullOrEmpty(naziv))
            {
                popis = popis.Where(
                       st => (st.ime).ToUpper().
                           Contains(naziv.ToUpper())).
                           OrderBy(st => st.ime).ToList();
            }
            ViewBag.Title = "Popis korisnika";
            return View(popis);
        }
        [HttpGet]
        public ActionResult DodavanjeKorisnika(int? id)
        {

            Korisnik k;
            if (id == null)
            {
                k = new Korisnik();
            }
            else
            {
                k = baza.korisnik.Find(id);
                if (k == null)
                {
                    return HttpNotFound();
                }
            }
            List<Poduzece> poduzeca = baza.Poduzeca.ToList();
            List<Object> pod = new List<object>();
            foreach (Poduzece p in poduzeca)
            {
                pod.Add(new { value = p.id_poduzece, text = p.naziv_poduzece });
            }
            List<Korisnik> korisnici = baza.korisnik.ToList();
            korisnici.Add(new Korisnik { ime = "Nedefinirano" });
            ViewBag.Korisnici = korisnici;
            ViewBag.Poduzeca = pod;
            ViewBag.Title = "Dodavanje novog korisnika";
            return View(k);
        }


        [HttpPost]
        public ActionResult DodavanjeKorisnika(Korisnik k)
        {

            if (ModelState.IsValid)
            {
                if (k.id_korisnik != 0)
                {
                    // ažuriranje

                    baza.Entry(k).State =
                        EntityState.Modified;

                }
                else
                {
                    // upis
                    baza.korisnik.Add(k);

                }

                baza.SaveChanges();

                return RedirectToAction("PopisKorisnika");
            }
            List<Korisnik> korisnici = baza.korisnik.ToList();
            korisnici.Add(new Korisnik { ime = "Nedefinirano" });
            ViewBag.Korisnici = korisnici;
            ViewBag.Title = "Dodavanje novog korisnika";
            return View(k);
        }

        [HttpGet]
        public ActionResult UrediKorisnika(int id)
        {

            Korisnik k = new Korisnik();
            foreach (Korisnik kor in baza.korisnik)
            {
                if (kor.id_korisnik == id)
                {

                    k = kor;
                }
            }

            if (k == null)
            {
                return HttpNotFound();

            }
            if (Request.IsAjaxRequest())

            {
                ViewBag.IsUpdate = false;

                return View("UrediKorisnika", k);
            }
            else
                return View("UrediKorisnika", k);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UrediKorisnika([Bind(Include = "id_korisnik,id_poduzece, ime,prezime, email, lozinka")] Korisnik kor)
        {
            if (!ModelState.IsValid)
            {
                return View("UrediKorisnika", kor);

            }

            Korisnik K = baza.korisnik.Where(

             x => x.id_korisnik == kor.id_korisnik).SingleOrDefault();

            if (kor.id_korisnik != 0 && K != null)
            {
                baza.Entry(K).CurrentValues.SetValues(kor);
            }
            else
            {
                baza.korisnik.Add(kor);
            }
            baza.SaveChanges();
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);

            }
            return RedirectToAction("PopisKorisnika");
        }



        public ActionResult ObrisiKorisnika(int id)
        {
            Korisnik korisnik = baza.korisnik.Find(id);
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("ObrisiKorisnika", korisnik);
            }
            else

                return View("ObrisiKorisnika", korisnik);
        }

        [HttpPost, ActionName("ObrisiKorisnika")]
        [ValidateAntiForgeryToken]
        public ActionResult ObrisiKorisnika1(int id)
        {
            Korisnik K = baza.korisnik.Where(
              x => x.id_korisnik == id).SingleOrDefault();

            if (K != null)
            {
                baza.korisnik.Remove(K);
                baza.SaveChanges();
            }
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("PopisKorisnika");
        }

    }
}