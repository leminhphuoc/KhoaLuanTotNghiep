using FonNature.Filter;
using FonNature.Services;
using Models.Entity;
using Models.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        public ActionResult Index(long serviceId = 0)
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
            if(serviceId != 0)
            {
                ViewBag.SelectedService = serviceId;
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Book(Booking booking, string startTime)
        {
            DateTime.TryParseExact(startTime, "MM/dd/yyyy" , CultureInfo.InvariantCulture, DateTimeStyles.None ,out var arrivalTimeParsed);
            if(arrivalTimeParsed != DateTime.MinValue)
            {
                booking.ArrivalTime = arrivalTimeParsed;
            }

            var account = Session[Constant.Membership.AccountSession] as ClientAccount;
            if (account == null)
            {
                return Redirect("/");
            }

            var availableTimes = _repository.GetAvailabePeriodTime(booking.ArrivalTime, Constant.TimeRanges.Keys.ToList());
            if (!availableTimes.Any(x=>x.Equals(booking.PeriodTime)))
            {
                ModelState.AddModelError("", "This arrival time was selected is full booking!");
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
                else
                {
                    ModelState.AddModelError("", "Cannot book service because system error!");
                }
            }
            ViewBag.TimeRangeId = booking.PeriodTime;
            ViewBag.Services = _serviceRepository.GetServices();
            return View("Index");
        }

        [HttpPost]
        public JsonResult GetAvailablePeriodTimes(string date)
        {
            if (string.IsNullOrWhiteSpace(date))
            {
                return Json( new { isError = true , message = "date is null!" });
            }

            DateTime.TryParse(date, out var dateParsed);
            if(dateParsed.Equals(DateTime.MinValue))
            {
                return Json(new { isError = true, message = "Cannot parsed!", date = date });
            }

            var results = _repository.GetAvailabePeriodTime(dateParsed, Constant.TimeRanges.Keys.ToList());

            return Json(new
            {
                isError = false,
                message = "Success!",
                results = results
            }
            );
        }
    }
}