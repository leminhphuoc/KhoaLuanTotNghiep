using FonNature.Filter;
using FonNature.Services;
using Models.Entity;
using PagedList;
using System.Web.Mvc;

namespace FonNature.Areas.Admin.Controllers
{
    [AuthData]
    public class FooterAdminController : Controller
    {
        private readonly IFooterAdminServices _footerAdminServices;
        public FooterAdminController(IFooterAdminServices footerAdminServices)
        {
            _footerAdminServices = footerAdminServices;
        }
        // GET: Admin/FooterAdmin
        public ActionResult Index(int? page)
        {
            var listFooter = _footerAdminServices.GetListFooter();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var listFooterPaged = listFooter.ToPagedList(pageNumber, pageSize);
            ViewBag.FooterType = _footerAdminServices.GetFooterCategory();
            return View(listFooterPaged);
        }

        public ActionResult Create()
        {
            ViewBag.FooterType = _footerAdminServices.GetFooterCategory();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Footer Footer)
        {

            if (ModelState.IsValid)
            {
                var addFooterSuccess = _footerAdminServices.AddFooter(Footer);
                if (addFooterSuccess == 0) ModelState.AddModelError("", "Thêm footer không thành công !");
                return RedirectToAction("Index");
            }
            return View(Footer);
        }
        public ActionResult Edit(int id)
        {
            var Footer = _footerAdminServices.GetDetail(id);
            if (Footer == null) return RedirectToAction("Index");
            ViewBag.FooterType = _footerAdminServices.GetFooterCategory();
            return View(Footer);
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(Footer Footer)
        {
            if (ModelState.IsValid)
            {
                var editFooterSuccess = _footerAdminServices.Edit(Footer);
                if (!editFooterSuccess) ModelState.AddModelError("", "Sửa sản phẩm không thành công !");
                return RedirectToAction("Index");
            }
            return View(Footer);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _footerAdminServices.Delete(id);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var res = _footerAdminServices.ChangeStatus(id);
            return Json(new
            {
                Status = res
            });
        }
    }
}