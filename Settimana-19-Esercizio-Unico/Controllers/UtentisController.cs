using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Settimana_19_Esercizio_Unico.Models;

namespace Settimana_19_Esercizio_Unico.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UtentisController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        // GET: Utentis
        public ActionResult Index()
        {
            return View(db.Utenti.ToList());
        }

        // GET: Utentis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utenti utenti = db.Utenti.Find(id);
            if (utenti == null)
            {
                return HttpNotFound();
            }
            return View(utenti);
        }

        // GET: Utentis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Utentis/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding.
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Username,Password,Admin")] Utenti utenti)
        {
            if (ModelState.IsValid)
            {
                db.Utenti.Add(utenti);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(utenti);
        }

        // GET: Utentis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utenti utenti = db.Utenti.Find(id);
            if (utenti == null)
            {
                return HttpNotFound();
            }
            return View(utenti);
        }

        // POST: Utentis/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding.
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Username,Password,Admin")] Utenti utenti)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utenti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(utenti);
        }

        // GET: Utentis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utenti utenti = db.Utenti.Find(id);
            if (utenti == null)
            {
                return HttpNotFound();
            }
            return View(utenti);
        }

        // POST: Utentis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Utenti utenti = db.Utenti.Find(id);
            db.Utenti.Remove(utenti);
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
