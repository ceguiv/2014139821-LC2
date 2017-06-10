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
using _2014139821_PER.Repositories;
using _2014139821_ENT.IRepositories;

namespace _2014139821_MVC.Controllers
{
    public class EstadoEvaluacionsController : Controller
    {
        //private _2014139821_DbContext db = new _2014139821_DbContext();
        //private UnityOfWork unityOfWork = UnityOfWork.Instance;
        public readonly IUnityOfWork _UnityOfWork;

        public EstadoEvaluacionsController()
        {

        }

        public EstadoEvaluacionsController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        // GET: EstadoEvaluacions
        public ActionResult Index()
        {
            //return View(db.EstadoEvaluacions.ToList());
            return View(_UnityOfWork.EstadoEvaluacions.GetAll());
        }

        // GET: EstadoEvaluacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //EstadoEvaluacion estadoEvaluacion = db.EstadoEvaluacions.Find(id);
            EstadoEvaluacion estadoEvaluacion = _UnityOfWork.EstadoEvaluacions.Get(id);
            if (estadoEvaluacion == null)
            {
                return HttpNotFound();
            }
            return View(estadoEvaluacion);
        }

        // GET: EstadoEvaluacions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoEvaluacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EstadoEvaluacionId,EvaluacionId")] EstadoEvaluacion estadoEvaluacion)
        {
            if (ModelState.IsValid)
            {
                //db.EstadoEvaluacions.Add(estadoEvaluacion);
                _UnityOfWork.EstadoEvaluacions.Add(estadoEvaluacion);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadoEvaluacion);
        }

        // GET: EstadoEvaluacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //EstadoEvaluacion estadoEvaluacion = db.EstadoEvaluacions.Find(id);
            EstadoEvaluacion estadoEvaluacion = _UnityOfWork.EstadoEvaluacions.Get(id);
            if (estadoEvaluacion == null)
            {
                return HttpNotFound();
            }
            return View(estadoEvaluacion);
        }

        // POST: EstadoEvaluacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstadoEvaluacionId,EvaluacionId")] EstadoEvaluacion estadoEvaluacion)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(estadoEvaluacion).State = EntityState.Modified;
                _UnityOfWork.StateModified(estadoEvaluacion);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadoEvaluacion);
        }

        // GET: EstadoEvaluacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //EstadoEvaluacion estadoEvaluacion = db.EstadoEvaluacions.Find(id);
            EstadoEvaluacion estadoEvaluacion = _UnityOfWork.EstadoEvaluacions.Get(id);
            if (estadoEvaluacion == null)
            {
                return HttpNotFound();
            }
            return View(estadoEvaluacion);
        }

        // POST: EstadoEvaluacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //EstadoEvaluacion estadoEvaluacion = db.EstadoEvaluacions.Find(id);
            EstadoEvaluacion estadoEvaluacion = _UnityOfWork.EstadoEvaluacions.Get(id);
            //db.EstadoEvaluacions.Remove(estadoEvaluacion);
            _UnityOfWork.EstadoEvaluacions.Remove(estadoEvaluacion);
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
