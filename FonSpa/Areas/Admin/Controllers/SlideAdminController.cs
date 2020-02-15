using FonNature.Filter;
using FonNature.Services.IServices;
using Models.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FonNature.Areas.Admin.Controllers
{
    [AuthData]
    public class SlideAdminController : Controller
    {
        // GET: Admin/SlideAdmin
        private readonly ISlideAdminServices _slideAdminServices;
        public SlideAdminController(ISlideAdminServices slideAdminServices)
        {
            _slideAdminServices = slideAdminServices;
        }
        // GET: Admin/slideAdmin
        public ActionResult Index(int? page)
        {
            var listSlide = _slideAdminServices.GetListSlide();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var listslidePaged = listSlide.ToPagedList(pageNumber, pageSize);
            return View(listslidePaged);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Slide slide)
        {

            if (ModelState.IsValid)
            {
                var addSlideSuccess = _slideAdminServices.AddSlide(slide);
                if (addSlideSuccess == 0) ModelState.AddModelError("", "Thêm slide không thành công !");
                return RedirectToAction("Index");
            }
            return View(slide);
        }
        public ActionResult Edit(int id)
        {
            var slide = _slideAdminServices.GetDetail(id);
            if (slide == null) return RedirectToAction("Index");
            return View(slide);
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(Slide slide)
        {
            if (ModelState.IsValid)
            {
                var editSlideSuccess = _slideAdminServices.Edit(slide);
                if (!editSlideSuccess) ModelState.AddModelError("", "Sửa sản phẩm không thành công !");
                return RedirectToAction("Index");
            }
            return View(slide);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _slideAdminServices.Delete(id);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var res = _slideAdminServices.ChangeStatus(id);
            return Json(new
            {
                Status = res
            });
        }
    }
}