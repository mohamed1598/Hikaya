using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hikaya.Models;
namespace hikaya.Controllers
{
    public class StoryController : Controller
    {
        // GET: Story
        HikayaContext db = new HikayaContext();
        public ActionResult display()
        {
            List<Story> sts;
            int? userid = (int)Session["userid"];
            sts = db.Stories.Where(n => n.userid == userid).ToList();
            return View(sts);
        }
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(Story s)
        {
            s.userid = (int)Session["userid"];
            s.isPublished = false;
            db.Stories.Add(s);
            db.SaveChanges();
            return RedirectToAction("display");
        }
        public ActionResult addPlot(int id)
        {
            Session["storyid"] = id;
            return View();
        }
        [HttpPost]
        public ActionResult addPlot(StoryPlot s,HttpPostedFileBase photo)
        {
            s.storyid = (int)Session["storyid"];
            if(photo != null)
            {
                s.imageUrl = photo.FileName;
                photo.SaveAs(Server.MapPath("~/attached/" + photo.FileName));
            }
            db.StoryPlots.Add(s);
            db.SaveChanges();
            return RedirectToAction("display");
        }
        public ActionResult viewStory(int id)
        {            
            Story s = db.Stories.Where(n => n.id == id).FirstOrDefault();
            List<StoryPlot> sts = db.StoryPlots.Where(n => n.storyid == id).ToList();
            List<FeaturedMessage> msgs = db.FeaturedMessages.Where(n => n.storyid == id).ToList();
            ViewBag.msgs = msgs;
            StoryAndPlots sp = new StoryAndPlots() { story = s, plots = sts };
            return View(sp);
        }
        public ActionResult removeStory(int id)
        {
            Story s = db.Stories.Where(n => n.id == id).FirstOrDefault();
            db.Stories.Remove(s);
            db.SaveChanges();
            return RedirectToAction("display");
        }
        public ActionResult editPlot(int id)
        {
            StoryPlot sp = db.StoryPlots.Where(n => n.id == id).FirstOrDefault();
            Session["storyid"] = sp.storyid;
            Session["plotImage"] = sp.imageUrl;
            return View(sp);
        }
        [HttpPost]
        public ActionResult editPlot(StoryPlot s, HttpPostedFileBase photo)
        {
            s.storyid = (int)Session["storyid"];
            if (photo != null)
            {
                s.imageUrl = photo.FileName;
                photo.SaveAs(Server.MapPath("~/attached/" + photo.FileName));
            }
            else
            {
                s.imageUrl = Session["plotImage"].ToString();
            }
            db.Entry(s).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("display");
        }
    }
}