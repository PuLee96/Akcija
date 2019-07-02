using Akcija.Baza_povezivanje;
using Akcija.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
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
    public class AkcijaController : Controller
    {
         akcija baza = new akcija();
        public ActionResult Index()
        {

            ViewBag.Title = "Baza akcija";
            return View();
        }
        public ActionResult PopisAkcija(string naziv, string kategorija)
        {
            List<Akcije> popis = baza.Akcije.ToList();

            if (!String.IsNullOrEmpty(naziv))
            {
                popis = popis.Where(
                       st => (st.naziv_akcija).ToUpper().
                           Contains(naziv.ToUpper())).
                           OrderBy(st => st.naziv_akcija).ToList();
            }
            ViewBag.Title = "Popis akcija";
            return View(popis);
        }


        [HttpGet]
        public ActionResult DodavanjeAkcija(int? id)
        {
            Akcije a;
            if (id == null)
            {
                a = new Akcije();
            }
            else
            {
                a = baza.Akcije.Find(id);
                if (a == null)
                {
                    return HttpNotFound();
                }
            }
            List<Akcije> akcija = baza.Akcije.ToList();

            akcija.Add(new Akcije { naziv_akcija = "Nedefinirano" });
            ViewBag.Akcije = akcija;
            ViewBag.Title = "Dodavanje nove akcije";
            List<Poduzece> poduzeca = baza.Poduzeca.ToList();
            List<Akcije> akcije = baza.Akcije.ToList();
            List<Object> pod = new List<object>();
            foreach (Poduzece p in poduzeca)
            {
                pod.Add(new { value = p.id_poduzece, text = p.naziv_poduzece });
            }

            ViewBag.Poduzeca = pod;
            return View(a);
        }


        [HttpPost]
        public ActionResult DodavanjeAkcija(Akcije a)
        {

            //int veci = DateTime.Compare(a.datum_pocetka, a.datum_zavrsetka);
            //if (veci > 0)
            //    ModelState.AddModelError("datum_zavrsetka", "Datum početka mora biti veći od datuma završetka");


            if (ModelState.IsValid)
            {


                if (a.id_akcija != 0)
                {
                    // ažuriranje

                    baza.Entry(a).State =
                        EntityState.Modified;

                }
                else
                {
                    baza.Akcije.Add(a);

                }

                baza.SaveChanges();

                return RedirectToAction("PopisAkcija");
            }

            List<Akcije> akcije = baza.Akcije.ToList();
            akcije.Add(new Akcije { naziv_akcija = "Nedefinirano" });
            ViewBag.Akcije = akcije;
            ViewBag.Title = "Dodavanje nove akcije";
            return View(a);
        }



        [HttpGet]
        public ActionResult UrediAkciju(int id)
        {

            Akcije a = new Akcije();
            foreach (Akcije akc in baza.Akcije)
            {
                if (akc.id_akcija == id)
                {

                    a = akc;
                }
            }

            if (a == null)
            {
                return HttpNotFound();

            }
            if (Request.IsAjaxRequest())

            {
                ViewBag.IsUpdate = false;

                return View("UrediAkciju", a);
            }
            else
                return View("UrediAkciju", a);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UrediAkciju([Bind(Include = "id_poduzece, id_akcija, id_oglas, naziv_akcija, datum_pocetka, datum_zavrsetka , datum_zavrsetka,opis")] Akcije akc)
        {
            if (!ModelState.IsValid)
            {
                return View("UrediAkciju", akc);

            }

            Akcije A = baza.Akcije.Where(

             x => x.id_akcija == akc.id_akcija).SingleOrDefault();

            if (akc.id_akcija != 0 && A != null)
            {
                baza.Entry(A).CurrentValues.SetValues(akc);
            }
            else
            {
                baza.Akcije.Add(akc);
            }
            baza.SaveChanges();
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);

            }
            return RedirectToAction("PopisAkcija");
        }

        public ActionResult ObrisiAkciju(int id)
        {
            Akcije akc = baza.Akcije.Find(id);
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("ObrisiAkciju", akc);
            }
            else

                return View("ObrisiAkciju", akc);
        }

        [HttpPost, ActionName("ObrisiAkciju")]
        [ValidateAntiForgeryToken]
        public ActionResult ObrisiAkciju1(int id)
        {
            Akcije A = baza.Akcije.Where(
              x => x.id_akcija == id).SingleOrDefault();

            if (A != null)
            {
                baza.Akcije.Remove(A);
                baza.SaveChanges();
            }
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("PopisAkcija");
        }


        public FileResult CreatePdf()
        {
            MemoryStream workStream = new MemoryStream();
            StringBuilder status = new StringBuilder("");
            DateTime dTime = DateTime.Now;
            dTime.ToShortDateString();

            string strPDFFileName = string.Format("Popis Akcija" + dTime.ToString("ddMMyyyy") + "-" + ".pdf");
            Document doc = new Document();
            doc.SetMargins(0f, 0f, 0f, 0f);

            PdfPTable tableLayout = new PdfPTable(4);
            doc.SetMargins(0f, 0f, 0f, 0f);

            string strAttachment = Server.MapPath("~/Downloads/" + strPDFFileName);


            PdfWriter.GetInstance(doc, workStream).CloseStream = false;
            doc.Open();


            doc.Add(Add_Content_To_PDF(tableLayout));


            doc.Close();

            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;


            return File(workStream, "application/pdf", strPDFFileName);

        }
        protected PdfPTable Add_Content_To_PDF(PdfPTable tableLayout)
        {

            float[] headers = { 24, 45, 35, 50 };
            tableLayout.SetWidths(headers);
            tableLayout.WidthPercentage = 100;
            tableLayout.HeaderRows = 1;


            List<Akcije> akcije = baza.Akcije.ToList<Akcije>();



            tableLayout.AddCell(new PdfPCell(new Phrase("POPIS AKCIJA", new Font(Font.FontFamily.HELVETICA, 18, 1, new iTextSharp.text.BaseColor(0, 0, 1))))
            {
                Colspan = 12,
                Border = 0,
                PaddingBottom = 5,
                HorizontalAlignment = Element.ALIGN_CENTER
            });


            ////Add header  

            AddCellToHeader(tableLayout, "Naziv akcije");
            AddCellToHeader(tableLayout, "Datum pocetka");
            AddCellToHeader(tableLayout, "Datum završetka");
            AddCellToHeader(tableLayout, "Opis");

            ////Add body  

            foreach (var akc in akcije)
            {


                AddCellToBody(tableLayout, akc.naziv_akcija);
                AddCellToBody(tableLayout, akc.datum_pocetka.Value.ToShortDateString());
                AddCellToBody(tableLayout, akc.datum_zavrsetka.Value.ToShortDateString());
                AddCellToBody(tableLayout, akc.opis);

            }

            return tableLayout;
        }
        private static void AddCellToHeader(PdfPTable tableLayout, string cellText)
        {

            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.WHITE)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(0, 0, 230)
            });
        }

        // Method to add single cell to the body  
        private static void AddCellToBody(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255)
            });
        }
    }
}