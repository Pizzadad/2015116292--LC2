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
    public class lineatelefonicasController : Controller
    {
        private _2015116292_DbContext db = new _2015116292_DbContext();

        // GET: lineatelefonicas
        public ActionResult Index()
        {
            var lineatelefonica1 = db.lineatelefonica1.Include(l => l._tipolinea);
            return View(lineatelefonica1.ToList());
        }

        // GET: lineatelefonicas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lineatelefonica lineatelefonica = db.lineatelefonica1.Find(id);
            if (lineatelefonica == null)
            {
                return HttpNotFound();
            }
            return View(lineatelefonica);
        }

        // GET: lineatelefonicas/Create
        public ActionResult Create()
        {
            ViewBag.tipolinea_id = new SelectList(db.tipolinea1, "tipolinea_id", "tipolinea_nombre");
            return View();
        }

        // POST: lineatelefonicas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "lineatelefonica_id,lineatelefonica_numero,tipolinea_id")] lineatelefonica lineatelefonica)
        {
            if (ModelState.IsValid)
            {
                db.lineatelefonica1.Add(lineatelefonica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tipolinea_id = new SelectList(db.tipolinea1, "tipolinea_id", "tipolinea_nombre", lineatelefonica.tipolinea_id);
            return View(lineatelefonica);
        }

        // GET: lineatelefonicas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lineatelefonica lineatelefonica = db.lineatelefonica1.Find(id);
            if (lineatelefonica == null)
            {
                return HttpNotFound();
            }
            ViewBag.tipolinea_id = new SelectList(db.tipolinea1, "tipolinea_id", "tipolinea_nombre", lineatelefonica.tipolinea_id);
            return View(lineatelefonica);
        }

        // POST: lineatelefonicas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "lineatelefonica_id,lineatelefonica_numero,tipolinea_id")] lineatelefonica lineatelefonica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lineatelefonica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tipolinea_id = new SelectList(db.tipolinea1, "tipolinea_id", "tipolinea_nombre", lineatelefonica.tipolinea_id);
            return View(lineatelefonica);
        }

        // GET: lineatelefonicas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lineatelefonica lineatelefonica = db.lineatelefonica1.Find(id);
            if (lineatelefonica == null)
            {
                return HttpNotFound();
            }
            return View(lineatelefonica);
        }

        // POST: lineatelefonicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            lineatelefonica lineatelefonica = db.lineatelefonica1.Find(id);
            db.lineatelefonica1.Remove(lineatelefonica);
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
