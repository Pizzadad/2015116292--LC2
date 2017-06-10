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
    public class AdministradorEquipoesController : Controller
    {
        private _2015116292_DbContext db = new _2015116292_DbContext();

        // GET: AdministradorEquipoes
        public ActionResult Index()
        {
            var administradorEquipo1 = db.AdministradorEquipo1.Include(a => a._Equipocelular);
            return View(administradorEquipo1.ToList());
        }

        // GET: AdministradorEquipoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdministradorEquipo administradorEquipo = db.AdministradorEquipo1.Find(id);
            if (administradorEquipo == null)
            {
                return HttpNotFound();
            }
            return View(administradorEquipo);
        }

        // GET: AdministradorEquipoes/Create
        public ActionResult Create()
        {
            ViewBag.Equipocelular_id = new SelectList(db.Equipocelular1, "Equipocelular_id", "Equipocelular_modelo");
            return View();
        }

        // POST: AdministradorEquipoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdministradorEquipo_id,AdministradorEquipo_modelo,Equipocelular_id")] AdministradorEquipo administradorEquipo)
        {
            if (ModelState.IsValid)
            {
                db.AdministradorEquipo1.Add(administradorEquipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Equipocelular_id = new SelectList(db.Equipocelular1, "Equipocelular_id", "Equipocelular_modelo", administradorEquipo.Equipocelular_id);
            return View(administradorEquipo);
        }

        // GET: AdministradorEquipoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdministradorEquipo administradorEquipo = db.AdministradorEquipo1.Find(id);
            if (administradorEquipo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Equipocelular_id = new SelectList(db.Equipocelular1, "Equipocelular_id", "Equipocelular_modelo", administradorEquipo.Equipocelular_id);
            return View(administradorEquipo);
        }

        // POST: AdministradorEquipoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdministradorEquipo_id,AdministradorEquipo_modelo,Equipocelular_id")] AdministradorEquipo administradorEquipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(administradorEquipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Equipocelular_id = new SelectList(db.Equipocelular1, "Equipocelular_id", "Equipocelular_modelo", administradorEquipo.Equipocelular_id);
            return View(administradorEquipo);
        }

        // GET: AdministradorEquipoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdministradorEquipo administradorEquipo = db.AdministradorEquipo1.Find(id);
            if (administradorEquipo == null)
            {
                return HttpNotFound();
            }
            return View(administradorEquipo);
        }

        // POST: AdministradorEquipoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AdministradorEquipo administradorEquipo = db.AdministradorEquipo1.Find(id);
            db.AdministradorEquipo1.Remove(administradorEquipo);
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
