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
    public class PlansController : Controller
    {
        private _2015116292_DbContext db = new _2015116292_DbContext();

        // GET: Plans
        public ActionResult Index()
        {
            var plan1 = db.Plan1.Include(p => p._TipoPlan);
            return View(plan1.ToList());
        }

        // GET: Plans/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.Plan1.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // GET: Plans/Create
        public ActionResult Create()
        {
            ViewBag.TipoPlan_id = new SelectList(db.TipoPlan1, "TipoPlan_id", "TipoPlan_caracteristica");
            return View();
        }

        // POST: Plans/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Plan_id,Plan_descripcion,TipoPlan_id")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                db.Plan1.Add(plan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoPlan_id = new SelectList(db.TipoPlan1, "TipoPlan_id", "TipoPlan_caracteristica", plan.TipoPlan_id);
            return View(plan);
        }

        // GET: Plans/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.Plan1.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoPlan_id = new SelectList(db.TipoPlan1, "TipoPlan_id", "TipoPlan_caracteristica", plan.TipoPlan_id);
            return View(plan);
        }

        // POST: Plans/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Plan_id,Plan_descripcion,TipoPlan_id")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoPlan_id = new SelectList(db.TipoPlan1, "TipoPlan_id", "TipoPlan_caracteristica", plan.TipoPlan_id);
            return View(plan);
        }

        // GET: Plans/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.Plan1.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // POST: Plans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Plan plan = db.Plan1.Find(id);
            db.Plan1.Remove(plan);
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
