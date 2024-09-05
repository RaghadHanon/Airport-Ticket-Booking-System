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
    public List<Book> Bookings { get; } = new List<Book>();

    private string _name;
    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be null.");
            }
            _name = value;

        }

    }

    public Passenger(string name)
    {
        _id = ++_currentId;
        Name = name;
    }

    public void ShowBooking()
    {

        Console.WriteLine($"*****************************  {Name}'s Bookings  *****************************");
        foreach (var book in Bookings)
        {
            Console.WriteLine($"{book}"); 
        }
    }
}

