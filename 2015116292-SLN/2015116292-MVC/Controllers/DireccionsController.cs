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
    public class DireccionsController : Controller
    {
        private _2015116292_DbContext db = new _2015116292_DbContext();

        // GET: Direccions
        public ActionResult Index()
        {
            var direccion1 = db.Direccion1.Include(d => d._Ubigeo);
            return View(direccion1.ToList());
        }

        // GET: Direccions/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.Direccion1.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // GET: Direccions/Create
        public ActionResult Create()
        {
            ViewBag.Ubigeo_id = new SelectList(db.Ubigeo1, "Ubigeo_id", "Ubigeo_numero");
            return View();
        }

        // POST: Direccions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Direccion_id,Direccion_lugar,Ubigeo_id")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                db.Direccion1.Add(direccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Ubigeo_id = new SelectList(db.Ubigeo1, "Ubigeo_id", "Ubigeo_numero", direccion.Ubigeo_id);
            return View(direccion);
        }

        // GET: Direccions/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.Direccion1.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ubigeo_id = new SelectList(db.Ubigeo1, "Ubigeo_id", "Ubigeo_numero", direccion.Ubigeo_id);
            return View(direccion);
        }

        // POST: Direccions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Direccion_id,Direccion_lugar,Ubigeo_id")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(direccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ubigeo_id = new SelectList(db.Ubigeo1, "Ubigeo_id", "Ubigeo_numero", direccion.Ubigeo_id);
            return View(direccion);
        }

        // GET: Direccions/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.Direccion1.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // POST: Direccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Direccion direccion = db.Direccion1.Find(id);
            db.Direccion1.Remove(direccion);
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
