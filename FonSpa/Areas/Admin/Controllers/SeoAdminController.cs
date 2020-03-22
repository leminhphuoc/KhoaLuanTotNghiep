using Models.IRepository;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PagedList;
using Models.Entity;

namespace FonNature.Areas.Admin.Controllers
{
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

        public ActionResult SeoDetail(long id)
        {
            var seo = _seoRepository.GetSEO(id);
            return View(seo);
        }

        [HttpPost]
        public ActionResult Edit(SEO seo)
        {
            var seoId = _seoRepository.EditSEO(seo);
            return RedirectToAction("SeoDetail", new { id = seoId});
        }
    }
}