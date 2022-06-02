using Rental_House_Backend.Data;
using Rental_House_Backend.Models;

namespace Rental_House_Backend.Services
{
    public class BookingService : IBookingService
    {
        private readonly RentalHouseDbContext bookingContext;

        public BookingService(RentalHouseDbContext rentalHouseDbContext_)
        {
            this.bookingContext = rentalHouseDbContext_;
        }
        public bool AddBooking(Booking booking)
        {
            bookingContext.Booking.Add(booking);
            Room room = bookingContext.Room.FirstOrDefault(x => x.Id == booking.Room);
            room.State = "Đã Đặt";
            bookingContext.Room.Update(room);
            bookingContext.SaveChanges();
            return true;
        }

        public bool ChangeState(int id)
        {
            var booking = GetBooking(id);
            if(booking == null)
            {
                return false;
            }

            booking.Status = true;
            bookingContext.Update(booking);
            bookingContext.SaveChanges();
            return true;
        }

        public Booking GetBooking(int id)
        {
            return bookingContext.Booking.FirstOrDefault(x => x.Id == id);
        }

        public List<Booking> GetBookings()
        {
            return bookingContext.Booking.ToList();
        }

        public bool RemoveBooking(int id)
        {
            var booking = GetBooking(id);
            bookingContext.Booking.Remove(booking);
            bookingContext.SaveChanges();
            return true;
        }

        public bool UpdateBooking(Booking booking)
        {
            bookingContext.Booking.Update(booking);
            bookingContext.SaveChanges();
            return true;
        }
    }
}
