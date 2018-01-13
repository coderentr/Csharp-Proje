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

namespace PublicUI.Controllers
{
    public class CalisanlarController : Controller
    {
        private RehberDBContext db = new RehberDBContext();

        // GET: Calisanlar
        public ActionResult Index()
        {
            var calisan = db.Calisan.Include(c => c.Departman).Include(c => c.Yonetici);
            return View(calisan.ToList());
        }

        // GET: Calisanlar/Details
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
