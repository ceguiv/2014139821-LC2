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
    public class CentroAtencionsController : Controller
    {
        //private _2014139821_DbContext db = new _2014139821_DbContext();
        //private UnityOfWork unityOfWork = UnityOfWork.Instance;
        public readonly IUnityOfWork _UnityOfWork;

        public CentroAtencionsController()
        {

        }

        public CentroAtencionsController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        // GET: CentroAtencions
        public ActionResult Index()
        {
            //return View(db.CentroAtencions.ToList());
            return View(_UnityOfWork.CentroAtencions.GetAll());
        }

        // GET: CentroAtencions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //CentroAtencion centroAtencion = db.CentroAtencions.Find(id);
            CentroAtencion centroAtencion = _UnityOfWork.CentroAtencions.Get(id);
            if (centroAtencion == null)
            {
                return HttpNotFound();
            }
            return View(centroAtencion);
        }

        // GET: CentroAtencions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CentroAtencions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CentroAtencionId,DireccionId,EvaluacionId,VentaId")] CentroAtencion centroAtencion)
        {
            if (ModelState.IsValid)
            {
                //db.CentroAtencions.Add(centroAtencion);
                _UnityOfWork.CentroAtencions.Add(centroAtencion);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(centroAtencion);
        }

        // GET: CentroAtencions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //CentroAtencion centroAtencion = db.CentroAtencions.Find(id);
            CentroAtencion centroAtencion = _UnityOfWork.CentroAtencions.Get(id);
            if (centroAtencion == null)
            {
                return HttpNotFound();
            }
            return View(centroAtencion);
        }

        // POST: CentroAtencions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CentroAtencionId,DireccionId,EvaluacionId,VentaId")] CentroAtencion centroAtencion)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(centroAtencion).State = EntityState.Modified;
                _UnityOfWork.StateModified(centroAtencion);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(centroAtencion);
        }

        // GET: CentroAtencions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //CentroAtencion centroAtencion = db.CentroAtencions.Find(id);
            CentroAtencion centroAtencion = _UnityOfWork.CentroAtencions.Get(id);
            if (centroAtencion == null)
            {
                return HttpNotFound();
            }
            return View(centroAtencion);
        }

        // POST: CentroAtencions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //CentroAtencion centroAtencion = db.CentroAtencions.Find(id);
            CentroAtencion centroAtencion = _UnityOfWork.CentroAtencions.Get(id);
            //db.CentroAtencions.Remove(centroAtencion);
            _UnityOfWork.CentroAtencions.Remove(centroAtencion);
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
