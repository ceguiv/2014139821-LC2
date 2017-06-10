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
    public class EquipoCelularsController : Controller
    {
        //private _2014139821_DbContext db = new _2014139821_DbContext();
        //private UnityOfWork unityOfWork = UnityOfWork.Instance;

        public readonly IUnityOfWork _UnityOfWork;

        public EquipoCelularsController()
        {

        }

        public EquipoCelularsController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        // GET: EquipoCelulars
        public ActionResult Index()
        {
            //var equipoCelulars = db.EquipoCelulars.Include(e => e.AdministradorEquipo);
            //return View(equipoCelulars.ToList());
            return View(_UnityOfWork.EquipoCelulars.GetAll());
        }

        // GET: EquipoCelulars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //EquipoCelular equipoCelular = db.EquipoCelulars.Find(id);
            EquipoCelular equipoCelular = _UnityOfWork.EquipoCelulars.Get(id);
            if (equipoCelular == null)
            {
                return HttpNotFound();
            }
            return View(equipoCelular);
        }

        // GET: EquipoCelulars/Create
        public ActionResult Create()
        {
            //ViewBag.AdministradorEquipoId = new SelectList(db.AdministradorEquipos, "AdministradorEquipoId", "AdministradorEquipoId");
            return View();
        }

        // POST: EquipoCelulars/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EquipoCelularId,AdministradorEquipoId,EvaluacionId")] EquipoCelular equipoCelular)
        {
            if (ModelState.IsValid)
            {
                //db.EquipoCelulars.Add(equipoCelular);
                _UnityOfWork.EquipoCelulars.Add(equipoCelular);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.AdministradorEquipoId = new SelectList(db.AdministradorEquipos, "AdministradorEquipoId", "AdministradorEquipoId", equipoCelular.AdministradorEquipoId);
            return View(equipoCelular);
        }

        // GET: EquipoCelulars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //EquipoCelular equipoCelular = db.EquipoCelulars.Find(id);
            EquipoCelular equipoCelular = _UnityOfWork.EquipoCelulars.Get(id);
            if (equipoCelular == null)
            {
                return HttpNotFound();
            }
            //ViewBag.AdministradorEquipoId = new SelectList(db.AdministradorEquipos, "AdministradorEquipoId", "AdministradorEquipoId", equipoCelular.AdministradorEquipoId);
            return View(equipoCelular);
        }

        // POST: EquipoCelulars/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EquipoCelularId,AdministradorEquipoId,EvaluacionId")] EquipoCelular equipoCelular)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(equipoCelular).State = EntityState.Modified;
                _UnityOfWork.StateModified(equipoCelular);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.AdministradorEquipoId = new SelectList(db.AdministradorEquipos, "AdministradorEquipoId", "AdministradorEquipoId", equipoCelular.AdministradorEquipoId);
            return View(equipoCelular);
        }

        // GET: EquipoCelulars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //EquipoCelular equipoCelular = db.EquipoCelulars.Find(id);
            EquipoCelular equipoCelular = _UnityOfWork.EquipoCelulars.Get(id);
            if (equipoCelular == null)
            {
                return HttpNotFound();
            }
            return View(equipoCelular);
        }

        // POST: EquipoCelulars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //EquipoCelular equipoCelular = db.EquipoCelulars.Find(id);
            EquipoCelular equipoCelular = _UnityOfWork.EquipoCelulars.Get(id);
            //db.EquipoCelulars.Remove(equipoCelular);
            _UnityOfWork.EquipoCelulars.Remove(equipoCelular);
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
