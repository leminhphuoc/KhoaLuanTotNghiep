using Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FonNature.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IPageRepository _repository;
        public DefaultController(IPageRepository repository)
        {
            _repository = repository;
        }

        // GET: Default
        public ActionResult CommonPage(string pageUrl)
        {
            var model = _repository.GetPageByUrl(pageUrl);
            if (model == null) return View("~/Views/Shared/Error.cshtml");
            ViewBag.MetaTitle = model.MetaTitle ?? string.Empty;
            ViewBag.MetaDescription = model.MetaDescription ?? string.Empty;
            ViewBag.MetaKeyword = model.MetaKeywords ?? string.Empty;
            return View(model);
        }
    }
}