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
    public class KategorijaController : Controller
    {
        private akcija baza = new akcija();
        public ActionResult Index()
        {
            ViewBag.Title = "Baza kategorija";
            return View();
        }
        public ActionResult PopisKategorija(string naziv, string kategorija)
        {
            List<Kategorija> popis = baza.kategorija.ToList();

            if (!String.IsNullOrEmpty(naziv))
            {
                popis = popis.Where(
                       st => (st.naziv_kategorije).ToUpper().
                           Contains(naziv.ToUpper())).
                           OrderBy(st => st.naziv_kategorije).ToList();
            }
            ViewBag.Title = "Popis kategorija";
            return View(popis);
        }


        [HttpGet]
        public ActionResult DodavanjeKategorija(int? id)
        {
            Kategorija k;
            if (id == null)
            {
                k = new Kategorija();
            }
            else
            {
                k = baza.kategorija.Find(id);
                if (k == null)
                {
                    return HttpNotFound();
                }
            }

            List<Kategorija> kategorija = baza.kategorija.ToList();
            kategorija.Add(new Kategorija { naziv_kategorije = "Nedefinirano" });
            ViewBag.Kategorije = kategorija;
            ViewBag.Title = "Dodavanje nove kategorije";
            return View(k);
        }


        [HttpPost]
        public ActionResult DodavanjeKategorija(Kategorija k)
        {

            if (ModelState.IsValid)
            {
                if (k.id_kategorija != 0)
                {
                    // ažuriranje

                    baza.Entry(k).State =
                        EntityState.Modified;

                }
                else
                {
                    // upis
                    baza.kategorija.Add(k);

                }

                baza.SaveChanges();

                return RedirectToAction("PopisKategorija");
            }
            List<Kategorija> kategorija = baza.kategorija.ToList();
            kategorija.Add(new Kategorija { naziv_kategorije = "Nedefinirano" });
            ViewBag.Kategorije = kategorija;
            ViewBag.Title = "Dodavanje nove kategorije";
            return View(k);
        }
        [HttpGet]
        public ActionResult UrediKategoriju(int id)
        {

            Kategorija k = new Kategorija();
            foreach (Kategorija kat in baza.kategorija)
            {
                if (kat.id_kategorija == id)
                {

                    k = kat;
                }
            }

            if (k == null)
            {
                return HttpNotFound();

            }
            if (Request.IsAjaxRequest())

            {
                ViewBag.IsUpdate = false;

                return View("UrediKategoriju", k);
            }
            else
                return View("UrediKategoriju", k);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UrediKategoriju([Bind(Include = "id_kategorija, naziv_kategorije")] Kategorija kat)
        {
            if (!ModelState.IsValid)
            {
                return View("UrediKategoriju", kat);

            }

            Kategorija K = baza.kategorija.Where(

             x => x.id_kategorija == kat.id_kategorija).SingleOrDefault();

            if (kat.id_kategorija != 0 && K != null)
            {
                baza.Entry(K).CurrentValues.SetValues(kat);
            }
            else
            {
                baza.kategorija.Add(kat);
            }
            baza.SaveChanges();
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);

            }
            return RedirectToAction("PopisKategorija");
        }


        public ActionResult ObrisiKategoriju(int id)
        {
            Kategorija kategorija = baza.kategorija.Find(id);
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("ObrisiKategoriju", kategorija);
            }
            else

                return View("ObrisiKategoriju", kategorija);
        }

        [HttpPost, ActionName("ObrisiKategoriju")]
        [ValidateAntiForgeryToken]
        public ActionResult ObrisiKategoriju1(int id)
        {
            Kategorija K = baza.kategorija.Where(
              x => x.id_kategorija == id).SingleOrDefault();
            List<Oglas> oglasi = baza.Oglasi.Where(o => o.id_kategorija == id).ToList();
            if (oglasi != null)
            {
                foreach (Oglas og in oglasi)
                {
                    baza.Oglasi.Remove(og);
                    baza.SaveChanges();
                }
            }
            if (K != null)
            {
                baza.kategorija.Remove(K);
                baza.SaveChanges();
            }
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("PopisKategorija");
        }
    }
}