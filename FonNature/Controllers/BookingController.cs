using FonNature.Filter;
using FonNature.Services;
using Models.Entity;
using Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FonNature.Controllers
{
    [RoutePrefix("booking")]
    [Route("{action=Index}")]
    public class BookingController : Controller
    {
        private readonly IBookingService _service;
        private readonly IBookingRepository _repository;
        private readonly IServiceRepository _serviceRepository;

        public BookingController(IBookingService service, IBookingRepository repository, IServiceRepository serviceRepository)
        {
            _service = service;
            _repository = repository;
            _serviceRepository = serviceRepository;
        }

        [AuthenticationClient]
        public ActionResult Index()
        {
            var isLogin = false;
            if(Session[Constant.Membership.IsLoginSession] != null)
            {
                isLogin = Session[Constant.Membership.IsLoginSession] != null;
            }
            if(!isLogin)
            {
                return Redirect("/");
            }
            ViewBag.Services = _serviceRepository.GetServices();

            return View();
        }

        [HttpPost]
        public ActionResult Book(Booking booking)
        {
            var account = Session[Constant.Membership.AccountSession] as ClientAccount;
            if (account == null)
            {
                return Redirect("/");
            }

            if (ModelState.IsValid)
            {
                var timeRange = Constant.TimeRanges.FirstOrDefault(x => x.Key.Equals(booking.PeriodTime)).Value;
                booking.ClientAccountId = account.Id;
                booking.ArrivalTime = booking.ArrivalTime.AddHours(timeRange.Hour);
                booking.ArrivalTime = booking.ArrivalTime.AddMinutes(timeRange.Minute);
                var bookingId = _service.BookService(booking);
                if(bookingId != 0)
                {
                    return RedirectToAction("BookingSuccessPage", "Success", new { bookingId = bookingId });
                }
            }
            ViewBag.TimeRangeId = booking.PeriodTime;
            ViewBag.Services = _serviceRepository.GetServices();
            return View("Index");
        }
    }
}