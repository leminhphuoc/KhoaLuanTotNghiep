using FonNature.Services.ClientServices;
using FonNature.Services.IServices;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FonNature.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactClientServices _contactClientServices;
        public ContactController(IContactClientServices contactClientServices)
        {
            _contactClientServices = contactClientServices;
        }
        // GET: Contact
        public ActionResult Index()
        {
            ViewBag.Tittle = "Contact";
            var listContact = _contactClientServices.GetContacts();
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