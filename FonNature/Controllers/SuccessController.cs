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
        private readonly IClientAccountRepository _clientAccountRepository;
        public SuccessController(IOrderRepository orderRepository, IBookingRepository bookingRepository, IClientAccountRepository clientAccountRepository)
        {
            _orderRepository = orderRepository;
            _bookingRepository = bookingRepository;
            _clientAccountRepository = clientAccountRepository;
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

        public ActionResult RegisterSuccess(string email)
        {
            if(string.IsNullOrWhiteSpace(email))
            {
                return Redirect("/");
            }

            if(!_clientAccountRepository.IsExistEmail(email))
            {
                return Redirect("/");
            }

            ViewBag.Email = email;
            return View();
        }
    }
}