using Models.Entity;
using Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FonNature.Services
{
    public class BookingService : IBookingService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IBookingRepository _bookingRepository;
        public BookingService(IServiceRepository serviceRepository, IBookingRepository bookingRepository)
        {
            _serviceRepository = serviceRepository;
            _bookingRepository = bookingRepository;
        }

        public long BookService(Booking booking)
        {
            if(booking == null)
            {
                return 0;
            }

            var service = _serviceRepository.GetService(booking.ServiceId);
            var duration = service != null ? service.Duration : 0;
            booking.EndTime = booking.ArrivalTime.AddMinutes(duration);
            var bookingId = _bookingRepository.AddBooking(booking);

            return bookingId;
        }
    }
}