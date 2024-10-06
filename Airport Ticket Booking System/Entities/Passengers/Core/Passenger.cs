using Airport_Ticket_Booking_System.Entities.Bookings.Core;

namespace Airport_Ticket_Booking_System.Entities.Passengers.Core;
public class Passenger
{
    private static int _currentId = 0;
    private int _id;
    public Passenger(string name)
    {
        _id = ++_currentId;
        Name = name;
    }
    public int Id { get { return _id; }  set{ _id = value; } }
    public List<Book> Bookings { get; } = new List<Book>();
    public string Name { get; set; }
}

