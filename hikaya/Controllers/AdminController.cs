using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hikaya.Models;
namespace hikaya.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        HikayaContext db = new HikayaContext();
        public ActionResult display()
        {
            List<Story> stories = db.Stories.Where(n => n.isPublished == false).ToList();
            return View(stories);
        }
        public ActionResult viewStory(int id)
        {
            Story s = db.Stories.Where(n => n.id == id).FirstOrDefault();
            List<StoryPlot> sts = db.StoryPlots.Where(n => n.storyid == id).ToList();
            List<User> users = db.Users.ToList();
            StoryAndPlots sp = new StoryAndPlots() { story = s, plots = sts };
            List<FeaturedMessage> msgs = db.FeaturedMessages.Where(n => n.storyid == id).ToList();
            ViewBag.msgs = msgs;
            ViewBag.users = users;
            Session["storyid"] = id;
            return View(sp);
        }
        [HttpPost]
        public ActionResult viewStory(string comment)
        {
            int userid = int.Parse(Session["userid"].ToString());
            int storyid = int.Parse(Session["storyid"].ToString());
            FeaturedMessage m = new FeaturedMessage();
            m.storyid = storyid;
            m.userid = userid;
            m.text = comment;
            db.FeaturedMessages.Add(m);
            db.SaveChanges();
            return RedirectToAction("viewStory","Admin",new { id=storyid });
        }
        
        public ActionResult approve(int id)
        {
            Story s = db.Stories.Where(n => n.id == id).FirstOrDefault();
            s.isPublished = true;
            db.SaveChanges();
            return RedirectToAction("display");
        }
        public ActionResult remove(int id)
        {
            Story s = db.Stories.Where(n => n.id == id).FirstOrDefault();
            db.Stories.Remove(s);
            db.SaveChanges();
            return RedirectToAction("display");
        }
    }
}