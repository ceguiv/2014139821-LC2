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
    public class TipoPagoesController : Controller
    {
        //private _2014139821_DbContext db = new _2014139821_DbContext();
        public readonly IUnityOfWork _UnityOfWork;

        public TipoPagoesController()
        {

        }

        public TipoPagoesController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        // GET: TipoPagoes
        public ActionResult Index()
        {
            //return View(db.TipoPagos.ToList());
            return View(_UnityOfWork.TipoPagos.GetAll());
        }

        // GET: TipoPagoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TipoPago tipoPago = db.TipoPagos.Find(id);
            TipoPago tipoPago = _UnityOfWork.TipoPagos.Get(id);
            if (tipoPago == null)
            {
                return HttpNotFound();
            }
            return View(tipoPago);
        }

        // GET: TipoPagoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoPagoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoPagoId,VentaId")] TipoPago tipoPago)
        {
            if (ModelState.IsValid)
            {
                //db.TipoPagos.Add(tipoPago);
                _UnityOfWork.TipoPagos.Add(tipoPago);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoPago);
        }

        // GET: TipoPagoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TipoPago tipoPago = db.TipoPagos.Find(id);
            TipoPago tipoPago = _UnityOfWork.TipoPagos.Get(id);
            if (tipoPago == null)
            {
                return HttpNotFound();
            }
            return View(tipoPago);
        }

        // POST: TipoPagoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoPagoId,VentaId")] TipoPago tipoPago)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(tipoPago).State = EntityState.Modified;
                _UnityOfWork.StateModified(tipoPago);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoPago);
        }

        // GET: TipoPagoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TipoPago tipoPago = db.TipoPagos.Find(id);
            TipoPago tipoPago = _UnityOfWork.TipoPagos.Get(id);
            if (tipoPago == null)
            {
                return HttpNotFound();
            }
            return View(tipoPago);
        }

        // POST: TipoPagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //TipoPago tipoPago = db.TipoPagos.Find(id);
            TipoPago tipoPago = _UnityOfWork.TipoPagos.Get(id);
            //db.TipoPagos.Remove(tipoPago);
            _UnityOfWork.TipoPagos.Remove(tipoPago);

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
