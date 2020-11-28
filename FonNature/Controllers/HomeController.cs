using FonNature.Filter;
using FonNature.Services;
using Models.Entity;
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
            ViewBag.otherSlide = _homeServices.GetOtherSlide();
            ViewBag.contentList = _homeServices.GetHomeContent();
            ViewBag.bannerHome = _homeServices.GetBannerHome();
            ViewBag.aboutUs = _homeServices.GetAboutUs();
            ViewBag.benefits = _homeServices.GetBenefits();
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
            ViewBag.ServiceCategories = _homeServices.GetServiceCategories();
            var menus = _homeServices.ListMenu();
            return PartialView(menus);
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            ViewBag.FooterCategories = _homeServices.ListFooterCategory();
            ViewBag.Contact = _homeServices.GetContactHome();
            var footers = _homeServices.ListFooter();
            return PartialView(footers);
        }

        [ChildActionOnly]
        public ActionResult ContactHome()
        {
            var contact = _homeServices.GetContactHome();
            return PartialView(contact);
        }

        [ChildActionOnly]
        public ActionResult HeaderLogo()
        {
            var contact = _homeServices.GetContactHome();
            return PartialView(contact);
        }

        [ChildActionOnly]
        public ActionResult FooterLogo()
        {

            var contact = _homeServices.GetContactHome();
            return PartialView(contact);
        }

        [ChildActionOnly]
        public ActionResult MiniCart()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult SendMessage(string email)
        {
            SendMail.SendMailSubcribe(email);
            return RedirectToAction("SuccessPage", "success", new { message = "Thank you ! " });
        }

        [ChildActionOnly]
        public ActionResult TopAccountNav()
        {
            var isLogin = Session[Constant.Membership.IsLoginSession];
            ViewBag.IsLogin = isLogin;
            var account = Session[Constant.Membership.AccountSession] as ClientAccount;
            return PartialView(account);
        }

        [ChildActionOnly]
        public ActionResult BookNav()
        {
            var isLogin = Session[Constant.Membership.IsLoginSession];
            ViewBag.IsLogin = isLogin;
            return PartialView();
        }
    }
}
