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
        private readonly IClientAccountRepository _clientAccountRepository;
        public BookingService(IServiceRepository serviceRepository, IBookingRepository bookingRepository, IClientAccountRepository clientAccountRepository)
        {
            _serviceRepository = serviceRepository;
            _bookingRepository = bookingRepository;
            _clientAccountRepository = clientAccountRepository;
        }

        public long BookService(Booking booking)
        {
            if (booking == null)
            {
                return 0;
            }

            var availableRooms = _bookingRepository.GetAvailableRooms(booking.ArrivalTime.Date, booking.PeriodTime);
            if (availableRooms == null || !availableRooms.Any())
            {
                return 0;
            }

            booking.RoomId = availableRooms.FirstOrDefault().Id;
            var service = _serviceRepository.GetService(booking.ServiceId);
            var duration = service != null ? service.Duration : 0;
            booking.EndTime = booking.ArrivalTime.AddMinutes(duration);
            booking.Duration = duration;
            var bookingId = _bookingRepository.AddBooking(booking);

            return bookingId;
        }
        public long BookServiceForAdmin(ClientAccount clientAccount, int roomId, int periodTimeId, string date, long serviceId)
        {
            if(clientAccount == null || roomId == 0 || periodTimeId == 0 || string.IsNullOrWhiteSpace(date) || serviceId == 0)
            {
                return 0;
            }

            var existedClient = _clientAccountRepository.GetClientByPhone(clientAccount.MobilePhone);

            var accountId = (long)0;
            if (existedClient == null)
            {
                accountId = _clientAccountRepository.AddPremember(clientAccount);
            }
            else
            {
                accountId = existedClient.Id;
            }

            DateTime.TryParse(date, out var dateParsed);

            var booking = new Booking()
            {
                ClientAccountId = accountId,
                ArrivalTime = dateParsed,
                PeriodTime = periodTimeId,
                ServiceId = serviceId,
                RoomId = roomId
            };
            var service = _serviceRepository.GetService(booking.ServiceId);
            var duration = service != null ? service.Duration : 0;
            booking.EndTime = booking.ArrivalTime.AddMinutes(duration);
            booking.Duration = duration;

            return _bookingRepository.AddBooking(booking);
        }
    }
}