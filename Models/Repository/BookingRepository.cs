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

        public List<Booking> GetBookingsByClientIds(List<long> ids)
        {
            try
            {
                if(ids == null || !ids.Any())
                {
                    return new List<Booking>();
                }

                return _db.Bookings.Where(x => ids.Contains(x.ClientAccountId)).ToList();
            }
            catch (Exception e)
            {
                log.Error($"Error at Get Benefits {nameof(BookingRepository)}: {e.Message}");
                return new List<Booking>();
            }
        }

        public List<Room> GetRooms()
        {
            try
            {
                return _db.Rooms.ToList();
            }
            catch (Exception e)
            {
                log.Error($"Error at Get Room from  BookingRepository {nameof(BookingRepository)}: {e.Message}");
                return new List<Room>();
            }
        }

        public List<Booking> GetBookingsByDate(DateTime date)
        {
            try
            {
                if(date == null)
                {
                    return new List<Booking>();
                }
                var bookings = _db.Bookings.ToList();
                return bookings.Where(x => x.ArrivalTime.Date.Equals(date.Date)).ToList();
            }
            catch (Exception e)
            {
                log.Error($"Error at GetBookingsByDate from {nameof(BookingRepository)}: {e.Message}");
                return new List<Booking>();
            }
        }

        public List<Room> GetAvailableRooms(DateTime date, int periodTime)
        {
            try
            {
                if(date == null || date.Equals(DateTime.MinValue) || periodTime == 0)
                {
                    return new List<Room>();
                }

                var roomList = _db.Rooms.ToList();
                if (roomList == null || !roomList.Any())
                {
                    return new List<Room>();
                }

                var bookings = _db.Bookings.ToList();
                var bookingsByDateAndTime = bookings.Where(x => !x.IsCancel && x.ArrivalTime.ToString("dd/MM/yyyy").Equals(date.ToString("dd/MM/yyyy")) && x.PeriodTime.Equals(periodTime)).ToList();

                if (bookingsByDateAndTime == null || !bookingsByDateAndTime.Any())
                {
                    return _db.Rooms.ToList();
                }

                var rooms = _db.Rooms.ToList();
                return rooms.Where(room=> !bookingsByDateAndTime.Any(booking=> booking.RoomId.Equals(room.Id))).ToList();
            }
            catch (Exception e)
            {
                log.Error($"Error at Get GetAvailableRooms from {nameof(BookingRepository)}: {e.Message}");
                return new List<Room>();
            }
        }

        public List<int> GetAvailabePeriodTime(DateTime date, List<int> periodTimes)
        {
            try
            {
                if (date == null || date.Equals(DateTime.MinValue) || periodTimes == null || !periodTimes.Any
                    ())
                {
                    return new List<int>();
                }

                var results = new List<int>();
                foreach(var time in periodTimes)
                {
                    var room = GetAvailableRooms(date, time);
                    if(room != null && room.Any())
                    {
                        results.Add(time);
                    }
                }

                return results;
            }
            catch (Exception e)
            {
                log.Error($"Error at Get GetAvailabePeriodTime from {nameof(BookingRepository)}: {e.Message}");
                return new List<int>();
            }
        }

        public void CancelBooking(long id)
        {
            try
            {
                if(id == 0)
                {
                    return;
                }

                var bookingCanceled = _db.Bookings.Find(id);
                if(bookingCanceled == null)
                {
                    log.Error($"Error at Get CancelBooking from {nameof(BookingRepository)}: Cannot find booking!");
                    return;
                }

                bookingCanceled.IsCancel = true;
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                log.Error($"Error at Get CancelBooking from {nameof(BookingRepository)}: {e.Message}");
                return;
            }
        }
    }
}
