using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _2015116292_ENT.Entities;
using _2015116292_PER;

namespace _2015116292_MVC.Controllers
{
    public class AdmiLineasController : Controller
    {
        private _2015116292_DbContext db = new _2015116292_DbContext();

        // GET: AdmiLineas
        public ActionResult Index()
        {
            var admiLinea1 = db.AdmiLinea1.Include(a => a._lineatelefonica);
            return View(admiLinea1.ToList());
        }

        // GET: AdmiLineas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdmiLinea admiLinea = db.AdmiLinea1.Find(id);
            if (admiLinea == null)
            {
                return HttpNotFound();
            }
            return View(admiLinea);
        }

        // GET: AdmiLineas/Create
        public ActionResult Create()
        {
            ViewBag.lineatelefonica_id = new SelectList(db.lineatelefonica1, "lineatelefonica_id", "lineatelefonica_numero");
            return View();
        }

        // POST: AdmiLineas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "admilinea_id,admilinea_nombre,lineatelefonica_id")] AdmiLinea admiLinea)
        {
            if (ModelState.IsValid)
            {
                db.AdmiLinea1.Add(admiLinea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.lineatelefonica_id = new SelectList(db.lineatelefonica1, "lineatelefonica_id", "lineatelefonica_numero", admiLinea.lineatelefonica_id);
            return View(admiLinea);
        }

        // GET: AdmiLineas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdmiLinea admiLinea = db.AdmiLinea1.Find(id);
            if (admiLinea == null)
            {
                return HttpNotFound();
            }
            ViewBag.lineatelefonica_id = new SelectList(db.lineatelefonica1, "lineatelefonica_id", "lineatelefonica_numero", admiLinea.lineatelefonica_id);
            return View(admiLinea);
        }

        // POST: AdmiLineas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "admilinea_id,admilinea_nombre,lineatelefonica_id")] AdmiLinea admiLinea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admiLinea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.lineatelefonica_id = new SelectList(db.lineatelefonica1, "lineatelefonica_id", "lineatelefonica_numero", admiLinea.lineatelefonica_id);
            return View(admiLinea);
        }

        // GET: AdmiLineas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdmiLinea admiLinea = db.AdmiLinea1.Find(id);
            if (admiLinea == null)
            {
                return HttpNotFound();
            }
            return View(admiLinea);
        }

        // POST: AdmiLineas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AdmiLinea admiLinea = db.AdmiLinea1.Find(id);
            db.AdmiLinea1.Remove(admiLinea);
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
