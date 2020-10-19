using Models.Repository;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FonNature.Areas.Admin.Controllers
{
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
    }
}