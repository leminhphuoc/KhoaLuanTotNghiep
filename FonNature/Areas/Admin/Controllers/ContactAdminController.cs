using FonNature.Filter;
using FonNature.Services;
using Models.Entity;
using System.Web.Mvc;

namespace FonNature.Areas.Admin.Controllers
{
    [AuthData]
    public class ContactAdminController : Controller
    {

        private readonly IContactAdminServices _contactAdminServices;
        public ContactAdminController(IContactAdminServices contactAdminServices)
        {
            _contactAdminServices = contactAdminServices;
        }
        // GET: Admin/ContactAdmin
        public ActionResult Edit()
        {
            var Contact = _contactAdminServices.GetContact();
            return View(Contact);
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult Edit(Contact Contact)
        {
            if (ModelState.IsValid)
            {
                var editContactSuccess = _contactAdminServices.Edit(Contact);
                return Json(new { status = editContactSuccess });
            }
            return Json(new { status = false });
        }
    }
}