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
    public class CentrodeatencionsController : Controller
    {
        private _2015116292_DbContext db = new _2015116292_DbContext();

        // GET: Centrodeatencions
        public ActionResult Index()
        {
            var centrodeatencion1 = db.Centrodeatencion1.Include(c => c._Direccion);
            return View(centrodeatencion1.ToList());
        }

        // GET: Centrodeatencions/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Centrodeatencion centrodeatencion = db.Centrodeatencion1.Find(id);
            if (centrodeatencion == null)
            {
                return HttpNotFound();
            }
            return View(centrodeatencion);
        }

        // GET: Centrodeatencions/Create
        public ActionResult Create()
        {
            ViewBag.Direccion_id = new SelectList(db.Direccion1, "Direccion_id", "Direccion_lugar");
            return View();
        }

        // POST: Centrodeatencions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Centrodeatencion_id,Centrodeatencion_nombre,Direccion_id")] Centrodeatencion centrodeatencion)
        {
            if (ModelState.IsValid)
            {
                db.Centrodeatencion1.Add(centrodeatencion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Direccion_id = new SelectList(db.Direccion1, "Direccion_id", "Direccion_lugar", centrodeatencion.Direccion_id);
            return View(centrodeatencion);
        }

        // GET: Centrodeatencions/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Centrodeatencion centrodeatencion = db.Centrodeatencion1.Find(id);
            if (centrodeatencion == null)
            {
                return HttpNotFound();
            }
            ViewBag.Direccion_id = new SelectList(db.Direccion1, "Direccion_id", "Direccion_lugar", centrodeatencion.Direccion_id);
            return View(centrodeatencion);
        }

        // POST: Centrodeatencions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Centrodeatencion_id,Centrodeatencion_nombre,Direccion_id")] Centrodeatencion centrodeatencion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(centrodeatencion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Direccion_id = new SelectList(db.Direccion1, "Direccion_id", "Direccion_lugar", centrodeatencion.Direccion_id);
            return View(centrodeatencion);
        }

        // GET: Centrodeatencions/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Centrodeatencion centrodeatencion = db.Centrodeatencion1.Find(id);
            if (centrodeatencion == null)
            {
                return HttpNotFound();
            }
            return View(centrodeatencion);
        }

        // POST: Centrodeatencions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Centrodeatencion centrodeatencion = db.Centrodeatencion1.Find(id);
            db.Centrodeatencion1.Remove(centrodeatencion);
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
