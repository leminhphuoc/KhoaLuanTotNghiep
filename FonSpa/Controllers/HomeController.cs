using FonNature.Filter;
using FonNature.Services.IClientServices;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FonNature.Controllers
{
    [CountVisitor]
    public class HomeController : Controller
    {
        private readonly IHomeServices _homeServices;

        public HomeController(IHomeServices homeServices)
        {
            _homeServices = homeServices;
        }

        public ActionResult Home()
        {
            ViewBag.Title = "Home Page";
            ViewBag.SlideList = _homeServices.ListSlide();
            var seo = _homeServices.GetHomeSeo();
            ViewBag.featuredProduct = _homeServices.GetFeaturedProducts();
            ViewBag.topHotProduct = _homeServices.GetTopHot();
            ViewBag.bestSellerProduct = _homeServices.GetBestSellerProducts();
            if (seo != null)
            {
                ViewBag.MetaTitle = seo.MetaTitle ?? string.Empty;
                ViewBag.MetaDescription = seo.MetaDescription ?? string.Empty;
                ViewBag.MetaKeyword = seo.MetaKeyWord ?? string.Empty;
            }
            return View();
        }

        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            ViewBag.BlogCategories = _homeServices.ListContentCategory();
            ViewBag.ProductsCategories = _homeServices.ListProductCategories();
            var menus = _homeServices.ListMenu();
            return PartialView(menus);
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            ViewBag.FooterCategories = _homeServices.ListFooterCategory();
            var footers = _homeServices.ListFooter();
            return PartialView(footers);
        }
    }
}
