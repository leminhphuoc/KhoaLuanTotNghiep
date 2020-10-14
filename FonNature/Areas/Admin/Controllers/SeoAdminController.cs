using FonNature.Filter;
using Models.Entity;
using Models.Repository;
using PagedList;
using System.Web.Mvc;

namespace FonNature.Areas.Admin.Controllers
{
    [AuthData]
    public class SeoAdminController : Controller
    {
        private readonly ISEORepository _seoRepository;
        public SeoAdminController(ISEORepository seoRepository)
        {
            _seoRepository = seoRepository;
        }
        // GET: Admin/SeoAdmin
        public ActionResult SeoList(int? page, string searchString = null)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var seoList = _seoRepository.GetSEOs();
            var seoListPaged = seoList.ToPagedList(pageNumber, pageSize);
            return View(seoListPaged);
        }

        public ActionResult SeoDetail(int id)
        {
            var seo = _seoRepository.GetSEODetail(id);
            return View(seo);
        }

        [HttpPost]
        public ActionResult Edit(SEO seo)
        {
            var seoId = _seoRepository.EditSEO(seo);
            return RedirectToAction("SeoDetail", new { id = seoId });
        }
    }
}