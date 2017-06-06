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
    public class DetalleCotizacionsController : Controller
    {
        private CotizacionDB db = new CotizacionDB();

        // GET: DetalleCotizacions
        public ActionResult Index()
        {
            var detalleCotizacion = db.DetalleCotizacion.Include(d => d.Cotizacion).Include(d => d.Producto);
            return View(detalleCotizacion.ToList());
        }

        // GET: DetalleCotizacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleCotizacion detalleCotizacion = db.DetalleCotizacion.Find(id);
            if (detalleCotizacion == null)
            {
                return HttpNotFound();
            }
            return View(detalleCotizacion);
        }

        // GET: DetalleCotizacions/Create
        public ActionResult Create()
        {
            ViewBag.CotizacionId = new SelectList(db.Cotizacion, "CotizacionId", "CotizacionId");
            ViewBag.ProductoId = new SelectList(db.Producto, "ProductoId", "Nombre");
            return View();
        }

        // POST: DetalleCotizacions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DetalleCotizacionId,CotizacionId,ProductoId,Cantidad")] DetalleCotizacion detalleCotizacion)
        {
            if (ModelState.IsValid)
            {
                db.DetalleCotizacion.Add(detalleCotizacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CotizacionId = new SelectList(db.Cotizacion, "CotizacionId", "CotizacionId", detalleCotizacion.CotizacionId);
            ViewBag.ProductoId = new SelectList(db.Producto, "ProductoId", "Nombre", detalleCotizacion.ProductoId);
            return View(detalleCotizacion);
        }

        // GET: DetalleCotizacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleCotizacion detalleCotizacion = db.DetalleCotizacion.Find(id);
            if (detalleCotizacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.CotizacionId = new SelectList(db.Cotizacion, "CotizacionId", "CotizacionId", detalleCotizacion.CotizacionId);
            ViewBag.ProductoId = new SelectList(db.Producto, "ProductoId", "Nombre", detalleCotizacion.ProductoId);
            return View(detalleCotizacion);
        }

        // POST: DetalleCotizacions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DetalleCotizacionId,CotizacionId,ProductoId,Cantidad")] DetalleCotizacion detalleCotizacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleCotizacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CotizacionId = new SelectList(db.Cotizacion, "CotizacionId", "CotizacionId", detalleCotizacion.CotizacionId);
            ViewBag.ProductoId = new SelectList(db.Producto, "ProductoId", "Nombre", detalleCotizacion.ProductoId);
            return View(detalleCotizacion);
        }

        // GET: DetalleCotizacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleCotizacion detalleCotizacion = db.DetalleCotizacion.Find(id);
            if (detalleCotizacion == null)
            {
                return HttpNotFound();
            }
            return View(detalleCotizacion);
        }

        // POST: DetalleCotizacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleCotizacion detalleCotizacion = db.DetalleCotizacion.Find(id);
            db.DetalleCotizacion.Remove(detalleCotizacion);
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
