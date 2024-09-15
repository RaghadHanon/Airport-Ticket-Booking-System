using Airport_Ticket_Booking_System.Entities.Flights;
using Airport_Ticket_Booking_System.Entities.Passenegers;

namespace Airport_Ticket_Booking_System.Entities.Bookings;
public class Book
{
    private static int _currentId = 0;
    private readonly int _id;
    public Book(ClassOfFlight? classOfFlight, Flight? flight, Passenger? passenger)
    {
        _id = ++_currentId;
        ClassOfFlight = classOfFlight;
        Flight = flight;
        Passenger = passenger;
        BookingDate = DateTime.UtcNow;
    }
    public int Id { get { return _id; } }
    public ClassOfFlight? ClassOfFlight { get; set; }
    public Flight? Flight { get; set; }
    public Passenger? Passenger { get; set; }
    public DateTime? BookingDate { get; init; }
    
}
