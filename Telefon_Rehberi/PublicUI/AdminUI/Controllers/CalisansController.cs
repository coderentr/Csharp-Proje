using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PublicUI.DBContext;
using PublicUI.Models;

namespace PublicUI.AdminUI.Controllers
{
    public class CalisansController : Controller
    {
        private RehberDBContext db = new RehberDBContext();

        // GET: Calisans
        public ActionResult Index()
        {
            var calisan = db.Calisan.Include(c => c.Departman).Include(c => c.Yonetici);
            return View(calisan.ToList());
        }

        // GET: Calisans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calisan calisan = db.Calisan.Find(id);
            if (calisan == null)
            {
                return HttpNotFound();
            }
            return View(calisan);
        }

        // GET: Calisans/Create
        public ActionResult Create()
        {
            ViewBag.DepartmanID = new SelectList(db.Departman, "ID", "Adi");
            ViewBag.YoneticiID = new SelectList(db.Yonetici, "YoneticiID", "AdSoyad");
            return View();
        }

        // POST: Calisans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ad,Soyad,Telefon,DepartmanID,YoneticiID")] Calisan calisan)
        {
            if (ModelState.IsValid)
            {
                db.Calisan.Add(calisan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmanID = new SelectList(db.Departman, "ID", "Adi", calisan.DepartmanID);
            ViewBag.YoneticiID = new SelectList(db.Yonetici, "YoneticiID", "AdSoyad", calisan.YoneticiID);
            return View(calisan);
        }

        // GET: Calisans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calisan calisan = db.Calisan.Find(id);
            if (calisan == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmanID = new SelectList(db.Departman, "ID", "Adi", calisan.DepartmanID);
            ViewBag.YoneticiID = new SelectList(db.Yonetici, "YoneticiID", "AdSoyad", calisan.YoneticiID);
            return View(calisan);
        }

        // POST: Calisans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ad,Soyad,Telefon,DepartmanID,YoneticiID")] Calisan calisan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calisan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmanID = new SelectList(db.Departman, "ID", "Adi", calisan.DepartmanID);
            ViewBag.YoneticiID = new SelectList(db.Yonetici, "YoneticiID", "AdSoyad", calisan.YoneticiID);
            return View(calisan);
        }

        // GET: Calisans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calisan calisan = db.Calisan.Find(id);
            if (calisan == null)
            {
                return HttpNotFound();
            }
            return View(calisan);
        }

        // POST: Calisans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Calisan calisan = db.Calisan.Find(id);
            db.Calisan.Remove(calisan);
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
