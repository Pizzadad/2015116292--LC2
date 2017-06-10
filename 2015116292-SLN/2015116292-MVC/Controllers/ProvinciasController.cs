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
    public class ProvinciasController : Controller
    {
        private _2015116292_DbContext db = new _2015116292_DbContext();

        // GET: Provincias
        public ActionResult Index()
        {
            var provincia1 = db.Provincia1.Include(p => p._Distrito);
            return View(provincia1.ToList());
        }

        // GET: Provincias/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincia provincia = db.Provincia1.Find(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            return View(provincia);
        }

        // GET: Provincias/Create
        public ActionResult Create()
        {
            ViewBag.Distrito_id = new SelectList(db.Distrito1, "Distrito_id", "Distrito_nombre");
            return View();
        }

        // POST: Provincias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Provincia_id,Provincia_nombre,Distrito_id")] Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                db.Provincia1.Add(provincia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Distrito_id = new SelectList(db.Distrito1, "Distrito_id", "Distrito_nombre", provincia.Distrito_id);
            return View(provincia);
        }

        // GET: Provincias/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincia provincia = db.Provincia1.Find(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            ViewBag.Distrito_id = new SelectList(db.Distrito1, "Distrito_id", "Distrito_nombre", provincia.Distrito_id);
            return View(provincia);
        }

        // POST: Provincias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Provincia_id,Provincia_nombre,Distrito_id")] Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(provincia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Distrito_id = new SelectList(db.Distrito1, "Distrito_id", "Distrito_nombre", provincia.Distrito_id);
            return View(provincia);
        }

        // GET: Provincias/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincia provincia = db.Provincia1.Find(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            return View(provincia);
        }

        // POST: Provincias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Provincia provincia = db.Provincia1.Find(id);
            db.Provincia1.Remove(provincia);
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
