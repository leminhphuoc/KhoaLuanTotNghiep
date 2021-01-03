using Models.Entity;

namespace FonNature.Services
{
    public interface IBookingService
    {
        long BookService(Booking booking);
        long BookServiceForAdmin(ClientAccount clientAccount, int roomId, int periodTimeId, string date, long serviceId);
    }
}
