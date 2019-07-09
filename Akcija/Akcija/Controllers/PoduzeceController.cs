using Akcija.Baza_povezivanje;
using Akcija.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity.Migrations;

namespace Akcija.Controllers
{
    public class PoduzeceController : Controller
    {
        private akcija baza = new akcija();
        public ActionResult Index()
        {

            ViewBag.Title = "Baza poduzeca";
            return View();
        }

        public ActionResult PopisPoduzeca()
        {
            return View(baza.Poduzeca);
        }

        private bool TraziKorisnike(Korisnik k)
        {
            return false;
        }


        public ActionResult Popis(string naziv, string poduzece)
        {
            List<Poduzece> popis = baza.Poduzeca.ToList();

            if (!String.IsNullOrEmpty(naziv))
            {
                popis = popis.Where(
                       st => (st.naziv_poduzece).ToUpper().
                           Contains(naziv.ToUpper())).
                           OrderBy(st => st.naziv_poduzece).ToList();
            }
            ViewBag.Title = "Popis poduzeca";
            return View(popis);
        }


        [HttpGet]
        public ActionResult DodavanjePoduzeca(int? id)
        {
            Poduzece p;
            if (id == null)
            {
                p = new Poduzece();
            }
            else
            {
                p = baza.Poduzeca.Find(id);
                if (p == null)
                {
                    return HttpNotFound();
                }
            }

            List<Poduzece> poduzece = baza.Poduzeca.ToList();
            poduzece.Add(new Poduzece { naziv_poduzece = "Nedefinirano" });
            ViewBag.Poduzece = poduzece;
            ViewBag.Title = "Dodavanje novog poduzeca";
            return View(p);
        }


        [HttpPost]
        public ActionResult DodavanjePoduzeca(Poduzece p)
        {

            if (ModelState.IsValid)
            {
                if (p.id_poduzece != 0)
                {
                    // ažuriranje

                    baza.Entry(p).State =
                        EntityState.Modified;

                }
                else
                {
                    // upis
                    baza.Poduzeca.Add(p);

                }

                baza.SaveChanges();

                return RedirectToAction("Popis");
            }
            List<Poduzece> poduzece = baza.Poduzeca.ToList();
            poduzece.Add(new Poduzece { naziv_poduzece = "Nedefinirano" });
            ViewBag.Poduzece = poduzece;
            ViewBag.Title = "Dodavanje novog poduzeca";
            return View(p);
        }


        [HttpGet]
        public ActionResult UrediPoduzece(int id)
        {

            Poduzece p = new Poduzece();
            foreach (Poduzece pod in baza.Poduzeca)
            {
                if (pod.id_poduzece == id)
                {

                    p = pod;
                }
            }

            if (p == null)
            {
                return HttpNotFound();

            }
            if (Request.IsAjaxRequest())

            {
                ViewBag.IsUpdate = false;

                return View("UrediPoduzece", p);
            }
            else
                return View("UrediPoduzece", p);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UrediPoduzece([Bind(Include = "id_poduzece, naziv_poduzece,adresa, grad, telefon, email, web_adresa")] Poduzece pod)
        {
            if (!ModelState.IsValid)
            {
                return View("UrediPoduzece", pod);

            }

            Poduzece P = baza.Poduzeca.Where(

             x => x.id_poduzece == pod.id_poduzece).SingleOrDefault();

            if (pod.id_poduzece != 0 && P != null)
            {
                baza.Entry(P).CurrentValues.SetValues(pod);
            }
            else
            {
                baza.Poduzeca.Add(pod);
            }
            baza.SaveChanges();
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);

            }
            return RedirectToAction("Popis");
        }

        public ActionResult ObrisiPoduzece(int id)
        {
            Poduzece pod = baza.Poduzeca.Find(id);
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("ObrisiPoduzece", pod);
            }
            else

                return View("ObrisiPoduzece", pod);
        }

        [HttpPost, ActionName("ObrisiPoduzece")]
        [ValidateAntiForgeryToken]
        public ActionResult ObrisiPoduzece1(int id)
        {
            Poduzece P = baza.Poduzeca.Where(
              x => x.id_poduzece == id).SingleOrDefault();

            if (P != null)
            {
                baza.Poduzeca.Remove(P);
                baza.SaveChanges();
            }
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("Popis");
        }
    }
}