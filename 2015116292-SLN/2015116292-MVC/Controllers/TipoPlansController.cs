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
using _2015116292_ENT.IRepositories;

namespace _2015116292_MVC.Controllers
{
    public class TipoPlansController : Controller
    {
        //private _2015116292_DbContext db = new _2015116292_DbContext();
        private readonly IUnityOfWork _UnityOfWork;
        // GET: TipoPlans

        public TipoPlansController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        public TipoPlansController()
        {

        }

        public ActionResult Index()
        {
            return View(_UnityOfWork.TipoPlan1.GetAll());
        }

        // GET: TipoPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPlan tipoPlan = _UnityOfWork.TipoPlan1.Get(id);
            if (tipoPlan == null)
            {
                return HttpNotFound();
            }
            return View(tipoPlan);
        }

        // GET: TipoPlans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoPlans/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoPlan_id,TipoPlan_caracteristica")] TipoPlan tipoPlan)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.TipoPlan1.Add(tipoPlan);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoPlan);
        }

        // GET: TipoPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPlan tipoPlan = _UnityOfWork.TipoPlan1.Get(id);
            if (tipoPlan == null)
            {
                return HttpNotFound();
            }
            return View(tipoPlan);
        }

        // POST: TipoPlans/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoPlan_id,TipoPlan_caracteristica")] TipoPlan tipoPlan)
        {
            if (ModelState.IsValid)
            {
                //  _UnityOfWork.Entry(tipoPlan).State = EntityState.Modified;
                _UnityOfWork.StateModified(tipoPlan);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoPlan);
        }

        // GET: TipoPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPlan tipoPlan = _UnityOfWork.TipoPlan1.Get(id);
            if (tipoPlan == null)
            {
                return HttpNotFound();
            }
            return View(tipoPlan);
        }

        // POST: TipoPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoPlan tipoPlan = _UnityOfWork.TipoPlan1.Get(id);
            _UnityOfWork.TipoPlan1.Delete(tipoPlan);
           _UnityOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
