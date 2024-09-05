using Airport_Ticket_Booking_System.Entites.FlightManagment;
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

    public Book(ClassOfFlight classOfFlight, int flgihtId)
    {

        _id = ++_currentId;
        ClassOfFlight = classOfFlight;
        Flight = FlightsManager.GetById(flgihtId);
    }

    public override string? ToString()
    {
        return $"Booked Id:\" {Id} \",\nBooked Class: \" {ClassOfFlight} \",\nPrice: \" {Flight.ClassPriceMap[ClassOfFlight]}$ \",\r\n{Flight}";
    }
}
