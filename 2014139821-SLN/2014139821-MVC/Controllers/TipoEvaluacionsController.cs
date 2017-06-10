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
    public class TipoEvaluacionsController : Controller
    {
        //private _2014139821_DbContext db = new _2014139821_DbContext();
        public readonly IUnityOfWork _UnityOfWork;

        public TipoEvaluacionsController()
        {

        }

        public TipoEvaluacionsController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        // GET: TipoEvaluacions
        public ActionResult Index()
        {
            //return View(db.TipoEvaluacions.ToList());
            return View(_UnityOfWork.TipoEvaluacions.GetAll());
        }

        // GET: TipoEvaluacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TipoEvaluacion tipoEvaluacion = db.TipoEvaluacions.Find(id);
            TipoEvaluacion tipoEvaluacion = _UnityOfWork.TipoEvaluacions.Get(id);
            if (tipoEvaluacion == null)
            {
                return HttpNotFound();
            }
            return View(tipoEvaluacion);
        }

        // GET: TipoEvaluacions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoEvaluacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoEvaluacionId,EvaluacionId")] TipoEvaluacion tipoEvaluacion)
        {
            if (ModelState.IsValid)
            {
                //db.TipoEvaluacions.Add(tipoEvaluacion);
                _UnityOfWork.TipoEvaluacions.Add(tipoEvaluacion);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoEvaluacion);
        }

        // GET: TipoEvaluacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TipoEvaluacion tipoEvaluacion = db.TipoEvaluacions.Find(id);
            TipoEvaluacion tipoEvaluacion = _UnityOfWork.TipoEvaluacions.Get(id);
            if (tipoEvaluacion == null)
            {
                return HttpNotFound();
            }
            return View(tipoEvaluacion);
        }

        // POST: TipoEvaluacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoEvaluacionId,EvaluacionId")] TipoEvaluacion tipoEvaluacion)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(tipoEvaluacion).State = EntityState.Modified;
                _UnityOfWork.StateModified(tipoEvaluacion);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoEvaluacion);
        }

        // GET: TipoEvaluacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TipoEvaluacion tipoEvaluacion = db.TipoEvaluacions.Find(id);
            TipoEvaluacion tipoEvaluacion = _UnityOfWork.TipoEvaluacions.Get(id);
            if (tipoEvaluacion == null)
            {
                return HttpNotFound();
            }
            return View(tipoEvaluacion);
        }

        // POST: TipoEvaluacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //TipoEvaluacion tipoEvaluacion = db.TipoEvaluacions.Find(id);
            TipoEvaluacion tipoEvaluacion = _UnityOfWork.TipoEvaluacions.Get(id);
            //db.TipoEvaluacions.Remove(tipoEvaluacion);
            _UnityOfWork.TipoEvaluacions.Remove(tipoEvaluacion);
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
