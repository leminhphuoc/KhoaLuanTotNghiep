using FonNature.Services.IClientServices;
using Models.Entity;
using Models.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FonNature.Controllers
{
    [RoutePrefix("product")]
    [Route("{action=ProductHome}")]
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly IOrderServices _orderServices;
        public ProductController(IProductServices productServices, IOrderServices orderServices)
        {
            _productServices = productServices;
            _orderServices = orderServices;
        }
        // GET: Product
        public ActionResult ProductHome(int? page, string searchString = null)
        {
            var productList = _productServices.ListAll();
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            var productListPaged = productList.ToPagedList(pageNumber, pageSize);
            var seo = _productServices.GetProductSeo();
            ViewBag.banner = _productServices.GetProductBanner();
            ViewBag.categories = _productServices.GetProductCategories();
            if (seo != null)
            {
                ViewBag.MetaTitle = seo.MetaTitle ?? string.Empty;
                ViewBag.MetaDescription = seo.MetaDescription ?? string.Empty;
                ViewBag.MetaKeyword = seo.MetaKeyWord ?? string.Empty;
            }
            return View(productListPaged);
        }

        public ActionResult ProductListByCategory(int? page, string searchString = null, int idCategory = 0)
        {
            var listProduct = _productServices.ListByCategory(idCategory);
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            var listProductPaged = listProduct.ToPagedList(pageNumber, pageSize);
            ViewBag.banner = _productServices.GetProductBanner();
            ViewBag.categories = _productServices.GetProductCategories();
            var seo = _productServices.GetProductSeo();
            if (seo != null)
            {
                ViewBag.MetaTitle = seo.MetaTitle ?? string.Empty;
                ViewBag.MetaDescription = seo.MetaDescription ?? string.Empty;
                ViewBag.MetaKeyword = seo.MetaKeyWord ?? string.Empty;
            }
            return View(listProductPaged);
        }

        public ActionResult Detail(long id)
        {
            var product = _productServices.GetDetail(id);
            ViewBag.categoryName = _productServices.GetCategoryName(product.idCategory.Value);
            ViewBag.RealtedProduct = _productServices.GetRelatedProduct(product);
            ViewBag.ListImage = _productServices.GetImagesList(id);
            ViewBag.MetaTitle = product.MetaTitle ?? string.Empty;
            ViewBag.MetaDescription = product.MetaKeyword ?? string.Empty;
            ViewBag.MetaKeyword = product.MetaDescription ?? string.Empty;
            return View(product);
        }

        public ActionResult CheckOut()
        {
            var idProductsFromCart = Request.Form["id"];
            if (idProductsFromCart == null) return View();
            var idProductsSplit = idProductsFromCart.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int productTotal = idProductsSplit.Count();
            if (productTotal == 0) return View();
            List<ProductInCart> cart = new List<ProductInCart>();
            for (int i = 1; i <= productTotal; i++)
            {
                var product = new ProductInCart(long.Parse(idProductsSplit[i - 1])) { ProductId = long.Parse(idProductsSplit[i - 1]), Count = int.Parse(Request.Form["quantity_" + i]) };
                cart.Add(product);
            }
            Session[Constant.Cart_Sesion] = cart;
            return View(cart);
        }

        [HttpPost]
        public JsonResult OrderInformation(List<OrderInformation> orderInformations)
        {
            TempData["OrderInformation"] = orderInformations;
            return Json(new { orderInformations }
            );
        }

        [HttpPost]
        public ActionResult Order(Customer customerInfor)
        {
            var orderInformations = TempData["OrderInformation"] as List<OrderInformation>;
            var idOrder = _orderServices.CreateOrder(orderInformations,customerInfor);
            var productInCarts = new List<ProductInCart>();
            foreach(var order in orderInformations)
            {
                var product = new ProductInCart(order.IdProduct);
                productInCarts.Add(product);
            }
            var cart = new Cart() { productInCarts = productInCarts, customer = customerInfor };
            if (idOrder > 0) ViewBag.idOrder = idOrder;
            return View(cart);
        }
    }
}