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
        private KomentarDbContext db = new KomentarDbContext();

        // GET: Komentari
        public ActionResult Index()
        {
            return View(db.Komentar.ToList());
        }

        // GET: Komentari/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Komentar komentar = db.Komentar.Find(id);
            if (komentar == null)
            {
                return HttpNotFound();
            }
            return View(komentar);
        }

        // GET: Komentari/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Komentari/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,datum,sadrzaj,ocjena,datumKreiranja")] Komentar komentar)
        {
            if (ModelState.IsValid)
            {
                db.Komentar.Add(komentar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(komentar);
        }

        // GET: Komentari/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Komentar komentar = db.Komentar.Find(id);
            if (komentar == null)
            {
                return HttpNotFound();
            }
            return View(komentar);
        }

        // POST: Komentari/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,datum,sadrzaj,ocjena,datumKreiranja")] Komentar komentar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(komentar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(komentar);
        }

        // GET: Komentari/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Komentar komentar = db.Komentar.Find(id);
            if (komentar == null)
            {
                return HttpNotFound();
            }
            return View(komentar);
        }

        // POST: Komentari/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Komentar komentar = db.Komentar.Find(id);
            db.Komentar.Remove(komentar);
            db.SaveChanges();
            return RedirectToAction("Index");
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
