using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hikaya.Controllers
{
    public class PartialController : Controller
    {
        // GET: Partial
        public ActionResult search()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult search(string search)
        {
            return PartialView();
        }
    }
}