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
    public class LineaTelefonicasController : Controller
    {
        //private _2014139821_DbContext db = new _2014139821_DbContext();
        public readonly IUnityOfWork _UnityOfWork;

        public LineaTelefonicasController()
        {

        }

        public LineaTelefonicasController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        // GET: LineaTelefonicas
        public ActionResult Index()
        {
            //var lineaTelefonicas = db.LineaTelefonicas.Include(l => l.AdministradorLinea).Include(l => l.Venta);
            //return View(lineaTelefonicas.ToList());
            return View(_UnityOfWork.LineaTelefonicas.GetAll());
        }

        // GET: LineaTelefonicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //LineaTelefonica lineaTelefonica = db.LineaTelefonicas.Find(id);
            LineaTelefonica lineaTelefonica = _UnityOfWork.LineaTelefonicas.Get(id);

            if (lineaTelefonica == null)
            {
                return HttpNotFound();
            }
            return View(lineaTelefonica);
        }

        // GET: LineaTelefonicas/Create
        public ActionResult Create()
        {
            //ViewBag.AdministradorLineaId = new SelectList(db.Administradorlineas, "AdministradorLineaId", "AdministradorLineaId");
            //ViewBag.LineaTelefonicaId = new SelectList(db.Ventas, "VentaId", "VentaId");
            return View();
        }

        // POST: LineaTelefonicas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LineaTelefonicaId,AdministradorLineaId,VentaId,EvaluacionId")] LineaTelefonica lineaTelefonica)
        {
            if (ModelState.IsValid)
            {
                //db.LineaTelefonicas.Add(lineaTelefonica);
                _UnityOfWork.LineaTelefonicas.Add(lineaTelefonica);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.AdministradorLineaId = new SelectList(db.Administradorlineas, "AdministradorLineaId", "AdministradorLineaId", lineaTelefonica.AdministradorLineaId);
            //ViewBag.LineaTelefonicaId = new SelectList(db.Ventas, "VentaId", "VentaId", lineaTelefonica.LineaTelefonicaId);
            return View(lineaTelefonica);
        }

        // GET: LineaTelefonicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //LineaTelefonica lineaTelefonica = db.LineaTelefonicas.Find(id);
            LineaTelefonica lineaTelefonica = _UnityOfWork.LineaTelefonicas.Get(id);
            if (lineaTelefonica == null)
            {
                return HttpNotFound();
            }
            //ViewBag.AdministradorLineaId = new SelectList(db.Administradorlineas, "AdministradorLineaId", "AdministradorLineaId", lineaTelefonica.AdministradorLineaId);
            //ViewBag.LineaTelefonicaId = new SelectList(db.Ventas, "VentaId", "VentaId", lineaTelefonica.LineaTelefonicaId);
            return View(lineaTelefonica);
        }

        // POST: LineaTelefonicas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LineaTelefonicaId,AdministradorLineaId,VentaId,EvaluacionId")] LineaTelefonica lineaTelefonica)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(lineaTelefonica).State = EntityState.Modified;
                _UnityOfWork.StateModified(lineaTelefonica);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.AdministradorLineaId = new SelectList(db.Administradorlineas, "AdministradorLineaId", "AdministradorLineaId", lineaTelefonica.AdministradorLineaId);
            //ViewBag.LineaTelefonicaId = new SelectList(db.Ventas, "VentaId", "VentaId", lineaTelefonica.LineaTelefonicaId);
            return View(lineaTelefonica);
        }

        // GET: LineaTelefonicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //LineaTelefonica lineaTelefonica = db.LineaTelefonicas.Find(id);
            LineaTelefonica lineaTelefonica = _UnityOfWork.LineaTelefonicas.Get(id);
            if (lineaTelefonica == null)
            {
                return HttpNotFound();
            }
            return View(lineaTelefonica);
        }

        // POST: LineaTelefonicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //LineaTelefonica lineaTelefonica = db.LineaTelefonicas.Find(id);
            LineaTelefonica lineaTelefonica = _UnityOfWork.LineaTelefonicas.Get(id);
            //db.LineaTelefonicas.Remove(lineaTelefonica);
            _UnityOfWork.LineaTelefonicas.Remove(lineaTelefonica);
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
