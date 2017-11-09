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
    public class TestigoesController : Controller
    {
        private SitiosPruebaDatabaseEntities db = new SitiosPruebaDatabaseEntities();

        // GET: Testigoes
        public ActionResult Index()
        {
            var testigos = db.Testigos.Include(t => t.Sitio);
            return View(testigos.ToList());
        }

        // GET: Testigoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Testigo testigo = db.Testigos.Find(id);
            if (testigo == null)
            {
                return HttpNotFound();
            }
            return View(testigo);
        }

        // GET: Testigoes/Create
        public ActionResult Create()
        {
            ViewBag.Id_Sitio = new SelectList(db.Sitios, "Id_Sitio", "CodigoSitio");
            return View();
        }

        // POST: Testigoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Testigo,Nombres,ApellidoPaterno,ApellidoMaterno,Id_Sitio")] Testigo testigo)
        {
            if (ModelState.IsValid)
            {
                db.Testigos.Add(testigo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Sitio = new SelectList(db.Sitios, "Id_Sitio", "CodigoSitio", testigo.Id_Sitio);
            return View(testigo);
        }

        // GET: Testigoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Testigo testigo = db.Testigos.Find(id);
            if (testigo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Sitio = new SelectList(db.Sitios, "Id_Sitio", "CodigoSitio", testigo.Id_Sitio);
            return View(testigo);
        }

        // POST: Testigoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Testigo,Nombres,ApellidoPaterno,ApellidoMaterno,Id_Sitio")] Testigo testigo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testigo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Sitio = new SelectList(db.Sitios, "Id_Sitio", "CodigoSitio", testigo.Id_Sitio);
            return View(testigo);
        }

        // GET: Testigoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Testigo testigo = db.Testigos.Find(id);
            if (testigo == null)
            {
                return HttpNotFound();
            }
            return View(testigo);
        }

        // POST: Testigoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Testigo testigo = db.Testigos.Find(id);
            db.Testigos.Remove(testigo);
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
