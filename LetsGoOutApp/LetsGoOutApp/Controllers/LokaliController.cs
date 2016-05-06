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
    public class LokaliController : Controller
    {
        private LokalDbContext db = new LokalDbContext();

        // GET: Lokali
        public ActionResult Index()
        {
            return View(db.Lokal.ToList());
        }

        // GET: Lokali/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lokal lokal = db.Lokal.Find(id);
            if (lokal == null)
            {
                return HttpNotFound();
            }
            return View(lokal);
        }

        // GET: Lokali/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lokali/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,naziv,adresa,postanskiBroj,grad,lat,lng,opis")] Lokal lokal)
        {
            if (ModelState.IsValid)
            {
                db.Lokal.Add(lokal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lokal);
        }

        // GET: Lokali/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lokal lokal = db.Lokal.Find(id);
            if (lokal == null)
            {
                return HttpNotFound();
            }
            return View(lokal);
        }

        // POST: Lokali/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,naziv,adresa,postanskiBroj,grad,lat,lng,opis")] Lokal lokal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lokal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lokal);
        }

        // GET: Lokali/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lokal lokal = db.Lokal.Find(id);
            if (lokal == null)
            {
                return HttpNotFound();
            }
            return View(lokal);
        }

        // POST: Lokali/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lokal lokal = db.Lokal.Find(id);
            db.Lokal.Remove(lokal);
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
