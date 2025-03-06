using Airport_Ticket_Booking_System.Entities.Bookings.Query;
using Airport_Ticket_Booking_System.Entities.Flights.Core;
using Airport_Ticket_Booking_System.Presentation.EntitiesPrinters;

namespace Airport_Ticket_Booking_System.Entities.Bookings.Filter;
public class BookingFilter : IBookingFilter
{
    public IBookingQuery BookingQuery { get; }
    public BookingFilter(IBookingQuery bookingQuery)
    {
        BookingQuery = bookingQuery;
    }

    public void ShowBookings()
    {
        var bookings = BookPrinter.PrintBookings(BookingQuery.FilterBookings(), $"Bookings List:\n ");
        Console.WriteLine(bookings);
    }

    public void ShowBookingsByPassenger(int passengerId)
    {
        var bookings = BookPrinter.PrintBookings(BookingQuery.FilterBookings(passengerId: passengerId), $"Bookings by Passenger {passengerId}:\n ");
        Console.WriteLine(bookings);
    }

    public void ShowBookingsByFlight(int flightId)
    {
        var bookings = BookPrinter.PrintBookings(BookingQuery.FilterBookings(flightId: flightId), $"Bookings on flight {flightId}:\n ");
        Console.WriteLine(bookings);
    }

    public void ShowBookingsByClassFlight(ClassOfFlight classOfFlight)
    {
        var bookings = BookPrinter.PrintBookings(BookingQuery.FilterBookings(classOfFlight: classOfFlight), $"{classOfFlight} Class Bookings:\n ");
        Console.WriteLine(bookings);
    }

    public void ShowBookingsByDate(DateTime date)
    {
        var bookings = BookPrinter.PrintBookings(BookingQuery.FilterBookings(departureDate: date), $"Bookings on flights departing at {date}:\n ");
        Console.WriteLine(bookings);
    }

    public void ShowBookingsAfterDate(DateTime date)
    {
        var bookings = BookPrinter.PrintBookings(BookingQuery.FilterBookings(afterDate: date), $"Bookings on flights departing after {date}:\n ");
        Console.WriteLine(bookings);
    }

    public void ShowBookingsByPrice(decimal price)
    {
        var bookings = BookPrinter.PrintBookings(BookingQuery.FilterBookings(price: price), $"Bookings matching the price {price}:\n ");
        Console.WriteLine(bookings);
    }

    public void ShowBookingsByDepartureCountry(string departureCountry)
    {
        var bookings = BookPrinter.PrintBookings(BookingQuery.FilterBookings(departureCountry: departureCountry), $"Available bookings on flights departing from {departureCountry}:\n ");
        Console.WriteLine(bookings);
    }

    public void ShowBookingsByDestinationCountry(string destinationCountry)
    {
        var bookings = BookPrinter.PrintBookings(BookingQuery.FilterBookings(destinationCountry: destinationCountry), $"Available bookings on flights to {destinationCountry}:\n ");
        Console.WriteLine(bookings);
    }

    public void ShowBookingsByDepartureAirport(string departureAirport)
    {
        var bookings = BookPrinter.PrintBookings(BookingQuery.FilterBookings(departureAirport: departureAirport), $"Available flights departing from {departureAirport} Airport:\n ");
        Console.WriteLine(bookings);
    }

    public void ShowFlightsByArrivalAirport(string arrivalAirport)
    {
        var bookings = BookPrinter.PrintBookings(BookingQuery.FilterBookings(arrivalAirport: arrivalAirport), $"Available flights departing from {arrivalAirport} Airport:\n ");
        Console.WriteLine(bookings);
    }
}