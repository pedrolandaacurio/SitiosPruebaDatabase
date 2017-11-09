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
    public class FamiliaresController : Controller
    {
        private SitiosPruebaDatabaseEntities db = new SitiosPruebaDatabaseEntities();

        // GET: Familiares
        public ActionResult Index()
        {
            var familiares = db.Familiares.Include(f => f.Victima);
            return View(familiares.ToList());
        }

        // GET: Familiares/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Familiare familiare = db.Familiares.Find(id);
            if (familiare == null)
            {
                return HttpNotFound();
            }
            return View(familiare);
        }

        // GET: Familiares/Create
        public ActionResult Create()
        {
            ViewBag.Id_Victima = new SelectList(db.Victimas, "Id_Victima", "CodigoVictima");
            return View();
        }

        // POST: Familiares/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Familiar,Familiar,Id_Victima")] Familiare familiare)
        {
            if (ModelState.IsValid)
            {
                db.Familiares.Add(familiare);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Victima = new SelectList(db.Victimas, "Id_Victima", "CodigoVictima", familiare.Id_Victima);
            return View(familiare);
        }

        // GET: Familiares/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Familiare familiare = db.Familiares.Find(id);
            if (familiare == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Victima = new SelectList(db.Victimas, "Id_Victima", "CodigoVictima", familiare.Id_Victima);
            return View(familiare);
        }

        // POST: Familiares/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Familiar,Familiar,Id_Victima")] Familiare familiare)
        {
            if (ModelState.IsValid)
            {
                db.Entry(familiare).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Victima = new SelectList(db.Victimas, "Id_Victima", "CodigoVictima", familiare.Id_Victima);
            return View(familiare);
        }

        // GET: Familiares/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Familiare familiare = db.Familiares.Find(id);
            if (familiare == null)
            {
                return HttpNotFound();
            }
            return View(familiare);
        }

        // POST: Familiares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Familiare familiare = db.Familiares.Find(id);
            db.Familiares.Remove(familiare);
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
