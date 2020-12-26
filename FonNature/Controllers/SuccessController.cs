using FonNature.Filter;
using Models.Repository;
using System.Web.Mvc;

namespace FonNature.Controllers
{
    [RoutePrefix("success")]
    [Route("{action=SuccessPage}")]
    public class SuccessController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IBookingRepository _bookingRepository;
        public SuccessController(IOrderRepository orderRepository, IBookingRepository bookingRepository)
        {
            _orderRepository = orderRepository;
            _bookingRepository = bookingRepository;
        }

        // GET: Success
        public ActionResult SuccessPage(string message)
        {
            ViewBag.message = message;
            return View();
        }

        [AuthenticationClient]
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

        [AuthenticationClient]
        public ActionResult BookingSuccessPage(long bookingId)
        {
            var booking = _bookingRepository.GetBooking(bookingId);
            if (booking == null)
            {
                return Redirect("/");
            }

            ViewBag.bookingId = bookingId;
            return View();
        }
    }
}