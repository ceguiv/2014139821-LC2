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
    public class EvaluacionsController : Controller
    {
        //private _2014139821_DbContext db = new _2014139821_DbContext();
        //private UnityOfWork unityOfWork = UnityOfWork.Instance;
        public readonly IUnityOfWork _UnityOfWork;

        public EvaluacionsController()
        {

        }

        public EvaluacionsController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        // GET: Evaluacions
        public ActionResult Index()
        {
            //var evaluacions = db.Evaluacions.Include(e => e.CentroAtencion).Include(e => e.Trabajador).Include(e => e.Venta);
            //return View(evaluacions.ToList());
            return View(_UnityOfWork.Evaluacions.GetAll());
        }

        // GET: Evaluacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Evaluacion evaluacion = db.Evaluacions.Find(id);
            Evaluacion evaluacion = _UnityOfWork.Evaluacions.Get(id);

            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            return View(evaluacion);
        }

        // GET: Evaluacions/Create
        public ActionResult Create()
        {
            //ViewBag.CentroAtencionId = new SelectList(db.CentroAtencions, "CentroAtencionId", "CentroAtencionId");
            //ViewBag.TrabajadorId = new SelectList(db.Trabajadors, "TrabajadorId", "TrabajadorId");
            //ViewBag.EvaluacionId = new SelectList(db.Ventas, "VentaId", "VentaId");
            return View();
        }

        // POST: Evaluacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EvaluacionId,VentaId,TrabajadorId,CentroAtencionId")] Evaluacion evaluacion)
        {
            if (ModelState.IsValid)
            {
                //db.Evaluacions.Add(evaluacion);
                _UnityOfWork.Evaluacions.Add(evaluacion);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.CentroAtencionId = new SelectList(db.CentroAtencions, "CentroAtencionId", "CentroAtencionId", evaluacion.CentroAtencionId);
            //ViewBag.TrabajadorId = new SelectList(db.Trabajadors, "TrabajadorId", "TrabajadorId", evaluacion.TrabajadorId);
            //ViewBag.EvaluacionId = new SelectList(db.Ventas, "VentaId", "VentaId", evaluacion.EvaluacionId);
            return View(evaluacion);
        }

        // GET: Evaluacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Evaluacion evaluacion = db.Evaluacions.Find(id);
            Evaluacion evaluacion = _UnityOfWork.Evaluacions.Get(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            //ViewBag.CentroAtencionId = new SelectList(db.CentroAtencions, "CentroAtencionId", "CentroAtencionId", evaluacion.CentroAtencionId);
            //ViewBag.TrabajadorId = new SelectList(db.Trabajadors, "TrabajadorId", "TrabajadorId", evaluacion.TrabajadorId);
            //ViewBag.EvaluacionId = new SelectList(db.Ventas, "VentaId", "VentaId", evaluacion.EvaluacionId);
            return View(evaluacion);
        }

        // POST: Evaluacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EvaluacionId,VentaId,TrabajadorId,CentroAtencionId")] Evaluacion evaluacion)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(evaluacion).State = EntityState.Modified;
                _UnityOfWork.StateModified(evaluacion);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.CentroAtencionId = new SelectList(db.CentroAtencions, "CentroAtencionId", "CentroAtencionId", evaluacion.CentroAtencionId);
            //ViewBag.TrabajadorId = new SelectList(db.Trabajadors, "TrabajadorId", "TrabajadorId", evaluacion.TrabajadorId);
            //ViewBag.EvaluacionId = new SelectList(db.Ventas, "VentaId", "VentaId", evaluacion.EvaluacionId);
            return View(evaluacion);
        }

        // GET: Evaluacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Evaluacion evaluacion = db.Evaluacions.Find(id);
            Evaluacion evaluacion = _UnityOfWork.Evaluacions.Get(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            return View(evaluacion);
        }

        // POST: Evaluacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Evaluacion evaluacion = db.Evaluacions.Find(id);
            Evaluacion evaluacion = _UnityOfWork.Evaluacions.Get(id);
            //db.Evaluacions.Remove(evaluacion);
            _UnityOfWork.Evaluacions.Remove(evaluacion);
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
