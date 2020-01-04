using FonNature.Filter;
using FonNature.Services.IServices;
using Models.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public ActionResult Index(int? page)
        {
            var listContact = _contactAdminServices.GetListContact();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var listContactPaged = listContact.ToPagedList(pageNumber, pageSize);
            return View(listContactPaged);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(Contact Contact)
        {

            if (ModelState.IsValid)
            {
                var addContactSuccess = _contactAdminServices.AddContact(Contact);
                if (addContactSuccess == 0) ModelState.AddModelError("", "Thêm Contact không thành công !");
                return RedirectToAction("Index");
            }
            return View(Contact);
        }
        public ActionResult Edit(int id)
        {
            var Contact = _contactAdminServices.GetDetail(id);
            if (Contact == null) return RedirectToAction("Index");
            return View(Contact);
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(Contact Contact)
        {
            if (ModelState.IsValid)
            {
                var editContactSuccess = _contactAdminServices.Edit(Contact);
                if (!editContactSuccess) ModelState.AddModelError("", "Edit contact fail !");
                return RedirectToAction("Index");
            }
            return View(Contact);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var deleteSuccess = _contactAdminServices.Delete(id);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var res = _contactAdminServices.ChangeStatus(id);
            return Json(new
            {
                Status = res
            });
        }
        
    }
}