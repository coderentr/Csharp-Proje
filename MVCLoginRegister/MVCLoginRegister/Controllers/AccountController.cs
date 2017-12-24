using MVCLoginRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLoginRegister.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using(OurDbContext db=new OurDbContext())
            {
                return View(db.UserAccount.ToList());
            }
        }
        //Register
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if (ModelState.IsValid)
            {
                using(OurDbContext db=new OurDbContext())
                {
                    db.UserAccount.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.Ad + "  " + account.Soyad + "Kayıt Başarılı. ";
            }

            return View();
        }
        //Login



        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(UserAccount User)
        {
            using(OurDbContext db=new OurDbContext())
            {
                var usr = (from k in db.UserAccount
                           where k.KullaniciAdi == User.KullaniciAdi &&
                           k.Sifre == User.Sifre
                           select k).SingleOrDefault();
                if(usr!= null)
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["KullaniciAdi"] = usr.KullaniciAdi.ToString();
                    return RedirectToAction("GirisSayfasi");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış.");
                }
            }
            return View();
        }
        public ActionResult GirisSayfasi()
        {
            if (Session["UserID"]!= null)
            {
                   return View();
            }
            else
            {
              return   RedirectToAction("Giris");
            }
        }
    }
}