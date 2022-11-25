using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hikaya.Models;

namespace hikaya.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        
        HikayaContext db = new HikayaContext();
        
        public ActionResult Index()
        {
            List < Story > stories = db.Stories.Where(n => n.isPublished == true).ToList();
            List<User> users = db.Users.ToList();
            stories.Reverse();
            ViewBag.users = users;
            return View(stories);
        }
        [HttpPost]
        public ActionResult Search(searched s)
        {
            string search = s.searchMessage;
            List<string> srch = search.Split(' ').ToList();
            return View(srch);
        }
    }
}