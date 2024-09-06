using Airport_Ticket_Booking_System.Entites.FlightManagment;
using Airport_Ticket_Booking_System.Entites.PassengersManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.Entites.BookingManagement;
public class Book
{
    private static int _currentId = 0;
    private readonly int _id;
    public int Id { get { return _id; } }
    public ClassOfFlight ClassOfFlight { get; set; }
    public Flight Flight { get; set; }
    public Passenger Passenger { get; set; }
    public Book(ClassOfFlight classOfFlight, Flight flgiht, Passenger passenger)
    {

        _id = ++_currentId;
        ClassOfFlight = classOfFlight;
        Flight = flgiht;
        Passenger = passenger;
    }

    public override string? ToString()
    {
        return $"Booked Id:\" {Id} \",\nBooked Class: \" {ClassOfFlight} \",\nPrice: \" {Flight.ClassPriceMap[ClassOfFlight]}$ \",\r\n{Flight}";
    }
}
