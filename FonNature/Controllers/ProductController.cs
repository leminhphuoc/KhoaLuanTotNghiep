using FonNature.Filter;
using FonNature.Services;
using Models.Entity;
using Models.Model;
using Newtonsoft.Json;
using PagedList;
using System;
using System.Collections.Generic;
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

        public ActionResult CartPreview()
        {
            ViewBag.IsLogin = Session[Constant.Membership.IsLoginSession];
            return View();
        }

        [HttpPost]
        public JsonResult OrderInformation(List<OrderInformation> orderInformations)
        {
            TempData["OrderInformation"] = orderInformations;
            return Json(new { orderInformations }
            );
        }

        [HttpPost]
        public JsonResult GetDetailJson(long id)
        {
            var product = _productServices.GetDetail(id);
            return Json(new
            {
                product = product
            }
            );
        }

        [HttpPost]
        public JsonResult AddCart(string data)
        {
            var ProductInCart = JsonConvert.DeserializeObject<List<ProductInCart>>(data);
            if (ProductInCart != null)
            {
                Session["cart"] = ProductInCart;
                return Json(new
                {
                    res = true
                });
            }
            else
            {
                return Json(new
                {
                    res = false
                });
            }
        }

        [AuthenticationClient]
        public ActionResult Checkout()
        {
            ViewBag.Account = Session[Constant.Membership.AccountSession];

            if(TempData["PaymentError"] != null)
            {
                ModelState.AddModelError("", TempData["PaymentError"].ToString());
            }

            return View();
        }

        [HttpPost]
        public ActionResult Checkout(ShippingAddress shippingAddress)
        {
            var account = Session[Constant.Membership.AccountSession] as ClientAccount;
            if(account == null)
            {
                return Redirect("/");
            }
            if (ModelState.IsValid)
            {
                var cartItem = Session["cart"];
                if (cartItem == null && shippingAddress == null) return View(shippingAddress);
                var orderID = _orderServices.CreateOrder(cartItem as List<ProductInCart>, account.Id, shippingAddress);

                var returnUrl = Constant.HostUrl + "/product/ConfirmPayment";

                var result = _orderServices.PaymentByMomo(orderID, returnUrl);
                if(result.ErrorCode.Equals("0"))
                {
                    return Redirect(result.PayUrl);
                }
                ModelState.AddModelError("", result.ErrorCode + " - " + result.Message);
            }
            ViewBag.Account = Session[Constant.Membership.AccountSession];
            return View();
        }

        [HttpGet]
        public ActionResult ConfirmPayment(MomoPaymentResponse response)
        {
            if(response.ErrorCode.Equals("0"))
            {
                //var currentSignature = Session[Constant.SignatureSession];

                //if(!currentSignature.Equals(response.Signature))
                //{
                //    TempData["PaymentError"] = "101: Invalid request";
                //    return RedirectToAction("checkout");
                //}
                    
                return RedirectToAction("OrderSuccessPage", "Success", new { orderID = response.OrderId });
            }

            TempData["PaymentError"] = response.ErrorCode + " - " + response.Message;
            return RedirectToAction("checkout");
        }
    }
}