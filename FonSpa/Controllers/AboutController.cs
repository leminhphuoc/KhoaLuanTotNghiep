using FonNature.Services.IClientServices;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FonNature.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutServices _aboutServices;
        public AboutController(IAboutServices aboutServices)
        {
            _aboutServices = aboutServices;
        }
        // GET: About
        public ActionResult Index()
        {
            ViewBag.Tittle = "About";
            ViewBag.Staffs = _aboutServices.GetStaffs();
            var model = _aboutServices.GetAbouts();
            var seo = _aboutServices.GetSeo();
            if (seo != null)
            {
                ViewBag.MetaTitle = seo.MetaTitle ?? string.Empty;
                ViewBag.MetaDescription = seo.SeoDescription ?? string.Empty;
                ViewBag.MetaKeyword = seo.SeoKeyWord ?? string.Empty;
            }
            return View(model);
        }
    }
}