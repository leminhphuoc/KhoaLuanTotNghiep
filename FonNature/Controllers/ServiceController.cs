using Models.Repository;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FonNature.Controllers
{
    [RoutePrefix("service")]
    [Route("{action=ServiceHome}")]
    public class ServiceController : Controller
    {
        // GET: Service
        private readonly IServiceRepository _repository;
        private readonly IServiceCategoryRepository _categoryRepository;
        private readonly ISEORepository _seoRepository;
        public ServiceController(IServiceRepository repository, ISEORepository seoRepository, IServiceCategoryRepository categoryRepository)
        {
            _repository = repository;
            _seoRepository = seoRepository;
            _categoryRepository = categoryRepository;
        }
        // GET: Product
        public ActionResult ServiceHome(int? page, string searchString = null)
        {
            var servicesList = _repository.GetServices();
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            var servicesListPaged = servicesList.ToPagedList(pageNumber, pageSize);
            var seo = _seoRepository.GetSEO(6);
            ViewBag.categories = _categoryRepository.GetServiceCategories();
            var isLogin = Session[Constant.Membership.IsLoginSession];
            ViewBag.IsLogin = isLogin;
            if (seo != null)
            {
                ViewBag.MetaTitle = seo.MetaTitle ?? string.Empty;
                ViewBag.MetaDescription = seo.MetaDescription ?? string.Empty;
                ViewBag.MetaKeyword = seo.MetaKeyWord ?? string.Empty;
            }
            return View(servicesListPaged);
        }

        public ActionResult ServiceListByCategory(int? page, string searchString = null, int idCategory = 0)
        {
            var serviceList = _repository.GetServicesByCategory(idCategory);
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            var servicesListPaged = serviceList.ToPagedList(pageNumber, pageSize);
            var seo = _seoRepository.GetSEO(6);
            ViewBag.categories = _categoryRepository.GetServiceCategories();
            var isLogin = Session[Constant.Membership.IsLoginSession];
            ViewBag.IsLogin = isLogin;
            if (seo != null)
            {
                ViewBag.MetaTitle = seo.MetaTitle ?? string.Empty;
                ViewBag.MetaDescription = seo.MetaDescription ?? string.Empty;
                ViewBag.MetaKeyword = seo.MetaKeyWord ?? string.Empty;
            }
            return View(servicesListPaged);
        }

        public ActionResult Detail(long id)
        {
            var service = _repository.GetService(id);
            if(service == null)
            {
                return RedirectToAction("ServiceHome");
            }
            ViewBag.ListImage = _repository.GetImagesList(id);
            ViewBag.MetaTitle = service.MetaTitle ?? string.Empty;
            ViewBag.MetaDescription = service.MetaKeyword ?? string.Empty;
            ViewBag.MetaKeyword = service.MetaDescription ?? string.Empty;
            var isLogin = Session[Constant.Membership.IsLoginSession];
            ViewBag.IsLogin = isLogin;
            return View(service);
        }
    }
}