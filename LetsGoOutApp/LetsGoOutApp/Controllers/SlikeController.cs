using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LetsGoOutApp.Models;
using System.IO;

namespace LetsGoOutApp.Controllers
{
    public class SlikeController : Controller
    {
        private LetsGoOutAppContext db = new LetsGoOutAppContext();

        // POST: Slike/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int lokalID)
        {
            Lokal lokal = db.Lokali.Find(lokalID);

            if (lokal == null)
                return Json(new { Message = "Lokal nije pronađen." });

            bool uspjeh = true;
            string uploadedName = "";

            foreach (string name in Request.Files)
            {
                try
                {
                    HttpPostedFileBase file = Request.Files[name];
                    if (file != null && file.ContentLength > 0)
                    {
                        uploadedName = RandomName() + Path.GetExtension(file.FileName);
                        file.SaveAs(Server.MapPath("~/uploads/slike/" + uploadedName));

                        // Sačuvaj u bazu
                        Slika slika = new Slika();
                        slika.Naziv = uploadedName;
                        lokal.Slike.Add(slika);
                    }
                }
                catch (Exception)
                {
                    uspjeh = false;
                }
            }

            if (!uspjeh)
                return Json(new { Message = "Dodavanje slike nije uspjelo." });
            else
                return Json(new { Message = uploadedName });
        }

        private string RandomName()
        {
            const string baza = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            string str = "";
            Random random = new Random();
            for (int i = 0; i < 20; i++)
                str += baza[random.Next(61)];

            return str;
        }
    }
}