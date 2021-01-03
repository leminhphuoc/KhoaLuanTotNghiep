using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public interface IBookingRepository
    {
        long AddBooking(Booking booking);
        bool DeleteBooking(long id);
        bool EditBooking(Booking booking);
        Booking GetBooking(long id);
        List<Booking> GetBookings();
        List<Booking> GetBookingsByClientIds(List<long> ids);
        List<Room> GetRooms();
        List<Booking> GetBookingsByDate(DateTime date);
        List<Room> GetAvailableRooms(DateTime date, int periodTime);
        List<int> GetAvailabePeriodTime(DateTime date, List<int> periodTimes);
        void CancelBooking(long id);
    }
}
