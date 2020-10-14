using FonNature.Filter;
using FonNature.Services;
using Models.Entity;
using PagedList;
using System.Web.Mvc;

namespace FonNature.Areas.Admin.Controllers
{
    [AuthData]
    public class ProductAdminController : Controller
    {
        private readonly IProductAdminSerivces _productAdminServices;
        public ProductAdminController(IProductAdminSerivces productAdminServices)
        {
            _productAdminServices = productAdminServices;
        }
        // GET: Admin/ProductAdmin
        public ActionResult Index(int? page, string searchString = null)
        {
            var listProduct = _productAdminServices.ListAllByName(searchString);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var listProductPaged = listProduct.ToPagedList(pageNumber, pageSize);
            ViewBag.ProductCategory = _productAdminServices.GetProductCategory();
            ViewBag.SearchString = searchString ?? string.Empty;
            return View(listProductPaged);
        }

        public ActionResult Create()
        {
            ViewBag.ProductCategory = _productAdminServices.GetProductCategory();
            return View();
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(Product product)
        {

            if (ModelState.IsValid)
            {
                var addProduct = _productAdminServices.AddProduct(product);
                var idProduct = addProduct;
                if (idProduct == 0) ModelState.AddModelError("", "Thêm sản phẩm không thành công !");
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ActionResult Edit(int id)
        {
            var product = _productAdminServices.GetDetail(id);
            if (product == null) return RedirectToAction("Index");
            ViewBag.ProductCategory = _productAdminServices.GetProductCategory();
            return View(product);
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var editProduct = _productAdminServices.Edit(product);
                var editProductSuccess = editProduct;
                if (!editProductSuccess) ModelState.AddModelError("", "Sửa sản phẩm không thành công !");
                return RedirectToAction("Index");
            }
            ViewBag.ProductCategory = _productAdminServices.GetProductCategory();
            return View(product);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _productAdminServices.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var res = _productAdminServices.ChangeStatus(id);
            return Json(new
            {
                Status = res
            });
        }

        [HttpPost]
        public JsonResult SaveProductImages(string images, long id)
        {
            try
            {
                var saveImages = _productAdminServices.SaveProductImage(images, id);
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

        public JsonResult ProductImages(long id)
        {
            var imagesList = _productAdminServices.GetImagesList(id);
            return Json(new
            {
                data = imagesList
            }, JsonRequestBehavior.AllowGet);
        }
    }
}