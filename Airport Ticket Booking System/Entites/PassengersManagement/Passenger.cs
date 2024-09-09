using Airport_Ticket_Booking_System.Entites.BookingManagement;
using Airport_Ticket_Booking_System.Entites.FlightManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.Entites.PassengersManager;

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
 
    public override string? ToString()
    {
        return $"PassengerId {Id}: \" {Name} \"";
    }
}

