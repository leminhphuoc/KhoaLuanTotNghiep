using log4net;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private FonNatureDbContext _db = null;
        public FonNatureDbContext Db { get => _db; set => _db = value; }

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BookingRepository()
        {
            _db = new FonNatureDbContext();
        }

        public long AddBooking(Booking booking)
        {
            try
            {
                var addedItem = _db.Bookings.Add(booking);
                Db.SaveChanges();
                return addedItem.Id;
            }
            catch (Exception e)
            {
                log.Error($"Error at add function from {nameof(BookingRepository)}: {e.Message}");
                return 0;
            }
        }

        public bool DeleteBooking(long id)
        {
            try
            {
                var booking = _db.Bookings.Find(id);
                _db.Bookings.Remove(booking);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                log.Error($"Error at delete function {nameof(BookingRepository)}: {e.Message}");
                return false;
            }
        }

        public bool EditBooking(Booking booking)
        {
            try
            {
                var editBooking = _db.Bookings.Find(booking.Id);
                editBooking.ArrivalTime = booking.ArrivalTime;
                editBooking.ClientAccountId = booking.ClientAccountId;
                editBooking.EndTime = booking.EndTime;
                editBooking.Message = booking.Message;
                editBooking.RoomId = booking.RoomId;
                editBooking.ServiceId = booking.ServiceId;
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                log.Error($"Error at edit function from {nameof(BookingRepository)}: {e.Message}");
                return false;
            }
        }

        public Booking GetBooking(long id)
        {
            try
            {
                var booking = _db.Bookings.Find(id);
                return booking;
            }
            catch (Exception e)
            {
                log.Error($"Error at Get Booking function from {nameof(BookingRepository)}: {e.Message}");
                return null;
            }
        }

        public List<Booking> GetBookings()
        {
            try
            {
                return _db.Bookings.ToList();
            }
            catch (Exception e)
            {
                log.Error($"Error at Get Benefits {nameof(BookingRepository)}: {e.Message}");
                return new List<Booking>();
            }
        }
    }
}
