using FonNature.Filter;
using Models.Entity;
using Models.Repository;
using PagedList;
using System.Web.Mvc;

namespace FonNature.Areas.Admin.Controllers
{
    [AuthData]
    public class PageAdminController : Controller
    {
        private readonly IPageRepository _repository;
        public PageAdminController(IPageRepository repository)
        {
            _repository = repository;
        }
        // GET: Admin/PageAdmin
        public ActionResult PageList(int? page, string searchString = null)
        {
            var dictionaries = _repository.GetPages();

            if (!string.IsNullOrEmpty(searchString))
            {
                dictionaries = _repository.SearchPage(searchString);
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var pagedDictionaries = dictionaries.ToPagedList(pageNumber, pageSize);
            ViewBag.SearchString = searchString ?? string.Empty;
            return View(pagedDictionaries);
        }

        public ActionResult CreatePage()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreatePage(Page page)
        {
            if (ModelState.IsValid)
            {
                var addedPage = _repository.AddPage(page);
                if (addedPage == null)
                {
                    ModelState.AddModelError("", "Không thể thêm page vào cơ sở dữ liệu!");
                    return View(page);
                }
                return RedirectToAction("PageList");
            }
            return View(page);
        }

        public ActionResult EditPage(long id = 0)
        {
            var page = _repository.GetPage(id);
            if (page == null) return RedirectToAction("PageList");
            return View(page);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditPage(Page page)
        {
            if (ModelState.IsValid)
            {
                var addedPage = _repository.EditPage(page);
                if (addedPage == 0)
                {
                    ModelState.AddModelError("", "Không thể chỉnh sửa page trong cơ sở dữ liệu!");
                    return View(page);
                }
                return RedirectToAction("PageList");
            }
            return View(page);
        }

        [HttpDelete]
        public ActionResult DeletePage(long id)
        {
            _repository.RemovePage(id);
            return RedirectToAction("PageList");
        }
    }
}