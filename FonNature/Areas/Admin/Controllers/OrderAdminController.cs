using FonNature.Filter;
using FonNature.Services.Extension;
using FonNature.Services.IAdminServices;
using Models.Entity;
using Models.Model;
using Models.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FonNature.Areas.Admin.Controllers
{
    [AuthData]
    public class OrderAdminController : Controller
    {
        private readonly IOrderAdminServices _orderAdminServices;
        private readonly IClientAccountRepository _clientAccountRepository;
        private readonly List<ClientAccount> _clientAccounts;
        public OrderAdminController(IOrderAdminServices orderAdminServices, IClientAccountRepository clientAccountRepository)
        {
            _orderAdminServices = orderAdminServices;
            _clientAccountRepository = clientAccountRepository;
            _clientAccounts = _clientAccountRepository.GetClientAccounts();
        }
        // GET: Admin/OrderAdmin
        public ActionResult OrdersList()
        {
            var statuses = _orderAdminServices.GetStatuses();
            ViewBag.statuses = statuses;
            ViewBag.clientAccountList = _clientAccounts;
            var ordersList = _orderAdminServices.GetOrders();
            return View(ordersList);
        }

        public ActionResult OrderDetail(long id)
        {
            var order = _orderAdminServices.GetOrder(id);
            ViewBag.clientAccount = _clientAccounts.SingleOrDefault(x => x.Id.Equals(order.ClientAccountId));
            var orderInforsList = _orderAdminServices.GetOrderInfors(id);
            List<OrderProduct> orderProducts = new List<OrderProduct>();
            foreach (var infor in orderInforsList)
            {
                var product = new OrderProduct(infor.IdProduct, infor.Quantity);
                orderProducts.Add(product);
            }
            ViewBag.OrderProducts = orderProducts;
            return View(order);
        }

        [HttpPost]
        public JsonResult UpdateOrder(ShippingAddress shippingAddress, int idStatus, long orderId)
        {
            if(orderId == 0)
            {
                return Json(new
                {
                    status = false
                });
            }
            var order = _orderAdminServices.GetOrder(orderId);
            order.IdStatus = idStatus;
            var result = _orderAdminServices.UpdateOrder(order, shippingAddress);

            return Json(new {
                status = result
            });
        }
    }
}