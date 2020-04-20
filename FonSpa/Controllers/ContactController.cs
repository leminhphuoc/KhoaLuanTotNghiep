using FonNature.Services.ClientServices;
using FonNature.Services.IServices;
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
            ViewBag.Tittle = "Contact";
            SendMail.SendMailFromCustomer(name, email, comment);
            return View("~/Views/Shared/Success");
        }

    }
}