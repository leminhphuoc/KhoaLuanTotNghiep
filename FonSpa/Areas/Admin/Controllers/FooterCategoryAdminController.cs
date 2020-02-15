using FonNature.Filter;
using FonNature.Services.IServices;
using Models.Entity;
using PagedList;
using System.Web.Mvc;

namespace FonNature.Areas.Admin.Controllers
{
    [AuthData]
    public class FooterCategoryAdminController : Controller
    {
        // GET: Admin/FooterCategoryAdmin
        // GET: Admin/ContentsCategory
        private readonly IFooterCategoryAdminServices _footerCategoryAdminServices;
        public FooterCategoryAdminController(IFooterCategoryAdminServices footerCategoryAdminServices)
        {
            _footerCategoryAdminServices = footerCategoryAdminServices;
        }
        // GET: Admin/ContentsAdmin
        public ActionResult Index(int? page, string searchString = null)
        {
            var listContent = _footerCategoryAdminServices.ListAllByName(searchString);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var listContentsPaged = listContent.ToPagedList(pageNumber, pageSize);
            return View(listContentsPaged);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(FooterCategory FooterCategory)
        {

            if (ModelState.IsValid)
            {
                var addContent = _footerCategoryAdminServices.AddFooterCategory(FooterCategory);
                var idContents = addContent;
                if (idContents == 0) ModelState.AddModelError("", "Thêm sản phẩm không thành công !");
                return RedirectToAction("Index");
            }
            return View(FooterCategory);
        }

        public ActionResult Edit(int id)
        {
            var Contents = _footerCategoryAdminServices.GetDetail(id);
            if (Contents == null) return RedirectToAction("Index");
            return View(Contents);
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(FooterCategory ContentsCategory)
        {
            if (ModelState.IsValid)
            {
                var editContents = _footerCategoryAdminServices.Edit(ContentsCategory);
                var editContentsSuccess = editContents;
                if (!editContentsSuccess) ModelState.AddModelError("", "Sửa sản phẩm không thành công !");
                return RedirectToAction("Index");
            }
            return View(ContentsCategory);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _footerCategoryAdminServices.Delete(id);
            return RedirectToAction("Index");
        }
    }
}