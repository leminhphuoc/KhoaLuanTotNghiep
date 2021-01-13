using FonNature.Common;
using FonNature.Filter;
using Models.Repository;
using System;
using System.Web.Mvc;
using System.Linq;

namespace FonNature.Areas.Admin.Controllers
{
    [AuthData]
    public class HomeAdminController : Controller
    {
        private readonly IClientAccountRepository _clientAccountRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IOrderRepository _orderRepository;
        public HomeAdminController(IClientAccountRepository clientAccountRepository, IBookingRepository bookingRepository, IServiceRepository serviceRepository, IOrderRepository orderRepository)
        {
            _clientAccountRepository = clientAccountRepository;
            _bookingRepository = bookingRepository;
            _serviceRepository = serviceRepository;
            _orderRepository = orderRepository;
        }

        //GET: Admin/HomeAdmin
        public ActionResult HomeAdmin()
        {
            ViewBag.Visitor = new IPAddressRepository().CountVisitor();

            ViewBag.CountVisitor = new IPAddressRepository().CountByMonth(DateTime.Now.Month);
            ViewBag.CountVisitor1 = new IPAddressRepository().CountByMonth(DateTime.Now.AddMonths(-1).Month);
            ViewBag.CountVisitor2 = new IPAddressRepository().CountByMonth(DateTime.Now.AddMonths(-2).Month);
            ViewBag.CountVisitor3 = new IPAddressRepository().CountByMonth(DateTime.Now.AddMonths(-3).Month);
            ViewBag.CountVisitor4 = new IPAddressRepository().CountByMonth(DateTime.Now.AddMonths(-4).Month);
            ViewBag.CountVisitor5 = new IPAddressRepository().CountByMonth(DateTime.Now.AddMonths(-5).Month);
            ViewBag.CountVisitor6 = new IPAddressRepository().CountByMonth(DateTime.Now.AddMonths(-6).Month);
            ViewBag.CountVisitor7 = new IPAddressRepository().CountByMonth(DateTime.Now.AddMonths(-7).Month);
            ViewBag.CountVisitor8 = new IPAddressRepository().CountByMonth(DateTime.Now.AddMonths(-8).Month);

            var bookings = _bookingRepository.GetBookings();
            var services = _serviceRepository.GetServices();
            var customers = _clientAccountRepository.GetClientAccounts();
            var orders = _orderRepository.GetOrders();

            ViewBag.BookingQuantity = bookings.Count;
            ViewBag.ServiceQuantity = services.Count;
            ViewBag.CustomerQuantity = customers.Count;
            ViewBag.OrderQuantity = orders.Count;


            ViewBag.CountBooking1 = bookings.Count(x => x.ArrivalTime != DateTime.MinValue && x.ArrivalTime.Equals(DateTime.Now.AddMonths(-1)));
            ViewBag.CountBooking2 = bookings.Count(x => x.ArrivalTime != DateTime.MinValue && x.ArrivalTime.Equals(DateTime.Now.AddMonths(-2)));
            ViewBag.CountBooking3 = bookings.Count(x => x.ArrivalTime != DateTime.MinValue && x.ArrivalTime.Equals(DateTime.Now.AddMonths(-3)));
            ViewBag.CountBooking4 = bookings.Count(x => x.ArrivalTime != DateTime.MinValue && x.ArrivalTime.Equals(DateTime.Now.AddMonths(-4)));
            ViewBag.CountBooking5 = bookings.Count(x => x.ArrivalTime != DateTime.MinValue && x.ArrivalTime.Equals(DateTime.Now.AddMonths(-5)));
            ViewBag.CountBooking6 = bookings.Count(x => x.ArrivalTime != DateTime.MinValue && x.ArrivalTime.Equals(DateTime.Now.AddMonths(-6)));
            ViewBag.CountBooking7 = bookings.Count(x => x.ArrivalTime != DateTime.MinValue && x.ArrivalTime.Equals(DateTime.Now.AddMonths(-7)));
            ViewBag.CountBooking8 = bookings.Count(x => x.ArrivalTime != DateTime.MinValue && x.ArrivalTime.Equals(DateTime.Now.AddMonths(-8)));


            ViewBag.CountCustomer1 = customers.Count(x => x.CreatedDate != DateTime.MinValue && x.CreatedDate.Equals(DateTime.Now.AddMonths(-1)));
            ViewBag.CountCustomer2 = customers.Count(x => x.CreatedDate != DateTime.MinValue && x.CreatedDate.Equals(DateTime.Now.AddMonths(-2)));
            ViewBag.CountCustomer3 = customers.Count(x => x.CreatedDate != DateTime.MinValue && x.CreatedDate.Equals(DateTime.Now.AddMonths(-3)));
            ViewBag.CountCustomer4 = customers.Count(x => x.CreatedDate != DateTime.MinValue && x.CreatedDate.Equals(DateTime.Now.AddMonths(-4)));
            ViewBag.CountCustomer5 = customers.Count(x => x.CreatedDate != DateTime.MinValue && x.CreatedDate.Equals(DateTime.Now.AddMonths(-5)));
            ViewBag.CountCustomer6 = customers.Count(x => x.CreatedDate != DateTime.MinValue && x.CreatedDate.Equals(DateTime.Now.AddMonths(-6)));
            ViewBag.CountCustomer7 = customers.Count(x => x.CreatedDate != DateTime.MinValue && x.CreatedDate.Equals(DateTime.Now.AddMonths(-7)));
            ViewBag.CountCustomer8 = customers.Count(x => x.CreatedDate != DateTime.MinValue && x.CreatedDate.Equals(DateTime.Now.AddMonths(-8)));

            ViewBag.CountOrder1 = orders.Count(x => x.createdDate != DateTime.MinValue && x.createdDate.Equals(DateTime.Now.AddMonths(-1)));
            ViewBag.CountOrder2 = orders.Count(x => x.createdDate != DateTime.MinValue && x.createdDate.Equals(DateTime.Now.AddMonths(-2))); 
            ViewBag.CountOrder3 = orders.Count(x => x.createdDate != DateTime.MinValue && x.createdDate.Equals(DateTime.Now.AddMonths(-3))); 
            ViewBag.CountOrder4 = orders.Count(x => x.createdDate != DateTime.MinValue && x.createdDate.Equals(DateTime.Now.AddMonths(-4))); 
            ViewBag.CountOrder5 = orders.Count(x => x.createdDate != DateTime.MinValue && x.createdDate.Equals(DateTime.Now.AddMonths(-5))); 
            ViewBag.CountOrder6 = orders.Count(x => x.createdDate != DateTime.MinValue && x.createdDate.Equals(DateTime.Now.AddMonths(-6))); 
            ViewBag.CountOrder7 = orders.Count(x => x.createdDate != DateTime.MinValue && x.createdDate.Equals(DateTime.Now.AddMonths(-7))); 
            ViewBag.CountOrder8 = orders.Count(x => x.createdDate != DateTime.MinValue && x.createdDate.Equals(DateTime.Now.AddMonths(-8))); 

            return View();
        }

        public ActionResult Logout()
        {
            Session[CommonConstants.UserSession.USER_SESSION_ADMIN] = null;
            return Redirect("/admin");
        }
    }
}