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
    public class EvaluacionsController : Controller
    {
        private _2015116292_DbContext db = new _2015116292_DbContext();

        // GET: Evaluacions
        public ActionResult Index()
        {
            var evaluacion1 = db.Evaluacion1.Include(e => e._Centrodeatencion).Include(e => e._Cliente).Include(e => e._Equipocelular).Include(e => e._Estadodeevaluacion).Include(e => e._lineatelefonica).Include(e => e._Plan).Include(e => e._Tipodeevaluacion).Include(e => e._Trabajador);
            return View(evaluacion1.ToList());
        }

        // GET: Evaluacions/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion evaluacion = db.Evaluacion1.Find(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            return View(evaluacion);
        }

        // GET: Evaluacions/Create
        public ActionResult Create()
        {
            ViewBag.Centrodeatencion_id = new SelectList(db.Centrodeatencion1, "Centrodeatencion_id", "Centrodeatencion_nombre");
            ViewBag.Cliente_id = new SelectList(db.Cliente1, "Cliente_id", "Cliente_nombre");
            ViewBag.Equipocelular_id = new SelectList(db.Equipocelular1, "Equipocelular_id", "Equipocelular_modelo");
            ViewBag.Estadodeevaluacion_id = new SelectList(db.Estadodeevaluacion1, "Estadodeevaluacion_id", "Estadodeevaluacion_estado");
            ViewBag.lineatelefonica_id = new SelectList(db.lineatelefonica1, "lineatelefonica_id", "lineatelefonica_numero");
            ViewBag.Plan_id = new SelectList(db.Plan1, "Plan_id", "Plan_descripcion");
            ViewBag.Tipodeevaluacion_id = new SelectList(db.Tipodeevaluacion1, "Tipodeevaluacion_id", "Tipodeevaluacion_tipo");
            ViewBag.Trabajador_id = new SelectList(db.Trabajador1, "Trabajador_id", "Trabajador_nombre");
            return View();
        }

        // POST: Evaluacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Evaluacion_id,Evaluacion_caso,Cliente_id,Plan_id,lineatelefonica_id,Centrodeatencion_id,Trabajador_id,Equipocelular_id,Estadodeevaluacion_id,Tipodeevaluacion_id")] Evaluacion evaluacion)
        {
            if (ModelState.IsValid)
            {
                db.Evaluacion1.Add(evaluacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Centrodeatencion_id = new SelectList(db.Centrodeatencion1, "Centrodeatencion_id", "Centrodeatencion_nombre", evaluacion.Centrodeatencion_id);
            ViewBag.Cliente_id = new SelectList(db.Cliente1, "Cliente_id", "Cliente_nombre", evaluacion.Cliente_id);
            ViewBag.Equipocelular_id = new SelectList(db.Equipocelular1, "Equipocelular_id", "Equipocelular_modelo", evaluacion.Equipocelular_id);
            ViewBag.Estadodeevaluacion_id = new SelectList(db.Estadodeevaluacion1, "Estadodeevaluacion_id", "Estadodeevaluacion_estado", evaluacion.Estadodeevaluacion_id);
            ViewBag.lineatelefonica_id = new SelectList(db.lineatelefonica1, "lineatelefonica_id", "lineatelefonica_numero", evaluacion.lineatelefonica_id);
            ViewBag.Plan_id = new SelectList(db.Plan1, "Plan_id", "Plan_descripcion", evaluacion.Plan_id);
            ViewBag.Tipodeevaluacion_id = new SelectList(db.Tipodeevaluacion1, "Tipodeevaluacion_id", "Tipodeevaluacion_tipo", evaluacion.Tipodeevaluacion_id);
            ViewBag.Trabajador_id = new SelectList(db.Trabajador1, "Trabajador_id", "Trabajador_nombre", evaluacion.Trabajador_id);
            return View(evaluacion);
        }

        // GET: Evaluacions/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion evaluacion = db.Evaluacion1.Find(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.Centrodeatencion_id = new SelectList(db.Centrodeatencion1, "Centrodeatencion_id", "Centrodeatencion_nombre", evaluacion.Centrodeatencion_id);
            ViewBag.Cliente_id = new SelectList(db.Cliente1, "Cliente_id", "Cliente_nombre", evaluacion.Cliente_id);
            ViewBag.Equipocelular_id = new SelectList(db.Equipocelular1, "Equipocelular_id", "Equipocelular_modelo", evaluacion.Equipocelular_id);
            ViewBag.Estadodeevaluacion_id = new SelectList(db.Estadodeevaluacion1, "Estadodeevaluacion_id", "Estadodeevaluacion_estado", evaluacion.Estadodeevaluacion_id);
            ViewBag.lineatelefonica_id = new SelectList(db.lineatelefonica1, "lineatelefonica_id", "lineatelefonica_numero", evaluacion.lineatelefonica_id);
            ViewBag.Plan_id = new SelectList(db.Plan1, "Plan_id", "Plan_descripcion", evaluacion.Plan_id);
            ViewBag.Tipodeevaluacion_id = new SelectList(db.Tipodeevaluacion1, "Tipodeevaluacion_id", "Tipodeevaluacion_tipo", evaluacion.Tipodeevaluacion_id);
            ViewBag.Trabajador_id = new SelectList(db.Trabajador1, "Trabajador_id", "Trabajador_nombre", evaluacion.Trabajador_id);
            return View(evaluacion);
        }

        // POST: Evaluacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Evaluacion_id,Evaluacion_caso,Cliente_id,Plan_id,lineatelefonica_id,Centrodeatencion_id,Trabajador_id,Equipocelular_id,Estadodeevaluacion_id,Tipodeevaluacion_id")] Evaluacion evaluacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evaluacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Centrodeatencion_id = new SelectList(db.Centrodeatencion1, "Centrodeatencion_id", "Centrodeatencion_nombre", evaluacion.Centrodeatencion_id);
            ViewBag.Cliente_id = new SelectList(db.Cliente1, "Cliente_id", "Cliente_nombre", evaluacion.Cliente_id);
            ViewBag.Equipocelular_id = new SelectList(db.Equipocelular1, "Equipocelular_id", "Equipocelular_modelo", evaluacion.Equipocelular_id);
            ViewBag.Estadodeevaluacion_id = new SelectList(db.Estadodeevaluacion1, "Estadodeevaluacion_id", "Estadodeevaluacion_estado", evaluacion.Estadodeevaluacion_id);
            ViewBag.lineatelefonica_id = new SelectList(db.lineatelefonica1, "lineatelefonica_id", "lineatelefonica_numero", evaluacion.lineatelefonica_id);
            ViewBag.Plan_id = new SelectList(db.Plan1, "Plan_id", "Plan_descripcion", evaluacion.Plan_id);
            ViewBag.Tipodeevaluacion_id = new SelectList(db.Tipodeevaluacion1, "Tipodeevaluacion_id", "Tipodeevaluacion_tipo", evaluacion.Tipodeevaluacion_id);
            ViewBag.Trabajador_id = new SelectList(db.Trabajador1, "Trabajador_id", "Trabajador_nombre", evaluacion.Trabajador_id);
            return View(evaluacion);
        }

        // GET: Evaluacions/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion evaluacion = db.Evaluacion1.Find(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            return View(evaluacion);
        }

        // POST: Evaluacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Evaluacion evaluacion = db.Evaluacion1.Find(id);
            db.Evaluacion1.Remove(evaluacion);
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
