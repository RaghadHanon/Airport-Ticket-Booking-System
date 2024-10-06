using Airport_Ticket_Booking_System.Entities.Bookings.Core;

namespace Airport_Ticket_Booking_System.Entities.Bookings.Repository;
public interface IBookingRepository
{
    public List<Book> Bookings { get; set; }
    public void AddBooking(Book booking);
    public void RemoveBooking(Book booking);
}