
using FonNature.Filter;
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
    [AuthData]
    public class ServiceAdminController : Controller
    {
        private readonly IServiceRepository _repository;
        private readonly IServiceCategoryRepository _serviceCategoryRepository;
        public ServiceAdminController(IServiceRepository repository, IServiceCategoryRepository serviceCategoryRepository)
        {
            _repository = repository;
            _serviceCategoryRepository = serviceCategoryRepository;
        }

        public ActionResult Index(int? page, string searchString = null)
        {
            var services = _repository.GetServices();

            if (!string.IsNullOrEmpty(searchString))
            {
                services = _repository.SearchService(searchString);
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var pagedServices = services.ToPagedList(pageNumber, pageSize);
            ViewBag.SearchString = searchString ?? string.Empty;
            ViewBag.ServiceCategories = _serviceCategoryRepository?.GetServiceCategories();
            return View(pagedServices);
        }

        public ActionResult Create()
        {
            ViewBag.ServiceCategories = _serviceCategoryRepository?.GetServiceCategories();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Service service)
        {
            if (ModelState.IsValid && service != null)
            {
                var addedService = _repository.AddService(service);
                if (addedService == null)
                {
                    ModelState.AddModelError("", "Cannot add service, please see log for more detail!");
                    return View(service);
                }

                return RedirectToAction("Index");
            }

            ViewBag.ServiceCategories = _serviceCategoryRepository?.GetServiceCategories();
            return View(service);
        }

        public ActionResult Edit(long id)
        {
            var service = _repository.GetService(id);
            if(id == 0 || service ==null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.ServiceCategories = _serviceCategoryRepository?.GetServiceCategories();

            return View(service);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Service service)
        {
            if (ModelState.IsValid && service != null)
            {
                var editedService = _repository.EditService(service);
                if (editedService == 0)
                {
                    ModelState.AddModelError("", "Cannot edit service, please see log for more detail!");
                    return View(service);
                }

                return RedirectToAction("Index");
            }

            ViewBag.ServiceCategories = _serviceCategoryRepository?.GetServiceCategories();
            return View(service);
        }

        [HttpPost]
        public JsonResult SaveServiceImages(string images, long id)
        {
            try
            {
                var saveImages = _repository.SaveImages(images, id);
                return Json(new
                {
                    Status = saveImages
                });
            }
            catch
            {
                return Json(new
                {
                    Status = false
                });
            }
        }

        public JsonResult ServiceImages(long id)
        {
            var imagesList = _repository.GetImagesList(id);
            return Json(new
            {
                data = imagesList
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _repository.RemoveService(id);
            return RedirectToAction("Index");
        }
    }
}