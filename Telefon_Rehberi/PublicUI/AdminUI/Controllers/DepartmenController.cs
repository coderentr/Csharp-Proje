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
    public class DepartmenController : Controller
    {
        private RehberDBContext db = new RehberDBContext();

        // GET: Departmen
        public ActionResult Index()
        {
            return View(db.Departman.ToList());
        }

        // GET: Departmen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departman departman = db.Departman.Find(id);
            if (departman == null)
            {
                return HttpNotFound();
            }
            return View(departman);
        }

        // GET: Departmen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departmen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Adi")] Departman departman)
        {
            if (ModelState.IsValid)
            {
                db.Departman.Add(departman);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departman);
        }

        // GET: Departmen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departman departman = db.Departman.Find(id);
            if (departman == null)
            {
                return HttpNotFound();
            }
            return View(departman);
        }

        // POST: Departmen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Adi")] Departman departman)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departman).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departman);
        }

        // GET: Departmen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departman departman = db.Departman.Find(id);
            if (departman == null)
            {
                return HttpNotFound();
            }
            return View(departman);
        }

        // POST: Departmen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Departman departman = db.Departman.Find(id);
            if (departman.Calisanlar == null)
            {
                db.Departman.Remove(departman);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("ErrorDep");
            }
        }
        public ActionResult ErrorDep()
        {
            ViewBag.Message = "Çalışanı olan departman silinemez.";
            return View();
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
