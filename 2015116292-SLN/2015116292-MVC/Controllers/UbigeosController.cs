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
    public class UbigeosController : Controller
    {
        private _2015116292_DbContext db = new _2015116292_DbContext();

        // GET: Ubigeos
        public ActionResult Index()
        {
            var ubigeo1 = db.Ubigeo1.Include(u => u._Departamento).Include(u => u._Distrito).Include(u => u._Provincia);
            return View(ubigeo1.ToList());
        }

        // GET: Ubigeos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ubigeo ubigeo = db.Ubigeo1.Find(id);
            if (ubigeo == null)
            {
                return HttpNotFound();
            }
            return View(ubigeo);
        }

        // GET: Ubigeos/Create
        public ActionResult Create()
        {
            ViewBag.Departamento_id = new SelectList(db.Departamento1, "Departamento_id", "Departamento_nombre");
            ViewBag.Distrito_id = new SelectList(db.Distrito1, "Distrito_id", "Distrito_nombre");
            ViewBag.Provincia_id = new SelectList(db.Provincia1, "Provincia_id", "Provincia_nombre");
            return View();
        }

        // POST: Ubigeos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ubigeo_id,Ubigeo_numero,Departamento_id,Provincia_id,Distrito_id")] Ubigeo ubigeo)
        {
            if (ModelState.IsValid)
            {
                db.Ubigeo1.Add(ubigeo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Departamento_id = new SelectList(db.Departamento1, "Departamento_id", "Departamento_nombre", ubigeo.Departamento_id);
            ViewBag.Distrito_id = new SelectList(db.Distrito1, "Distrito_id", "Distrito_nombre", ubigeo.Distrito_id);
            ViewBag.Provincia_id = new SelectList(db.Provincia1, "Provincia_id", "Provincia_nombre", ubigeo.Provincia_id);
            return View(ubigeo);
        }

        // GET: Ubigeos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ubigeo ubigeo = db.Ubigeo1.Find(id);
            if (ubigeo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Departamento_id = new SelectList(db.Departamento1, "Departamento_id", "Departamento_nombre", ubigeo.Departamento_id);
            ViewBag.Distrito_id = new SelectList(db.Distrito1, "Distrito_id", "Distrito_nombre", ubigeo.Distrito_id);
            ViewBag.Provincia_id = new SelectList(db.Provincia1, "Provincia_id", "Provincia_nombre", ubigeo.Provincia_id);
            return View(ubigeo);
        }

        // POST: Ubigeos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ubigeo_id,Ubigeo_numero,Departamento_id,Provincia_id,Distrito_id")] Ubigeo ubigeo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ubigeo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departamento_id = new SelectList(db.Departamento1, "Departamento_id", "Departamento_nombre", ubigeo.Departamento_id);
            ViewBag.Distrito_id = new SelectList(db.Distrito1, "Distrito_id", "Distrito_nombre", ubigeo.Distrito_id);
            ViewBag.Provincia_id = new SelectList(db.Provincia1, "Provincia_id", "Provincia_nombre", ubigeo.Provincia_id);
            return View(ubigeo);
        }

        // GET: Ubigeos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ubigeo ubigeo = db.Ubigeo1.Find(id);
            if (ubigeo == null)
            {
                return HttpNotFound();
            }
            return View(ubigeo);
        }

        // POST: Ubigeos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Ubigeo ubigeo = db.Ubigeo1.Find(id);
            db.Ubigeo1.Remove(ubigeo);
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
