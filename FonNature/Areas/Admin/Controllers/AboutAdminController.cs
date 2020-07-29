using FonNature.Filter;
using FonNature.Services;
using Models.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FonNature.Areas.Admin.Controllers
{
    [AuthData]
    public class AboutAdminController : Controller
    {

        private readonly IAboutAdminServices _aboutAdminServices;
        public AboutAdminController(IAboutAdminServices aboutAdminServices)
        {
            _aboutAdminServices = aboutAdminServices;
        }
        public ActionResult Index(int? page, string searchString = null)
        {
            var listAbout = _aboutAdminServices.ListAllByName(searchString);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var listAboutPaged = listAbout.ToPagedList(pageNumber, pageSize);
            return View(listAboutPaged);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(About About)
        {

            if (ModelState.IsValid)
            {
                var addAboutSuccess = _aboutAdminServices.AddAbout(About);
                if (addAboutSuccess == 0) ModelState.AddModelError("", "Thêm sản phẩm không thành công !");
                return RedirectToAction("Index");
            }
            return View(About);
        }
        public ActionResult Edit(int id)
        {
            var About = _aboutAdminServices.GetDetail(id);
            if (About == null) return RedirectToAction("Index");
            return View(About);
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(About About)
        {
            if (ModelState.IsValid)
            {
                var editAboutSuccess = _aboutAdminServices.Edit(About);
                if (!editAboutSuccess) ModelState.AddModelError("", "Sửa sản phẩm không thành công !");
                return RedirectToAction("Index");
            }
            return View(About);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _aboutAdminServices.Delete(id);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var res = _aboutAdminServices.ChangeStatus(id);
            return Json(new
            {
                Status = res
            });
        }
    }
}