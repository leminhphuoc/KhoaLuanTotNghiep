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
    }
}
