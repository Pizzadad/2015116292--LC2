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
using _2015116292_PER.Repositories;
using _2015116292_ENT.IRepositories;

namespace _2015116292_MVC.Controllers
{
    public class AdmiLineasController : Controller
    {
        //private _2015116292_DbContext db = new _2015116292_DbContext();
        private readonly IUnityOfWork _UnityOfWork;

        public AdmiLineasController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }


        public AdmiLineasController()
        {

        }
        
        // GET: AdmiLineas
        public ActionResult Index()
        {
            //return View(unityOfWork.AdmiLinea1.GetAll());
            return View(_UnityOfWork.AdmiLinea1.GetAll());

           
        }

        // GET: AdmiLineas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdmiLinea admiLinea = _UnityOfWork.AdmiLinea1.Get(id);
            if (admiLinea == null)
            {
                return HttpNotFound();
            }
            return View(admiLinea);
        }

        // GET: AdmiLineas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdmiLineas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "admilinea_id,admilinea_nombre")] AdmiLinea admiLinea)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.AdmiLinea1.Add(admiLinea);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admiLinea);
        }

        // GET: AdmiLineas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdmiLinea admiLinea = _UnityOfWork.AdmiLinea1.Get(id);
            if (admiLinea == null)
            {
                return HttpNotFound();
            }
            return View(admiLinea);
        }

        // POST: AdmiLineas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "admilinea_id,admilinea_nombre")] AdmiLinea admiLinea)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(admiLinea).State = EntityState.Modified;
                _UnityOfWork.StateModified(admiLinea);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admiLinea);
        }

        // GET: AdmiLineas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdmiLinea admiLinea = _UnityOfWork.AdmiLinea1.Get(id);
            if (admiLinea == null)
            {
                return HttpNotFound();
            }
            return View(admiLinea);
        }

        // POST: AdmiLineas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AdmiLinea admiLinea = _UnityOfWork.AdmiLinea1.Get(id);
            _UnityOfWork.AdmiLinea1.Delete(admiLinea);
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
