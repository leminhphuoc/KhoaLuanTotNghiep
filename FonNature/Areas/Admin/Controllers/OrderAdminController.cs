using FonNature.Filter;
using FonNature.Services.IAdminServices;
using Models.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FonNature.Areas.Admin.Controllers
{
    [AuthData]
    public class OrderAdminController : Controller
    {
        private readonly IOrderAdminServices _orderAdminServices;
        public OrderAdminController(IOrderAdminServices orderAdminServices)
        {
            _orderAdminServices = orderAdminServices;
        }
        // GET: Admin/OrderAdmin
        public ActionResult OrdersList()
        {
            var statuses = _orderAdminServices.GetStatuses();
            ViewBag.statuses = statuses;
            var customersList = _orderAdminServices.GetCustomers();
            ViewBag.customersList = customersList;
            var ordersList = _orderAdminServices.GetOrders();
            return View(ordersList);
        }

        public ActionResult OrderDetail(long id)
        {
            var order = _orderAdminServices.GetOrder(id);
            var statuses = _orderAdminServices.GetStatuses();
            ViewBag.statuses = statuses;
            var customersList = _orderAdminServices.GetCustomers();
            ViewBag.customer = customersList.SingleOrDefault(x => x.id == order.IdCustomer);
            var orderInforsList = _orderAdminServices.GetOrderInfors(id);
            List<OrderProduct> orderProducts = new List<OrderProduct>();
            foreach(var infor in orderInforsList)
            {
                var product = new OrderProduct(infor.IdProduct, infor.Quantity);
                orderProducts.Add(product);
            }
            ViewBag.OrderProducts = orderProducts;
            return View(order);
        }
    }
}