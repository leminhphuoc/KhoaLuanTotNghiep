using FonNature.Filter;
using FonNature.Services;
using Models.Entity;
using PagedList;
using System.Web.Mvc;

namespace FonNature.Areas.Admin.Controllers
{
    [AuthData]
    public class MenuAdminController : Controller
    {
        // GET: Admin/MenuAdmin
        private readonly IMenuAdminServices _menuAdminServices;
        public MenuAdminController(IMenuAdminServices menuAdminServices)
        {
            _menuAdminServices = menuAdminServices;
        }
        public ActionResult Index(int? page, string searchString = null)
        {
            var listMenu = _menuAdminServices.ListMenuByText(searchString);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var listMenuPaged = listMenu.ToPagedList(pageNumber, pageSize);
            ViewBag.MenuType = _menuAdminServices.GetMenuTypes();
            return View(listMenuPaged);
        }
        public ActionResult Create()
        {
            ViewBag.MenuType = _menuAdminServices.GetMenuTypes();
            return View();
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(Menu menu)
        {

            if (ModelState.IsValid)
            {
                var addMenuSuccess = _menuAdminServices.AddMenu(menu);
                if (addMenuSuccess == 0) ModelState.AddModelError("", "Thêm sản phẩm không thành công !");
                return RedirectToAction("Index");
            }
            return View(menu);
        }
        public ActionResult Edit(int id)
        {
            var menu = _menuAdminServices.GetDetail(id);
            if (menu == null) return RedirectToAction("Index");
            ViewBag.MenuType = _menuAdminServices.GetMenuTypes();
            return View(menu);
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(Menu menu)
        {
            if (ModelState.IsValid)
            {
                var editMenuSuccess = _menuAdminServices.Edit(menu);
                if (!editMenuSuccess) ModelState.AddModelError("", "Sửa sản phẩm không thành công !");
                return RedirectToAction("Index");
            }
            return View(menu);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _menuAdminServices.Delete(id);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var res = _menuAdminServices.ChangeStatus(id);
            return Json(new
            {
                Status = res
            });
        }

    }
}