using Models.Entity;
using Models.Repository;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FonNature.Areas.Admin.Controllers
{
    public class ServiceCategoryAdminController : Controller
    {
        private readonly IServiceCategoryRepository _repository;
        public ServiceCategoryAdminController(IServiceCategoryRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index(int? page, string searchString = null)
        {
            var categories = _repository.GetServiceCategories();

            if (!string.IsNullOrEmpty(searchString))
            {
                categories = _repository.SearchServiceCategory(searchString);
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var pagedCategories = categories.ToPagedList(pageNumber, pageSize);
            ViewBag.SearchString = searchString ?? string.Empty;
            return View(pagedCategories);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiceCategory serviceCategory)
        {
            if (ModelState.IsValid)
            {
                var addedServiceCategory = _repository.AddServiceCategory(serviceCategory);
                if (addedServiceCategory == null)
                {
                    ModelState.AddModelError("", "Cannot add dictionary, please see log for more detail!");
                    return View(serviceCategory);
                }
                return RedirectToAction("Index");
            }
            return View(serviceCategory);
        }

        public ActionResult Edit(long id)
        {
            var serviceCategory = _repository.GetServiceCategory(id);
            if (serviceCategory == null) return RedirectToAction("Index");
            return View(serviceCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(ServiceCategory category)
        {
            if (ModelState.IsValid)
            {
                var categoryId = _repository.EditServiceCategory(category);
                if (categoryId == 0) ModelState.AddModelError("", "Cannot update!");
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            _repository.RemoveServiceCategory(id);
            return RedirectToAction("Index");
        }
    }
}