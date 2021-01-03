using FonNature.Filter;
using FonNature.Services;
using Models.Entity;
using Models.Repository;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FonNature.Areas.Admin.Controllers
{
    [AuthData]
    public class BookingAdminController : Controller
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IClientAccountRepository _clientRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IBookingService _bookingService;

        public BookingAdminController(IBookingRepository bookingRepository, IClientAccountRepository clientRepository, IServiceRepository serviceRepository, IBookingService bookingService)
        {
            _bookingRepository = bookingRepository;
            _clientRepository = clientRepository;
            _serviceRepository = serviceRepository;
            _bookingService = bookingService;
        }
        // GET: Admin/BookingAdmin
        public ActionResult Index(int? page, string searchString = null)
        {
            var bookings = _bookingRepository.GetBookings();
            
            if (!string.IsNullOrEmpty(searchString))
            {
                var clients = _clientRepository.SearchClient(searchString);
                if(clients != null && clients.Any())
                {
                    bookings = _bookingRepository.GetBookingsByClientIds(clients.Select(x => x.Id).ToList());
                }
                else    
                {
                    bookings = new List<Booking>();
                }
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            if (bookings != null && bookings.Any())
            {
                bookings = bookings.OrderByDescending(x => x.ArrivalTime).ToList();
            }
            var pagedServices = bookings.ToPagedList(pageNumber, pageSize);
            ViewBag.SearchString = searchString ?? string.Empty;
            ViewBag.Clients = _clientRepository.GetClientAccounts();
            ViewBag.Services = _serviceRepository.GetServices();
            ViewBag.Rooms = _bookingRepository.GetRooms();
            return View(pagedServices);
        }

        public ActionResult Book()
        {
            var bookings = _bookingRepository.GetBookingsByDate(DateTime.Now);
            var dateQuery = Request.QueryString["date"];
            if(!string.IsNullOrWhiteSpace(dateQuery))
            {
                DateTime.TryParse(dateQuery, out var dateParsed);
                if(dateParsed != DateTime.MinValue)
                {
                    bookings = _bookingRepository.GetBookingsByDate(dateParsed);
                    ViewBag.SelectedDate = dateParsed;
                }
            }

            var rooms = _bookingRepository.GetRooms();
            ViewBag.Bookings = bookings;
            ViewBag.ServiceList = _serviceRepository.GetServices();

            return View(rooms);
        }

        [HttpPost]
        public ActionResult Book(ClientAccount clientAccount, int roomId, int periodTime, string date, long serviceId)
        {
            if(clientAccount != null && roomId != 0 && periodTime != 0 && !string.IsNullOrWhiteSpace(date))
            {
                var bookingId = _bookingService.BookServiceForAdmin(clientAccount, roomId, periodTime, date, serviceId);
                if (bookingId == 0)
                {
                    ModelState.AddModelError("", "Cannot add booking because system error ! Please contact admin !");
                }
                else
                {
                    return RedirectToAction("Book");
                }  
            }

            var bookings = _bookingRepository.GetBookingsByDate(DateTime.Now);
            var dateQuery = date;
            if (!string.IsNullOrWhiteSpace(dateQuery))
            {
                DateTime.TryParse(dateQuery, out var dateParsed);
                if (dateParsed != DateTime.MinValue)
                {
                    bookings = _bookingRepository.GetBookingsByDate(dateParsed);
                    ViewBag.SelectedDate = dateParsed;
                }
            }
            var rooms = _bookingRepository.GetRooms();
            ViewBag.Bookings = bookings;
            return View(rooms);
        }

        [HttpPost]
        public JsonResult GetBookingInfo(string bookingId)
        {
            if(string.IsNullOrWhiteSpace(bookingId))
            {
                return Json(new { isError = true, meassage = "System Error!" });
            }

            long.TryParse(bookingId, out var bookingIdParsed);
            if(bookingIdParsed == 0)
            {
                return Json(new { isError = true, meassage = "System Error!" });
            }

            var booking = _bookingRepository.GetBooking(bookingIdParsed);
            if (booking == null)
            {
                return Json(new { isError = true, meassage = "System Error!" });
            }

            var client = _clientRepository.GetClientAccount(booking.ClientAccountId);
            if(client == null)
            {
                return Json(new { isError = true, meassage = "System Error!" });
            }

            return Json(new { isError = false, result = client });
        }

        [HttpPost]
        public JsonResult GetClientInfo(string mobilePhone)
        {
            if (string.IsNullOrWhiteSpace(mobilePhone))
            {
                return Json(new { isError = true, meassage = "System Error!" });
            }

            var clientInfo = _clientRepository.GetClientByPhone(mobilePhone);
            if (clientInfo == null)
            {
                return Json(new { isError = true, meassage = "System Error!" });
            }

            return Json(new { isError = false, result = clientInfo });
        }

        [HttpGet]
        public ActionResult CancelBooking(int id)
        {
            _bookingRepository.CancelBooking(id);
            return Redirect("/admin/bookingadmin/index");
        }
    }
}