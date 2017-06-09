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
    public class EquipocelularsController : Controller
    {
        //private _2015116292_DbContext db = new _2015116292_DbContext();
        private readonly IUnityOfWork _UnityOfWork;

        public EquipocelularsController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        public EquipocelularsController()
        {

        }

        // GET: Equipocelulars
        public ActionResult Index()
        {
            return View(_UnityOfWork.Equipocelular1.GetAll());
        }

        // GET: Equipocelulars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipocelular equipocelular = _UnityOfWork.Equipocelular1.Get(id);
            if (equipocelular == null)
            {
                return HttpNotFound();
            }
            return View(equipocelular);
        }

        // GET: Equipocelulars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Equipocelulars/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Equipocelular_id,Equipocelular_modelo")] Equipocelular equipocelular)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Equipocelular1.Add(equipocelular);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(equipocelular);
        }

        // GET: Equipocelulars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipocelular equipocelular = _UnityOfWork.Equipocelular1.Get(id);
            if (equipocelular == null)
            {
                return HttpNotFound();
            }
            return View(equipocelular);
        }

        // POST: Equipocelulars/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Equipocelular_id,Equipocelular_modelo")] Equipocelular equipocelular)
        {
            if (ModelState.IsValid)
            {
                //  _UnityOfWork.Entry(equipocelular).State = EntityState.Modified;
                _UnityOfWork.StateModified(equipocelular);

                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(equipocelular);
        }

        // GET: Equipocelulars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipocelular equipocelular = _UnityOfWork.Equipocelular1.Get(id);
            if (equipocelular == null)
            {
                return HttpNotFound();
            }
            return View(equipocelular);
        }

        // POST: Equipocelulars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Equipocelular equipocelular = _UnityOfWork.Equipocelular1.Get(id);
            _UnityOfWork.Equipocelular1.Delete(equipocelular);
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
