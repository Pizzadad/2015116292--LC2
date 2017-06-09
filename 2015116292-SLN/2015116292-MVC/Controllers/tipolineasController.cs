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
    public class tipolineasController : Controller
    {
        //private _2015116292_DbContext db = new _2015116292_DbContext();
        private readonly IUnityOfWork _UnityOfWork;

        public tipolineasController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        public tipolineasController()
        {
                
        }

        // GET: tipolineas
        public ActionResult Index()
        {
            return View(_UnityOfWork.tipolinea1.GetAll());
        }

        // GET: tipolineas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipolinea tipolinea = _UnityOfWork.tipolinea1.Get(id);
            if (tipolinea == null)
            {
                return HttpNotFound();
            }
            return View(tipolinea);
        }

        // GET: tipolineas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipolineas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tipolinea_id,tipolinea_nombre")] tipolinea tipolinea)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.tipolinea1.Add(tipolinea);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipolinea);
        }

        // GET: tipolineas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipolinea tipolinea = _UnityOfWork.tipolinea1.Get(id);
            if (tipolinea == null)
            {
                return HttpNotFound();
            }
            return View(tipolinea);
        }

        // POST: tipolineas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tipolinea_id,tipolinea_nombre")] tipolinea tipolinea)
        {
            if (ModelState.IsValid)
            {
                //_UnityOfWork.Entry(tipolinea).State = EntityState.Modified;
                _UnityOfWork.StateModified(tipolinea);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipolinea);
        }

        // GET: tipolineas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipolinea tipolinea = _UnityOfWork.tipolinea1.Get(id);
            if (tipolinea == null)
            {
                return HttpNotFound();
            }
            return View(tipolinea);
        }

        // POST: tipolineas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            tipolinea tipolinea = _UnityOfWork.tipolinea1.Get(id);
            _UnityOfWork.tipolinea1.Delete(tipolinea);
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
