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
    public class DireccionsController : Controller
    {
        //private _2014139821_DbContext db = new _2014139821_DbContext();
        //private UnityOfWork unityOfWork = UnityOfWork.Instance;

        public readonly IUnityOfWork _UnityOfWork;

        public DireccionsController()
        {

        }

        public DireccionsController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        // GET: Direccions
        public ActionResult Index()
        {
            //var direccions = db.Direccions.Include(d => d.CentroAtencion);
            //return View(direccions.ToList());
            return View(_UnityOfWork.Direccions.GetAll());
        }

        // GET: Direccions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Direccion direccion = db.Direccions.Find(id);
            Direccion direccion = _UnityOfWork.Direccions.Get(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // GET: Direccions/Create
        public ActionResult Create()
        {
            //ViewBag.DireccionId = new SelectList(db.CentroAtencions, "CentroAtencionId", "CentroAtencionId");
            return View();
        }

        // POST: Direccions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DireccionId,CentroAtencionId")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                //db.Direccions.Add(direccion);
                _UnityOfWork.Direccions.Add(direccion);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.DireccionId = new SelectList(db.CentroAtencions, "CentroAtencionId", "CentroAtencionId", direccion.DireccionId);
            return View(direccion);
        }

        // GET: Direccions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Direccion direccion = db.Direccions.Find(id);
            Direccion direccion = _UnityOfWork.Direccions.Get(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            //ViewBag.DireccionId = new SelectList(db.CentroAtencions, "CentroAtencionId", "CentroAtencionId", direccion.DireccionId);
            return View(direccion);
        }

        // POST: Direccions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DireccionId,CentroAtencionId")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(direccion).State = EntityState.Modified;
                _UnityOfWork.StateModified(direccion);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.DireccionId = new SelectList(db.CentroAtencions, "CentroAtencionId", "CentroAtencionId", direccion.DireccionId);
            return View(direccion);
        }

        // GET: Direccions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Direccion direccion = db.Direccions.Find(id);
            Direccion direccion = _UnityOfWork.Direccions.Get(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // POST: Direccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Direccion direccion = db.Direccions.Find(id);
            Direccion direccion = _UnityOfWork.Direccions.Get(id);
            //db.Direccions.Remove(direccion);
            _UnityOfWork.Direccions.Remove(direccion);
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
