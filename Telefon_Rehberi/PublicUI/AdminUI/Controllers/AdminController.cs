using PublicUI.DBContext;
using PublicUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PublicUI.AdminUI.Controllers
{
    public class AdminController : Controller
    {
      
        // GET: Admin
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Admin a)
        {
            using (RehberDBContext db = new RehberDBContext())
            {
                var usr = (from k in db.Admin
                           where k.KullaniciAdi == a.KullaniciAdi &&
                           k.Sifre == a.Sifre
                           select k).SingleOrDefault();
                if (usr != null)
                {
                    
                    Session["KullaniciAdi"] = usr.KullaniciAdi.ToString();
                    return RedirectToAction("Index","Calisans");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış.");
                }
            }
            return View();
        }
        public ActionResult SifreGuncelle()
        {
            return View();
        }
    }
}