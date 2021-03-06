﻿using System;
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
    public class TipoLineasController : Controller
    {
        //private _2014139821_DbContext db = new _2014139821_DbContext();
        public readonly IUnityOfWork _UnityOfWork;

        public TipoLineasController()
        {

        }

        public TipoLineasController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        // GET: TipoLineas
        public ActionResult Index()
        {
            //return View(db.TipoLineas.ToList());
            return View(_UnityOfWork.TipoLineas.GetAll());

        }

        // GET: TipoLineas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TipoLinea tipoLinea = db.TipoLineas.Find(id);
            TipoLinea tipoLinea = _UnityOfWork.TipoLineas.Get(id);
            if (tipoLinea == null)
            {
                return HttpNotFound();
            }
            return View(tipoLinea);
        }

        // GET: TipoLineas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoLineas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoLineaId,LineaTelefonicaId")] TipoLinea tipoLinea)
        {
            if (ModelState.IsValid)
            {
                //db.TipoLineas.Add(tipoLinea);
                _UnityOfWork.TipoLineas.Add(tipoLinea);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoLinea);
        }

        // GET: TipoLineas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TipoLinea tipoLinea = db.TipoLineas.Find(id);
            TipoLinea tipoLinea = _UnityOfWork.TipoLineas.Get(id);
            if (tipoLinea == null)
            {
                return HttpNotFound();
            }
            return View(tipoLinea);
        }

        // POST: TipoLineas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoLineaId,LineaTelefonicaId")] TipoLinea tipoLinea)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(tipoLinea).State = EntityState.Modified;
                _UnityOfWork.StateModified(tipoLinea);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoLinea);
        }

        // GET: TipoLineas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TipoLinea tipoLinea = db.TipoLineas.Find(id);
            TipoLinea tipoLinea = _UnityOfWork.TipoLineas.Get(id);
            if (tipoLinea == null)
            {
                return HttpNotFound();
            }
            return View(tipoLinea);
        }

        // POST: TipoLineas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //TipoLinea tipoLinea = db.TipoLineas.Find(id);
            TipoLinea tipoLinea = _UnityOfWork.TipoLineas.Get(id);
            //db.TipoLineas.Remove(tipoLinea);
            _UnityOfWork.TipoLineas.Remove(tipoLinea);
            //db.SaveChanges();
            _UnityOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // db.Dispose();
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
