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
    public class MenuTypeAdminController : Controller
    {
        // GET: Admin/ContentsCategory
        private readonly IMenuTypeSerivces _menuTypeSerivces;
        public MenuTypeAdminController(IMenuTypeSerivces menuTypeSerivces)
        {
            _menuTypeSerivces = menuTypeSerivces;
        }
        // GET: Admin/ContentsAdmin
        public ActionResult Index(int? page, string searchString = null)
        {
            var listContent = _menuTypeSerivces.ListAllByName(searchString);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var listContentsPaged = listContent.ToPagedList(pageNumber, pageSize);
            ViewBag.listMenu = _menuTypeSerivces.ListMenu();
            return View(listContentsPaged);
        }

        public ActionResult Create()
        {
            ViewBag.listMenu = _menuTypeSerivces.ListMenu();
            return View();
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(MenuType MenuType)
        {

            if (ModelState.IsValid)
            {
                var addContent = _menuTypeSerivces.AddMenuType(MenuType);
                var idContents = addContent;
                if (idContents == 0) ModelState.AddModelError("", "Thêm sản phẩm không thành công !");
                return RedirectToAction("Index");
            }
            return View(MenuType);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.listMenu = _menuTypeSerivces.ListMenu();
            var Contents = _menuTypeSerivces.GetDetail(id);
            if (Contents == null) return RedirectToAction("Index");
            return View(Contents);
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(MenuType ContentsCategory)
        {
            if (ModelState.IsValid)
            {
                var editContents = _menuTypeSerivces.Edit(ContentsCategory);
                var editContentsSuccess = editContents;
                if (!editContentsSuccess) ModelState.AddModelError("", "Sửa sản phẩm không thành công !");
                return RedirectToAction("Index");
            }
            return View(ContentsCategory);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var deleteAccountSuccess = _menuTypeSerivces.Delete(id);
            return RedirectToAction("Index");
        }
    }
}