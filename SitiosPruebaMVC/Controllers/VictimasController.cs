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
    public class VictimasController : Controller
    {
        private SitiosPruebaDatabaseEntities db = new SitiosPruebaDatabaseEntities();

        // GET: Victimas
        public ActionResult Index()
        {
            var victimas = db.Victimas.Include(v => v.Sitio);
            return View(victimas.ToList());
        }

        // GET: Victimas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Victima victima = db.Victimas.Find(id);
            if (victima == null)
            {
                return HttpNotFound();
            }
            return View(victima);
        }

        // GET: Victimas/Create
        public ActionResult Create()
        {
            ViewBag.Id_Sitio = new SelectList(db.Sitios, "Id_Sitio", "CodigoSitio");
            return View();
        }

        // POST: Victimas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Victima,CodigoVictima,NA,Sexo,Edad,Procedencia,Familia,PresuntaAfiliacion,Id_Sitio")] Victima victima)
        {
            if (ModelState.IsValid)
            {
                db.Victimas.Add(victima);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Sitio = new SelectList(db.Sitios, "Id_Sitio", "CodigoSitio", victima.Id_Sitio);
            return View(victima);
        }

        // GET: Victimas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Victima victima = db.Victimas.Find(id);
            if (victima == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Sitio = new SelectList(db.Sitios, "Id_Sitio", "CodigoSitio", victima.Id_Sitio);
            return View(victima);
        }

        // POST: Victimas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Victima,CodigoVictima,NA,Sexo,Edad,Procedencia,Familia,PresuntaAfiliacion,Id_Sitio")] Victima victima)
        {
            if (ModelState.IsValid)
            {
                db.Entry(victima).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Sitio = new SelectList(db.Sitios, "Id_Sitio", "CodigoSitio", victima.Id_Sitio);
            return View(victima);
        }

        // GET: Victimas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Victima victima = db.Victimas.Find(id);
            if (victima == null)
            {
                return HttpNotFound();
            }
            return View(victima);
        }

        // POST: Victimas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Victima victima = db.Victimas.Find(id);
            db.Victimas.Remove(victima);
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
