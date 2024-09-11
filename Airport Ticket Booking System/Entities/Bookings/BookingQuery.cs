using Airport_Ticket_Booking_System.Entites.FlightManagment;
using Airport_Ticket_Booking_System.Entites.PassengersManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.Entites.BookingManagement;
public static class BookingQuery
{
    public static List<Book> Bookings { get; } = new List<Book>();
   
    public static Book? GetById(int id)
    {
        return Bookings.FirstOrDefault(b => b.Id == id);
    }

    public static List<Book> GetAll(DateTime? date = null)
    {
        if (date.HasValue)
            return Bookings.Where(b => b.Flight.DepartureDate?.CompareTo(date) >= 0).ToList();

        return Bookings;
    }
    
    public static List<Book> GetByPassenger(int id)
    {
        return Bookings.Where(b => b.Passenger.Id == id).ToList();
    }
    public static List<Book> GetByFlight(int id)
    {
        return Bookings.Where(b => b.Flight.Id == id).ToList();
    }
    public static List<Book> GetByClassFlight(ClassOfFlight classOfFlight)
    {
        return Bookings.Where(b => b.ClassOfFlight == classOfFlight).ToList();
    }

    public static List<Book> GetByPrice(decimal price, DateTime? date = null)
    {
        if (date.HasValue)
            return Bookings.Where(b => b.Flight.ClassPriceMap[(ClassOfFlight)b.ClassOfFlight] == price && b.Flight.DepartureDate?.CompareTo(date) >= 0).ToList();

        return Bookings.Where(b => b.Flight.ClassPriceMap[(ClassOfFlight)b.ClassOfFlight] == price).ToList();
    }

    public static List<Book> GetByDepartureCountry(string departureCountry, DateTime? date = null)
    {
        if (date.HasValue)
            return Bookings.Where(b => b.Flight.DepartureCountry == departureCountry && b.Flight.DepartureDate?.CompareTo(date) >= 0).ToList();

        return Bookings.Where(b => b.Flight.DepartureCountry == departureCountry).ToList();
    }
    
    public static List<Book> GetByDestinationCountry(string destinationCountry, DateTime? date = null)
    {
        if (date.HasValue)
            return Bookings.Where(b => b.Flight.DestinationCountry == destinationCountry && b.Flight.DepartureDate?.CompareTo(date) >= 0).ToList();

        return Bookings.Where(b => b.Flight.DestinationCountry == destinationCountry).ToList();
    }
    

    public static List<Book> GetByDepartureDate(DateTime departureDate)
    {
        return Bookings.Where(b => b.Flight.DepartureDate == departureDate).ToList();
    }
    public static List<Book> GetByDepartureAirport(string departureAirport, DateTime? date = null)
    {
        if (date.HasValue)
            return Bookings.Where(b => b.Flight.DepartureAirport == departureAirport && b.Flight.DepartureDate?.CompareTo(date) >= 0).ToList();

        return Bookings.Where(b => b.Flight.DepartureAirport == departureAirport).ToList();
    }

    public static List<Book> GetByArrivalAirport(string arrivalAirport, DateTime? date = null)
    {
        if (date.HasValue)
            return Bookings.Where(b => b.Flight.ArrivalAirport == arrivalAirport && b.Flight.DepartureDate?.CompareTo(date) >= 0).ToList();
        return Bookings.Where(b => b.Flight.ArrivalAirport == arrivalAirport).ToList();
    }

    


}

