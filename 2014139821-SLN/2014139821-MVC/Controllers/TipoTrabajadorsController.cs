using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _2014139821_ENT;
using _2014139821_PER;
using _2014139821_ENT.IRepositories;

namespace _2014139821_MVC.Controllers
{
    public class TipoTrabajadorsController : Controller
    {
        //private _2014139821_DbContext db = new _2014139821_DbContext();
        public readonly IUnityOfWork _UnityOfWork;

        public TipoTrabajadorsController()
        {

        }

        public TipoTrabajadorsController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        // GET: TipoTrabajadors
        public ActionResult Index()
        {
            //return View(db.TipoTrabajadors.ToList());
            return View(_UnityOfWork.TipoTrabajadors.GetAll());
        }

        // GET: TipoTrabajadors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TipoTrabajador tipoTrabajador = db.TipoTrabajadors.Find(id);
            TipoTrabajador tipoTrabajador = _UnityOfWork.TipoTrabajadors.Get(id);
            if (tipoTrabajador == null)
            {
                return HttpNotFound();
            }
            return View(tipoTrabajador);
        }

        // GET: TipoTrabajadors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoTrabajadors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoTrabajadorId,TrabajadorId")] TipoTrabajador tipoTrabajador)
        {
            if (ModelState.IsValid)
            {
                //db.TipoTrabajadors.Add(tipoTrabajador);
                _UnityOfWork.TipoTrabajadors.Add(tipoTrabajador);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoTrabajador);
        }

        // GET: TipoTrabajadors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TipoTrabajador tipoTrabajador = db.TipoTrabajadors.Find(id);
            TipoTrabajador tipoTrabajador = _UnityOfWork.TipoTrabajadors.Get(id);
            if (tipoTrabajador == null)
            {
                return HttpNotFound();
            }
            return View(tipoTrabajador);
        }

        // POST: TipoTrabajadors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoTrabajadorId,TrabajadorId")] TipoTrabajador tipoTrabajador)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(tipoTrabajador).State = EntityState.Modified;
                _UnityOfWork.StateModified(tipoTrabajador);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoTrabajador);
        }

        // GET: TipoTrabajadors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TipoTrabajador tipoTrabajador = db.TipoTrabajadors.Find(id);
            TipoTrabajador tipoTrabajador = _UnityOfWork.TipoTrabajadors.Get(id);
            if (tipoTrabajador == null)
            {
                return HttpNotFound();
            }
            return View(tipoTrabajador);
        }

        // POST: TipoTrabajadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //TipoTrabajador tipoTrabajador = db.TipoTrabajadors.Find(id);
            TipoTrabajador tipoTrabajador = _UnityOfWork.TipoTrabajadors.Get(id);
            //db.TipoTrabajadors.Remove(tipoTrabajador);
            _UnityOfWork.TipoTrabajadors.Remove(tipoTrabajador);
            //db.SaveChanges();
            _UnityOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
