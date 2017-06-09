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
    public class EstadodeevaluacionsController : Controller
    {
        //  private _2015116292_DbContext db = new _2015116292_DbContext();
        private readonly IUnityOfWork _UnityOfWork;
        // GET: Estadodeevaluacions

        public EstadodeevaluacionsController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        public EstadodeevaluacionsController()
        {
                
        }


        public ActionResult Index()
        {
            return View(_UnityOfWork.Estadodeevaluacion1.GetAll());
        }

        // GET: Estadodeevaluacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estadodeevaluacion estadodeevaluacion = _UnityOfWork.Estadodeevaluacion1.Get(id);
            if (estadodeevaluacion == null)
            {
                return HttpNotFound();
            }
            return View(estadodeevaluacion);
        }

        // GET: Estadodeevaluacions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estadodeevaluacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Estadodeevaluacion_id,Estadodeevaluacion_estado")] Estadodeevaluacion estadodeevaluacion)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Estadodeevaluacion1.Add(estadodeevaluacion);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadodeevaluacion);
        }

        // GET: Estadodeevaluacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estadodeevaluacion estadodeevaluacion = _UnityOfWork.Estadodeevaluacion1.Get(id);
            if (estadodeevaluacion == null)
            {
                return HttpNotFound();
            }
            return View(estadodeevaluacion);
        }

        // POST: Estadodeevaluacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Estadodeevaluacion_id,Estadodeevaluacion_estado")] Estadodeevaluacion estadodeevaluacion)
        {
            if (ModelState.IsValid)
            {
                //_UnityOfWork.Entry(estadodeevaluacion).State = EntityState.Modified;
                _UnityOfWork.StateModified(estadodeevaluacion);

                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadodeevaluacion);
        }

        // GET: Estadodeevaluacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estadodeevaluacion estadodeevaluacion = _UnityOfWork.Estadodeevaluacion1.Get(id);
            if (estadodeevaluacion == null)
            {
                return HttpNotFound();
            }
            return View(estadodeevaluacion);
        }

        // POST: Estadodeevaluacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Estadodeevaluacion estadodeevaluacion = _UnityOfWork.Estadodeevaluacion1.Get(id);
            _UnityOfWork.Estadodeevaluacion1.Delete(estadodeevaluacion);
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
