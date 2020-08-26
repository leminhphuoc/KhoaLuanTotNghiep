using FonNature.Filter;
using FonNature.Services;
using Models.Entity;
using PagedList;
using System.Web.Mvc;

namespace FonNature.Areas.Admin.Controllers
{
    [AuthData]
    public class ContentCategoryAdminController : Controller
    {
        // GET: Admin/ContentsCategory
        private readonly IContentCategoryAdminServices _contentCategoryAdminServices;
        public ContentCategoryAdminController(IContentCategoryAdminServices contentCategoryAdminServices)
        {
            _contentCategoryAdminServices = contentCategoryAdminServices;
        }
        // GET: Admin/ContentsAdmin
        public ActionResult Index(int? page, string searchString = null)
        {
            var listContent = _contentCategoryAdminServices.ListAllByName(searchString);
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
        public ActionResult Create(ContentCategory ContentCategory)
        {

            if (ModelState.IsValid)
            {
                var addContent = _contentCategoryAdminServices.AddContentCategory(ContentCategory);
                var idContents = addContent;
                if (idContents == 0) ModelState.AddModelError("", "Thêm sản phẩm không thành công !");
                return RedirectToAction("Index");
            }
            return View(ContentCategory);
        }

        public ActionResult Edit(int id)
        {
            var Contents = _contentCategoryAdminServices.GetDetail(id);
            if (Contents == null) return RedirectToAction("Index");
            return View(Contents);
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(ContentCategory ContentsCategory)
        {
            if (ModelState.IsValid)
            {
                var editContents = _contentCategoryAdminServices.Edit(ContentsCategory);
                var editContentsSuccess = editContents;
                if (!editContentsSuccess) ModelState.AddModelError("", "Sửa sản phẩm không thành công !");
                return RedirectToAction("Index");
            }
            return View(ContentsCategory);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _contentCategoryAdminServices.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var res = _contentCategoryAdminServices.ChangeStatus(id);
            return Json(new
            {
                Status = res
            });
        }
    }
}