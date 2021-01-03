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
    public class CouponCodeAdminController : Controller
    {
        private readonly ICouponCodeRepository _repository;
        private readonly IProductAdminRepository _productRepository;
        public CouponCodeAdminController(ICouponCodeRepository repository, IProductAdminRepository productRepository)
        {
            _repository = repository;
            _productRepository = productRepository;
        }
        // GET: Admin/CouponCode
        public ActionResult Index(int? page, string searchString = null)
        {
            var couponCodes = _repository.GetCouponCodes();

            if (!string.IsNullOrEmpty(searchString))
            {
                couponCodes = _repository.GetCouponCodesByCode(searchString);
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var couponCodesPaged = couponCodes.ToPagedList(pageNumber, pageSize);
            ViewBag.SearchString = searchString ?? string.Empty;
            return View(couponCodesPaged);
        }

        public ActionResult Create()
        {
            ViewBag.ProductList = _productRepository?.GetListProduct();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CouponCode couponCode, List<string> productList)
        {
            if (ModelState.IsValid && couponCode != null)
            {
                if(productList != null || productList.Any())
                {
                    couponCode.ProductId = string.Join("|", productList);
                }                
                var result = _repository.AddCouponCode(couponCode);
                if (result.IsError)
                {
                    ViewBag.ProductList = _productRepository?.GetListProduct();
                    ModelState.AddModelError("", result.ErrorMessage);
                    return View(couponCode);
                }

                return RedirectToAction("Index");
            }

            ViewBag.ProductList = _productRepository?.GetListProduct();
            return View(couponCode);
        }

        public ActionResult Edit(string code)
        {
            if(string.IsNullOrWhiteSpace(code))
            {
                return RedirectToAction("Index");
            }

            var couponCode = _repository.GetCouponCode(code);
            ViewBag.ProductList = _productRepository?.GetListProduct();
            return View(couponCode);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CouponCode couponCode, List<string> productList)
        {
            if (ModelState.IsValid && couponCode != null)
            {
                if (productList != null || productList.Any())
                {
                    couponCode.ProductId = string.Join("|", productList);
                }
                var result = _repository.UpdateCouponCode(couponCode);
                if (result.IsError)
                {
                    ViewBag.ProductList = _productRepository?.GetListProduct();
                    ModelState.AddModelError("", result.ErrorMessage);
                    return View(couponCode);
                }

                return RedirectToAction("Index");
            }

            ViewBag.ProductList = _productRepository?.GetListProduct();
            return View(couponCode);
        }

        [HttpDelete]
        public ActionResult Delete(string code)
        {
            _repository.DeleteCouponCode(code);
            return RedirectToAction("Index");
        }
    }
}