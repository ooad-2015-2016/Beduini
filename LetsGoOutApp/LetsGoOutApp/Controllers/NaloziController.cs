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
    public class NaloziController : Controller
    {
        private NalogDbContext db = new NalogDbContext();

        // GET: Nalozi
        public ActionResult Index()
        {
            return View(db.Nalog.ToList());
        }

        // GET: Nalozi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nalog nalog = db.Nalog.Find(id);
            if (nalog == null)
            {
                return HttpNotFound();
            }
            return View(nalog);
        }

        // GET: Nalozi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nalozi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,korisnickoIme,password,email,datumKreiranja")] Nalog nalog)
        {
            if (ModelState.IsValid)
            {
                db.Nalog.Add(nalog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nalog);
        }

        // GET: Nalozi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nalog nalog = db.Nalog.Find(id);
            if (nalog == null)
            {
                return HttpNotFound();
            }
            return View(nalog);
        }

        // POST: Nalozi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,korisnickoIme,password,email,datumKreiranja")] Nalog nalog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nalog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nalog);
        }

        // GET: Nalozi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nalog nalog = db.Nalog.Find(id);
            if (nalog == null)
            {
                return HttpNotFound();
            }
            return View(nalog);
        }

        // POST: Nalozi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nalog nalog = db.Nalog.Find(id);
            db.Nalog.Remove(nalog);
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
