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
    public class UbigeosController : Controller
    {
        //private _2014139821_DbContext db = new _2014139821_DbContext();
        public readonly IUnityOfWork _UnityOfWork;

        public UbigeosController()
        {

        }

        public UbigeosController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        // GET: Ubigeos
        public ActionResult Index()
        {
            //var ubigeos = db.Ubigeos.Include(u => u.Direccion);
            //return View(ubigeos.ToList());
            return View(_UnityOfWork.Ubigeos.GetAll());
        }

        // GET: Ubigeos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Ubigeo ubigeo = db.Ubigeos.Find(id);
            Ubigeo ubigeo = _UnityOfWork.Ubigeos.Get(id);
            if (ubigeo == null)
            {
                return HttpNotFound();
            }
            return View(ubigeo);
        }

        // GET: Ubigeos/Create
        public ActionResult Create()
        {
            //ViewBag.UbigeoId = new SelectList(db.Direccions, "DireccionId", "DireccionId");
            return View();
        }

        // POST: Ubigeos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UbigeoId,DireccionId")] Ubigeo ubigeo)
        {
            if (ModelState.IsValid)
            {
                //db.Ubigeos.Add(ubigeo);
                _UnityOfWork.Ubigeos.Add(ubigeo);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.UbigeoId = new SelectList(db.Direccions, "DireccionId", "DireccionId", ubigeo.UbigeoId);
            return View(ubigeo);
        }

        // GET: Ubigeos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Ubigeo ubigeo = db.Ubigeos.Find(id);
            Ubigeo ubigeo = _UnityOfWork.Ubigeos.Get(id);
            if (ubigeo == null)
            {
                return HttpNotFound();
            }
            //ViewBag.UbigeoId = new SelectList(db.Direccions, "DireccionId", "DireccionId", ubigeo.UbigeoId);
            return View(ubigeo);
        }

        // POST: Ubigeos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UbigeoId,DireccionId")] Ubigeo ubigeo)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(ubigeo).State = EntityState.Modified;
                _UnityOfWork.StateModified(ubigeo);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.UbigeoId = new SelectList(db.Direccions, "DireccionId", "DireccionId", ubigeo.UbigeoId);
            return View(ubigeo);
        }

        // GET: Ubigeos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Ubigeo ubigeo = db.Ubigeos.Find(id);
            Ubigeo ubigeo = _UnityOfWork.Ubigeos.Get(id);
            if (ubigeo == null)
            {
                return HttpNotFound();
            }
            return View(ubigeo);
        }

        // POST: Ubigeos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Ubigeo ubigeo = db.Ubigeos.Find(id);
            Ubigeo ubigeo = _UnityOfWork.Ubigeos.Get(id);
            //db.Ubigeos.Remove(ubigeo);
            _UnityOfWork.Ubigeos.Remove(ubigeo);
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
