using Airport_Ticket_Booking_System.Entities.Bookings.Core;

namespace Airport_Ticket_Booking_System.Entities.Bookings.Repository;
public class BookingRepository : IBookingRepository
{
    public List<Book> Bookings { get; set; } = new List<Book>();
    public void AddBooking(Book booking)
    {
        Bookings.Add(booking);
    }

    public void RemoveBooking(Book booking)
    {
        Bookings.Remove(booking);
    }
}