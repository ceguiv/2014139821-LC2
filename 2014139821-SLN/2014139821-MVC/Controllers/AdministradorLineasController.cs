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
    public class AdministradorLineasController : Controller
    {
        //private _2014139821_DbContext db = new _2014139821_DbContext();
        //private UnityOfWork unityOfWork = UnityOfWork.Instance;
        public readonly IUnityOfWork _UnityOfWork;

        public AdministradorLineasController()
        {

        }

        public AdministradorLineasController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        // GET: AdministradorLineas
        public ActionResult Index()
        {
            //return View(db.Administradorlineas.ToList());
            return View(_UnityOfWork.AdministradorLineas.GetAll());
            
        }

        // GET: AdministradorLineas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //AdministradorLinea administradorLinea = db.Administradorlineas.Find(id);
            AdministradorLinea administradorLinea = _UnityOfWork.AdministradorLineas.Get(id);
            if (administradorLinea == null)
            {
                return HttpNotFound();
            }
            return View(administradorLinea);
        }

        // GET: AdministradorLineas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdministradorLineas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdministradorLineaId")] AdministradorLinea administradorLinea)
        {
            if (ModelState.IsValid)
            {
                //db.Administradorlineas.Add(administradorLinea);
                _UnityOfWork.AdministradorLineas.Add(administradorLinea);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(administradorLinea);
        }

        // GET: AdministradorLineas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //AdministradorLinea administradorLinea = db.Administradorlineas.Find(id);
            AdministradorLinea administradorLinea = _UnityOfWork.AdministradorLineas.Get(id);
            if (administradorLinea == null)
            {
                return HttpNotFound();
            }
            return View(administradorLinea);
        }

        // POST: AdministradorLineas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdministradorLineaId")] AdministradorLinea administradorLinea)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(administradorLinea).State = EntityState.Modified;
                _UnityOfWork.StateModified(administradorLinea);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(administradorLinea);
        }

        // GET: AdministradorLineas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //AdministradorLinea administradorLinea = db.Administradorlineas.Find(id);
            AdministradorLinea administradorLinea = _UnityOfWork.AdministradorLineas.Get(id);
            if (administradorLinea == null)
            {
                return HttpNotFound();
            }
            return View(administradorLinea);
        }

        // POST: AdministradorLineas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //AdministradorLinea administradorLinea = db.Administradorlineas.Find(id);
            AdministradorLinea administradorLinea = _UnityOfWork.AdministradorLineas.Get(id);
            //db.Administradorlineas.Remove(administradorLinea);
            _UnityOfWork.AdministradorLineas.Remove(administradorLinea);
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
