using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cotizacion.DAL;
using Cotizacion.Models;

namespace Cotizacion.Controllers
{
    public class MCotizacionsController : Controller
    {
        private CotizacionDB db = new CotizacionDB();

        // GET: MCotizacions
        public ActionResult Index()
        {
            var cotizacion = db.Cotizacion.Include(m => m.Cliente);
            return View(cotizacion.ToList());
        }

        // GET: MCotizacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MCotizacion mCotizacion = db.Cotizacion.Find(id);
            if (mCotizacion == null)
            {
                return HttpNotFound();
            }
            return View(mCotizacion);
        }

        // GET: MCotizacions/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nombre");
            return View();
        }

        // POST: MCotizacions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CotizacionId,Fecha,ClienteId")] MCotizacion mCotizacion)
        {
            if (ModelState.IsValid)
            {
                db.Cotizacion.Add(mCotizacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nombre", mCotizacion.ClienteId);
            return View(mCotizacion);
        }

        // GET: MCotizacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MCotizacion mCotizacion = db.Cotizacion.Find(id);
            if (mCotizacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nombre", mCotizacion.ClienteId);
            return View(mCotizacion);
        }

        // POST: MCotizacions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CotizacionId,Fecha,ClienteId")] MCotizacion mCotizacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mCotizacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nombre", mCotizacion.ClienteId);
            return View(mCotizacion);
        }

        // GET: MCotizacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MCotizacion mCotizacion = db.Cotizacion.Find(id);
            if (mCotizacion == null)
            {
                return HttpNotFound();
            }
            return View(mCotizacion);
        }

        // POST: MCotizacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MCotizacion mCotizacion = db.Cotizacion.Find(id);
            db.Cotizacion.Remove(mCotizacion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
