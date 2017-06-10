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
    public class DepartamentoesController : Controller
    {
        private _2015116292_DbContext db = new _2015116292_DbContext();

        // GET: Departamentoes
        public ActionResult Index()
        {
            var departamento1 = db.Departamento1.Include(d => d._Provincia);
            return View(departamento1.ToList());
        }

        // GET: Departamentoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamento departamento = db.Departamento1.Find(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        // GET: Departamentoes/Create
        public ActionResult Create()
        {
            ViewBag.Provincia_id = new SelectList(db.Provincia1, "Provincia_id", "Provincia_nombre");
            return View();
        }

        // POST: Departamentoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Departamento_id,Departamento_nombre,Provincia_id")] Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                db.Departamento1.Add(departamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Provincia_id = new SelectList(db.Provincia1, "Provincia_id", "Provincia_nombre", departamento.Provincia_id);
            return View(departamento);
        }

        // GET: Departamentoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamento departamento = db.Departamento1.Find(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.Provincia_id = new SelectList(db.Provincia1, "Provincia_id", "Provincia_nombre", departamento.Provincia_id);
            return View(departamento);
        }

        // POST: Departamentoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Departamento_id,Departamento_nombre,Provincia_id")] Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Provincia_id = new SelectList(db.Provincia1, "Provincia_id", "Provincia_nombre", departamento.Provincia_id);
            return View(departamento);
        }

        // GET: Departamentoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamento departamento = db.Departamento1.Find(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        // POST: Departamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Departamento departamento = db.Departamento1.Find(id);
            db.Departamento1.Remove(departamento);
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
