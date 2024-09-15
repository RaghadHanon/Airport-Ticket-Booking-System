using Airport_Ticket_Booking_System.Entities.Bookings;

namespace Airport_Ticket_Booking_System.Entities.Passenegers;
public class Passenger
{
    private static int _currentId = 0;
    private readonly int _id;
    public int Id { get { return _id; } }
    public Passenger(string name)
    {
        _id = ++_currentId;
        Name = name;
    }
    public List<Book> Bookings { get; } = new List<Book>();
    public string Name { get; set; }
}

