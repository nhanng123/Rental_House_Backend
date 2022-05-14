using Rental_House_Backend.Models;

namespace Rental_House_Backend.Services
{
    public interface IBookingService
    {
        List<Booking> GetBookings();
        Booking GetBooking(int id);
        Boolean AddBooking(Booking booking);
        Boolean UpdateBooking(Booking booking);
        Boolean RemoveBooking(int id);
        Boolean ChangeState(int id);
    }
}
