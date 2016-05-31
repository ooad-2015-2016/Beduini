using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LetsGoOutApp.Models;

namespace LetsGoOutApp.Controllers
{
    public class KomentariController : Controller
    {
        private LetsGoOutAppContext db = new LetsGoOutAppContext();

        // POST: Komentari/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Sadrzaj,Ocjena,DatumKreiranja,LokalID")] Komentar komentar)
        {
            if (ModelState.IsValid)
            {
                db.Komentari.Add(komentar);
                db.SaveChanges();
            }

            return RedirectToAction("Details", "Lokali", new { id = komentar.LokalID });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
