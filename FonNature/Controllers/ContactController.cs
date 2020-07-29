using FonNature.Services;
using System.Web.Mvc;

namespace FonNature.Controllers
{
    [RoutePrefix("contact")]
    [Route("{action=ContactHome}")]
    public class ContactController : Controller
    {
        private readonly IContactClientServices _contactClientServices;
        public ContactController(IContactClientServices contactClientServices)
        {
            _contactClientServices = contactClientServices;
        }
        // GET: Contact
        public ActionResult ContactHome()
        {
            ViewBag.Tittle = "Contact";
            var listContact = _contactClientServices.GetContact();
            var seo = _contactClientServices.GetSeo();
            ViewBag.banner = _contactClientServices.GetBanner();
            if (seo != null)
            {
                ViewBag.MetaTitle = seo.MetaTitle ?? string.Empty;
                ViewBag.MetaDescription = seo.MetaDescription ?? string.Empty;
                ViewBag.MetaKeyword = seo.MetaKeyWord ?? string.Empty;
            }
            return View(listContact);
        }
        public ActionResult SendMessage(string name, string email, string comment)
        {
            SendMail.SendMailFromCustomer(name, email, comment);
            return RedirectToAction("SuccessPage", "success", new { message = "Thank you ! " });
        }

    }
}