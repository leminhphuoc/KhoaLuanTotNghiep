using Models.Repository;
using System.Web.Mvc;

namespace FonNature.Controllers
{
    [RoutePrefix("success")]
    [Route("{action=SuccessPage}")]
    public class SuccessController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        public SuccessController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // GET: Success
        public ActionResult SuccessPage(string message)
        {
            ViewBag.message = message;
            return View();
        }

        public ActionResult OrderSuccessPage(long orderID)
        {
            var order = _orderRepository.GetOrder(orderID);
            if(order== null)
            {
                return Redirect("/");
            }

            ViewBag.orderID = orderID;
            return View();
        }
    }
}