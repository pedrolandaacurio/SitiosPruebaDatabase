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
    public class InformantesController : Controller
    {
        private SitiosPruebaDatabaseEntities db = new SitiosPruebaDatabaseEntities();

        // GET: Informantes
        public ActionResult Index()
        {
            var informantes = db.Informantes.Include(i => i.Sitio);
            return View(informantes.ToList());
        }

        // GET: Informantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Informante informante = db.Informantes.Find(id);
            if (informante == null)
            {
                return HttpNotFound();
            }
            return View(informante);
        }

        // GET: Informantes/Create
        public ActionResult Create()
        {
            ViewBag.Id_Sitio = new SelectList(db.Sitios, "Id_Sitio", "CodigoSitio");
            return View();
        }

        // POST: Informantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Informante,Nombres,ApellidoPaterno,ApellidoMaterno,Id_Sitio")] Informante informante)
        {
            if (ModelState.IsValid)
            {
                db.Informantes.Add(informante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Sitio = new SelectList(db.Sitios, "Id_Sitio", "CodigoSitio", informante.Id_Sitio);
            return View(informante);
        }

        // GET: Informantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Informante informante = db.Informantes.Find(id);
            if (informante == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Sitio = new SelectList(db.Sitios, "Id_Sitio", "CodigoSitio", informante.Id_Sitio);
            return View(informante);
        }

        // POST: Informantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Informante,Nombres,ApellidoPaterno,ApellidoMaterno,Id_Sitio")] Informante informante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(informante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Sitio = new SelectList(db.Sitios, "Id_Sitio", "CodigoSitio", informante.Id_Sitio);
            return View(informante);
        }

        // GET: Informantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Informante informante = db.Informantes.Find(id);
            if (informante == null)
            {
                return HttpNotFound();
            }
            return View(informante);
        }

        // POST: Informantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Informante informante = db.Informantes.Find(id);
            db.Informantes.Remove(informante);
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
