using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FonNature.Controllers
{
    public class DefaultController : Controller
    {
        [Route("{pageUrl}")]
        // GET: Default
        public ActionResult Index(string pageUrl)
        {
            ViewBag.Url = pageUrl;
            return View();
        }
    }
}