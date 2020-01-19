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
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;
        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }
        // GET: Product
        public ActionResult Index(int? page, string searchString = null)
        {
            ViewBag.Tittle = "Products";
            var listProduct = _productServices.ListAll();
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            var listProductPaged = listProduct.ToPagedList(pageNumber, pageSize);
            return View(listProductPaged);
        }

        public ActionResult ListByCategory(int? page, string searchString = null, int idCategory = 0)
        {
            ViewBag.Tittle = "Products";
            var listProduct = _productServices.ListByCategory(idCategory);
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            var listProductPaged = listProduct.ToPagedList(pageNumber, pageSize);
            return View(listProductPaged);
        }

        public ActionResult Detail(long id)
        {
            var product = _productServices.GetDetail(id);
            ViewBag.Tittle = "Product Detail";
            return View(product);
        }

        public ActionResult CheckOut()
        {
            var idProductsFromCart = Request.Form["id"];
            if (idProductsFromCart == null) return View();
            var idProductsSplit = idProductsFromCart.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int productTotal = idProductsSplit.Count();
            if (productTotal == 0) return View();
            List<CartProduct> cart = new List<CartProduct>();
            for (int i = 1; i <= productTotal; i++)
            {
                CartProduct product = new CartProduct(long.Parse(idProductsSplit[i - 1])) { ProductId = long.Parse(idProductsSplit[i - 1]), Count = int.Parse(Request.Form["quantity_" + i]) };
                cart.Add(product);
            }
            Session[Constant.Cart_Sesion] = cart;
            return View(cart);
        }

        public ActionResult Order(Customer customer)
        {
            var idProductsFromCart = Request.Form["id"];
            return View();
        }
    }
}