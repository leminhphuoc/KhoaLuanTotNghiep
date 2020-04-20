using FonNature.Services.IClientServices;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FonNature.Controllers
{
    [RoutePrefix("about")]
    [Route("{action=AboutHome}")]
    public class AboutController : Controller
    {
        private readonly IAboutServices _aboutServices;
        public AboutController(IAboutServices aboutServices)
        {
            _aboutServices = aboutServices;
        }
        // GET: About
        public ActionResult AboutHome()
        {   
            ViewBag.Tittle = "About";
            var model = _aboutServices.GetAboutMain();
            var seo = _aboutServices.GetSeo();
            if (seo != null)
            {
                ViewBag.MetaTitle = seo.MetaTitle ?? string.Empty;
                ViewBag.MetaDescription = seo.MetaDescription ?? string.Empty;
                ViewBag.MetaKeyword = seo.MetaKeyWord ?? string.Empty;
            }
            return View(model);
        }

        public PartialViewResult AboutTeamList()
        {
            var model = _aboutServices.GetStaffs();
            return PartialView("AboutTeamList", model);
        }

        public PartialViewResult AboutTestimonial()
        {
            var model = _aboutServices.GetAboutsTestimonials();
            return PartialView("AboutTestimonial", model);
        }
    }
}