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
    public DateTime BookingDate { get; init; }
    public Book(ClassOfFlight classOfFlight, Flight flgiht, Passenger passenger)
    {

        _id = ++_currentId;
        ClassOfFlight = classOfFlight;
        Flight = flgiht;
        Passenger = passenger;
        BookingDate = DateTime.Now;
    }

    public override string? ToString()
    {
        return $"{{\n BookId {Id}: ,\n Booked Class: \"{ClassOfFlight}\",\n Price: {Flight.ClassPriceMap[ClassOfFlight]}$,\r\n {Passenger},\r\n{Flight} \n Booking Date: {BookingDate}\n}}";
    }
}
