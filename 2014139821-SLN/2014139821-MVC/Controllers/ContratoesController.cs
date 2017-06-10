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
    public class ContratoesController : Controller
    {
        //private _2014139821_DbContext db = new _2014139821_DbContext();
        //private UnityOfWork unityOfWork = UnityOfWork.Instance;
        public readonly IUnityOfWork _UnityOfWork;

        public ContratoesController()
        {

        }

        public ContratoesController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        // GET: Contratoes
        public ActionResult Index()
        {
            //var contratos = db.Contratos.Include(c => c.Venta);
            //return View(contratos.ToList());
            return View(_UnityOfWork.Contratos.GetAll());
        }

        // GET: Contratoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Contrato contrato = db.Contratos.Find(id);
            Contrato contrato = _UnityOfWork.Contratos.Get(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // GET: Contratoes/Create
        public ActionResult Create()
        {
            //ViewBag.ContratoId = new SelectList(db.Ventas, "VentaId", "VentaId");
            return View();
        }

        // POST: Contratoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContratoId,VentaId")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                //db.Contratos.Add(contrato);
                _UnityOfWork.Contratos.Add(contrato);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.ContratoId = new SelectList(db.Ventas, "VentaId", "VentaId", contrato.ContratoId);
            return View(contrato);
        }

        // GET: Contratoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Contrato contrato = db.Contratos.Find(id);
            Contrato contrato = _UnityOfWork.Contratos.Get(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            //ViewBag.ContratoId = new SelectList(db.Ventas, "VentaId", "VentaId", contrato.ContratoId);
            return View(contrato);
        }

        // POST: Contratoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContratoId,VentaId")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(contrato).State = EntityState.Modified;
                _UnityOfWork.StateModified(contrato);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.ContratoId = new SelectList(db.Ventas, "VentaId", "VentaId", contrato.ContratoId);
            return View(contrato);
        }

        // GET: Contratoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Contrato contrato = db.Contratos.Find(id);
            Contrato contrato = _UnityOfWork.Contratos.Get(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // POST: Contratoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Contrato contrato = db.Contratos.Find(id);
            Contrato contrato = _UnityOfWork.Contratos.Get(id);
            //db.Contratos.Remove(contrato);
            _UnityOfWork.Contratos.Remove(contrato);
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
