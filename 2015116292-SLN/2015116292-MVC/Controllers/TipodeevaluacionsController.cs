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
    public class TipodeevaluacionsController : Controller
    {
       // private _2015116292_DbContext db = new _2015116292_DbContext();
        private readonly IUnityOfWork _UnityOfWork;
        // GET: Tipodeevaluacions

        public TipodeevaluacionsController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        public TipodeevaluacionsController()
        {

        }

        public ActionResult Index()
        {
            return View(_UnityOfWork.Tipodeevaluacion1.GetAll());
        }

        // GET: Tipodeevaluacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipodeevaluacion tipodeevaluacion = _UnityOfWork.Tipodeevaluacion1.Get(id);
            if (tipodeevaluacion == null)
            {
                return HttpNotFound();
            }
            return View(tipodeevaluacion);
        }

        // GET: Tipodeevaluacions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipodeevaluacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Tipodeevaluacion_id,Tipodeevaluacion_tipo")] Tipodeevaluacion tipodeevaluacion)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Tipodeevaluacion1.Add(tipodeevaluacion);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipodeevaluacion);
        }

        // GET: Tipodeevaluacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipodeevaluacion tipodeevaluacion = _UnityOfWork.Tipodeevaluacion1.Get(id);
            if (tipodeevaluacion == null)
            {
                return HttpNotFound();
            }
            return View(tipodeevaluacion);
        }

        // POST: Tipodeevaluacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Tipodeevaluacion_id,Tipodeevaluacion_tipo")] Tipodeevaluacion tipodeevaluacion)
        {
            if (ModelState.IsValid)
            {
                //     _UnityOfWork.Entry(tipodeevaluacion).State = EntityState.Modified;
                _UnityOfWork.StateModified(tipodeevaluacion);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipodeevaluacion);
        }

        // GET: Tipodeevaluacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipodeevaluacion tipodeevaluacion = _UnityOfWork.Tipodeevaluacion1.Get(id);
            if (tipodeevaluacion == null)
            {
                return HttpNotFound();
            }
            return View(tipodeevaluacion);
        }

        // POST: Tipodeevaluacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Tipodeevaluacion tipodeevaluacion = _UnityOfWork.Tipodeevaluacion1.Get(id);
            _UnityOfWork.Tipodeevaluacion1.Delete(tipodeevaluacion);
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
