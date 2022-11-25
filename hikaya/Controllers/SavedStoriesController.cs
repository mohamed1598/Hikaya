using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hikaya.Models;
namespace hikaya.Controllers
{
    public class SavedStoriesController : Controller
    {
        // GET: SavedStories
        HikayaContext db = new HikayaContext();
        public ActionResult Index()
        {
            List<SavedStory> saveds = db.SavedStories.ToList();
            List<Story> stories = db.Stories.ToList();
            List<User> users = db.Users.ToList();
            List<Story> sts = new List<Story>();
            int userid = int.Parse(Session["userid"].ToString());
            foreach (var item in saveds)
            {
                Story s1 = stories.Where(n => n.id == item.storyid && item.userid==userid).FirstOrDefault();
                if (s1 != null)
                {
                    sts.Add(s1);
                }
                
            }
            ViewBag.users = users;
            return View(sts);
        }
        public ActionResult add(int id)
        {
            Story s = db.Stories.Where(n => n.id == id).FirstOrDefault();
            SavedStory ss = new SavedStory();
            ss.storyid = id;
            ss.userid = int.Parse(Session["userid"].ToString());
            db.SavedStories.Add(ss);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult unSave(int id)
        {
            Story s = db.Stories.Where(n => n.id == id).FirstOrDefault();
            int userid = int.Parse(Session["userid"].ToString());
            SavedStory ss = db.SavedStories.Where(n => n.userid == userid && n.storyid ==s.id ).FirstOrDefault();

            db.SavedStories.Remove(ss);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}