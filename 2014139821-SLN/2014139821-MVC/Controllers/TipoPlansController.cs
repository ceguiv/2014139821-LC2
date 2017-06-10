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
    public class TipoPlansController : Controller
    {
        //private _2014139821_DbContext db = new _2014139821_DbContext();
        public readonly IUnityOfWork _UnityOfWork;

        public TipoPlansController()
        {

        }

        public TipoPlansController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        // GET: TipoPlans
        public ActionResult Index()
        {
            //return View(db.TipoPlans.ToList());
            return View(_UnityOfWork.TipoPlans.GetAll());

        }

        // GET: TipoPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TipoPlan tipoPlan = db.TipoPlans.Find(id);
            TipoPlan tipoPlan = _UnityOfWork.TipoPlans.Get(id);

            if (tipoPlan == null)
            {
                return HttpNotFound();
            }
            return View(tipoPlan);
        }

        // GET: TipoPlans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoPlans/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoPlanId")] TipoPlan tipoPlan)
        {
            if (ModelState.IsValid)
            {
                //db.TipoPlans.Add(tipoPlan);
                _UnityOfWork.TipoPlans.Add(tipoPlan);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoPlan);
        }

        // GET: TipoPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TipoPlan tipoPlan = db.TipoPlans.Find(id);
            TipoPlan tipoPlan = _UnityOfWork.TipoPlans.Get(id);
            if (tipoPlan == null)
            {
                return HttpNotFound();
            }
            return View(tipoPlan);
        }

        // POST: TipoPlans/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoPlanId")] TipoPlan tipoPlan)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(tipoPlan).State = EntityState.Modified;
                _UnityOfWork.StateModified(tipoPlan);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoPlan);
        }

        // GET: TipoPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TipoPlan tipoPlan = db.TipoPlans.Find(id);
            TipoPlan tipoPlan = _UnityOfWork.TipoPlans.Get(id);
            if (tipoPlan == null)
            {
                return HttpNotFound();
            }
            return View(tipoPlan);
        }

        // POST: TipoPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //TipoPlan tipoPlan = db.TipoPlans.Find(id);
            TipoPlan tipoPlan = _UnityOfWork.TipoPlans.Get(id);
            //db.TipoPlans.Remove(tipoPlan);
            _UnityOfWork.TipoPlans.Remove(tipoPlan);
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
