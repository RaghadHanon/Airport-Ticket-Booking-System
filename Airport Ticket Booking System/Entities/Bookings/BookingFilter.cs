using Airport_Ticket_Booking_System.Entites.FlightManagment;
using Airport_Ticket_Booking_System.Presentation;

namespace Airport_Ticket_Booking_System.Entites.BookingManagement;
public static class BookingFilter
{
    public static void ShowBookings()
    {
        string bookings = BookPrinter.PrintBookings(BookingQuery.GetAll(), $"Bookings List:\n ");
        Console.WriteLine(bookings);
    }
    public static void ShowBookingsByPassenger(int passengerId)
    {
        string bookings = BookPrinter.PrintBookings(BookingQuery.GetByPassenger(passengerId), $"Bookings by Passenger {passengerId}:\n ");
        Console.WriteLine(bookings);
    }
    public static void ShowBookingsByFlight(int flightId)
    {
        string bookings = BookPrinter.PrintBookings(BookingQuery.GetByFlight(flightId), $"Bookings on flight { flightId}:\n ");
        Console.WriteLine(bookings);
    }
    public static void ShowBookingsByClassFlight(ClassOfFlight classOfFlight)
    {
        string bookings = BookPrinter.PrintBookings(BookingQuery.GetByClassFlight(classOfFlight), $"{classOfFlight} Class Bookings:\n ");
        Console.WriteLine(bookings);
    }
    
    public static void ShowBookingsByDate(DateTime date)
    {
        string bookings = BookPrinter.PrintBookings(BookingQuery.GetAll(date), $"Bookings on flights departing after {date}:\n ");
        Console.WriteLine(bookings);
    }

    public static void ShowBookingsByPrice(decimal price)
    {
        string bookings = BookPrinter.PrintBookings(BookingQuery.GetByPrice(price), $"Bookings matching the price {price}:\n ");
        Console.WriteLine(bookings);
    }

    public static void ShowBookingsByDepartureCountry(string departureCountry)
    {
        string bookings = BookPrinter.PrintBookings(BookingQuery.GetByDepartureCountry(departureCountry), $"Available bookings on flights departing from {departureCountry}:\n ");
        Console.WriteLine(bookings);
    }


    public static void ShowBookingsByDestinationCountry(string destinationCountry)
    {
        string bookings = BookPrinter.PrintBookings(BookingQuery.GetByDestinationCountry(destinationCountry), $"Available bookings on flights to {destinationCountry}:\n ");
        Console.WriteLine(bookings);
    }

    public static void ShowBookingsByDepartureAirport(string departureAirport)
    {
        string bookings = BookPrinter.PrintBookings(BookingQuery.GetByDepartureAirport(departureAirport), $"Available flights departing from {departureAirport} Airport:\n ");
        Console.WriteLine(bookings);
    }

    public static void ShowFlightsByArrivalAirport(string arrivalAirport)
    {
        string bookings = BookPrinter.PrintBookings(BookingQuery.GetByArrivalAirport(arrivalAirport), $"Available flights departing from {arrivalAirport} Airport:\n ");
        Console.WriteLine(bookings);
    }
        
}