using FonNature.Filter;
using FonNature.Services;
using Models.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FonNature.Areas.Admin.Controllers
{
    [AuthData]
    public class ProductCategoryController : Controller
    {
        // GET: Admin/ProductCategory
        private readonly IProductCategoryAdminServices _productCategoryAdminServices;
        public ProductCategoryController(IProductCategoryAdminServices productCategoryAdminServices)
        {
            _productCategoryAdminServices = productCategoryAdminServices;
        }
        // GET: Admin/ProductAdmin
        public ActionResult Index(int? page, string searchString = null)
        {
            var listProduct = _productCategoryAdminServices.ListAllByName(searchString);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var listProductPaged = listProduct.ToPagedList(pageNumber, pageSize);
            return View(listProductPaged);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(ProductCategory product)
        {

            if (ModelState.IsValid)
            {
                var addProduct = _productCategoryAdminServices.AddProductCategory(product);
                var idProduct = addProduct;
                if (idProduct == 0) ModelState.AddModelError("", "Thêm sản phẩm không thành công !");
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ActionResult Edit(int id)
        {
            var product = _productCategoryAdminServices.GetDetail(id);
            if (product == null) return RedirectToAction("Index");
            return View(product);
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                var editProduct = _productCategoryAdminServices.Edit(productCategory);
                var editProductSuccess = editProduct;
                if (!editProductSuccess) ModelState.AddModelError("", "Sửa sản phẩm không thành công !");
                return RedirectToAction("Index");
            }
            return View(productCategory);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _productCategoryAdminServices.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var res = _productCategoryAdminServices.ChangeStatus(id);
            return Json(new
            {
                Status = res
            });
        }
    }
}