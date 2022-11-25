using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hikaya.Models;

namespace hikaya.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        HikayaContext db = new HikayaContext();
        public ActionResult display()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User u)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(u);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult logout()
        {
            Session["isAdmin"] = "false";
            Session["userid"] = null;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(User u)
        {
            User u1 = db.Users.Where(n => n.email == u.email && n.password == u.password).FirstOrDefault();
            Session["isAdmin"] = "false";
            if (u1 != null)
            {
                Admin a = db.Admins.Where(n => n.id == u1.id).FirstOrDefault();
                if (a != null)
                {
                    Session["isAdmin"] = "true";
                }
                Session["userid"] = u1.id;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult writer(int id)
        {
            List<Story> sts = db.Stories.Where(n => n.userid == id && n.isPublished==true).ToList();
            ViewBag.username = db.Users.Where(n => n.id == id).FirstOrDefault().name;
            return View(sts);
        }
    }
}