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
    public class StaffAdminController : Controller
    {
        private readonly IStaffAdminServices _staffAdminServices;
        public StaffAdminController(IStaffAdminServices staffAdminServices)
        {
            _staffAdminServices = staffAdminServices;
        }
        // GET: Admin/StaffAdmin


        public ActionResult Index(int? page, string searchString = null)
        {
            var listStaff = _staffAdminServices.ListAllByName(searchString);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var listStaffPaged = listStaff.ToPagedList(pageNumber, pageSize);
            return View(listStaffPaged);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Staff staff)
        {

            if (ModelState.IsValid)
            {
                var addStaffSuccess = _staffAdminServices.AddStaff(staff);
                if (addStaffSuccess == 0) ModelState.AddModelError("", "Thêm Staff không thành công !");
                return RedirectToAction("Index");
            }
            return View(staff);
        }
        public ActionResult Edit(int id)
        {
            var Staff = _staffAdminServices.GetDetail(id);
            if (Staff == null) return RedirectToAction("Index");
            return View(Staff);
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(Staff Staff)
        {
            if (ModelState.IsValid)
            {
                var editStaffSuccess = _staffAdminServices.Edit(Staff);
                if (!editStaffSuccess) ModelState.AddModelError("", "Sửa sản phẩm không thành công !");
                return RedirectToAction("Index");
            }
            return View(Staff);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var deleteSuccess = _staffAdminServices.Delete(id);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var res = _staffAdminServices.ChangeStatus(id);
            return Json(new
            {
                Status = res
            });
        }
        [HttpPost]
        public JsonResult ChangeShowOnHome(int id)
        {
            var res = _staffAdminServices.ShowOnHome(id);
            return Json(new
            {
                Status = res
            });
        }

    }
}