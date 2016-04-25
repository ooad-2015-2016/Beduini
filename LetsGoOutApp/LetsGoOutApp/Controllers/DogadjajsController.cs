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
    public class DogadjajsController : Controller
    {
        private DogadjajDbContext db = new DogadjajDbContext();

        // GET: Dogadjajs
        public ActionResult Index()
        {
            return View(db.Dogadjaj.ToList());
        }

        // GET: Dogadjajs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dogadjaj dogadjaj = db.Dogadjaj.Find(id);
            if (dogadjaj == null)
            {
                return HttpNotFound();
            }
            return View(dogadjaj);
        }

        // GET: Dogadjajs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dogadjajs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,datum,naziv,opis,cijena")] Dogadjaj dogadjaj)
        {
            if (ModelState.IsValid)
            {
                db.Dogadjaj.Add(dogadjaj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dogadjaj);
        }

        // GET: Dogadjajs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dogadjaj dogadjaj = db.Dogadjaj.Find(id);
            if (dogadjaj == null)
            {
                return HttpNotFound();
            }
            return View(dogadjaj);
        }

        // POST: Dogadjajs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,datum,naziv,opis,cijena")] Dogadjaj dogadjaj)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dogadjaj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dogadjaj);
        }

        // GET: Dogadjajs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dogadjaj dogadjaj = db.Dogadjaj.Find(id);
            if (dogadjaj == null)
            {
                return HttpNotFound();
            }
            return View(dogadjaj);
        }

        // POST: Dogadjajs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dogadjaj dogadjaj = db.Dogadjaj.Find(id);
            db.Dogadjaj.Remove(dogadjaj);
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
