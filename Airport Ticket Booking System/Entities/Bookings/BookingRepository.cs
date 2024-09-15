namespace Airport_Ticket_Booking_System.Entities.Bookings;
public class BookingRepository
{
    private static List<Book> _bookings = new List<Book>();
    public static List<Book> Bookings { get => _bookings; }
}