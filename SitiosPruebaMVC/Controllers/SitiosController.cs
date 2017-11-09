using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SitiosPruebaMVC.Models;

namespace SitiosPruebaMVC.Controllers
{
    public class SitiosController : Controller
    {
        private SitiosPruebaDatabaseEntities db = new SitiosPruebaDatabaseEntities();

        // GET: Sitios
        public ActionResult Index()
        {
            return View(db.Sitios.ToList());
        }

        // GET: Sitios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sitio sitio = db.Sitios.Find(id);
            if (sitio == null)
            {
                return HttpNotFound();
            }
            return View(sitio);
        }

        // GET: Sitios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sitios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Sitio,CodigoSitio,Ubicacion,Propiedad,Antecedentes,RelatoAcontecimientos,FechaEvento,FechaInhumacion,NumeroVictimas,ExhumacionAnterior,MaterialesAdicionales")] Sitio sitio)
        {
            if (ModelState.IsValid)
            {
                db.Sitios.Add(sitio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sitio);
        }

        // GET: Sitios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sitio sitio = db.Sitios.Find(id);
            if (sitio == null)
            {
                return HttpNotFound();
            }
            return View(sitio);
        }

        // POST: Sitios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Sitio,CodigoSitio,Ubicacion,Propiedad,Antecedentes,RelatoAcontecimientos,FechaEvento,FechaInhumacion,NumeroVictimas,ExhumacionAnterior,MaterialesAdicionales")] Sitio sitio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sitio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sitio);
        }

        // GET: Sitios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sitio sitio = db.Sitios.Find(id);
            if (sitio == null)
            {
                return HttpNotFound();
            }
            return View(sitio);
        }

        // POST: Sitios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sitio sitio = db.Sitios.Find(id);
            db.Sitios.Remove(sitio);
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
