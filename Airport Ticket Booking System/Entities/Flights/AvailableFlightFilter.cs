using Airport_Ticket_Booking_System.Presentation;
using Airport_Ticket_Booking_System.Utilities;

namespace Airport_Ticket_Booking_System.Entities.Flights;
public static class AvailableFlightFilter
{
    public static void ShowAvailableFlights()
    {
        var flights = FlightPrinter.PrintFlights(FlightQuery.FilterFlights(afterDate : DateTime.UtcNow.AddHours(2)), $"Available flights departing after {DateTime.UtcNow.AddHours(2)}:\n ");
        Console.WriteLine(flights);
    }

    public static void ShowAvailableFlightsByDate(DateTime? date)
    {
        if (date?.CompareTo(DateTime.UtcNow.AddHours(2)) <= 0)
        {
            Console.WriteLine(ErrorMessages.SelectedDateInvalid);
            return;
        }
        var flights = FlightPrinter.PrintFlights(FlightQuery.FilterFlights(departureDate : date), $"Available flights departing at {date}:\n ");
        Console.WriteLine(flights);
    }

    public static void ShowFlightsByPrice(decimal price)
    {
        var flights = FlightQuery.FilterFlights( price : price, afterDate: DateTime.UtcNow.AddHours(2));
        if (flights.Any())
        {
            Console.WriteLine($"Available flights matching the price {price} after {DateTime.UtcNow.AddHours(2)}:\n ");
            foreach (var flight in flights)
            {
                ClassOfFlight classOfFlight = flight.ClassPriceMap.FirstOrDefault(x => x.Value == price).Key;
                Console.WriteLine($"\n \"{classOfFlight} class\" matches your specifications\n {FlightPrinter.PrintFlight(flight)}");
            }
        }
        else
        {
            Console.WriteLine("No available flights at the moment.");
        }
    }

    public static void ShowFlightsByDepartureCountry(string departureCountry)
    {
        var flights = FlightPrinter.PrintFlights(FlightQuery.FilterFlights(departureCountry : departureCountry, afterDate: DateTime.UtcNow.AddHours(2)), $"Available flights departing from {departureCountry} after {DateTime.UtcNow.AddHours(2)}:\n ");
        Console.WriteLine(flights);
    }

    public static void ShowFlightsByDestinationCountry(string destinationCountry)
    {
        var flights = FlightPrinter.PrintFlights(FlightQuery.FilterFlights(destinationCountry : destinationCountry, afterDate: DateTime.UtcNow.AddHours(2)), $"Available flights to {destinationCountry} after {DateTime.UtcNow.AddHours(2)}:\n ");
        Console.WriteLine(flights);
    }

    public static void ShowFlightsByDepartureAirport(string departureAirport)
    {
        var flights = FlightPrinter.PrintFlights(FlightQuery.FilterFlights(departureAirport : departureAirport, afterDate: DateTime.UtcNow.AddHours(2)), $"Available flights departing from {departureAirport} Airport after {DateTime.UtcNow.AddHours(2)}:\n ");
        Console.WriteLine(flights);
    }

    public static void ShowFlightsByArrivalAirport(string arrivalAirport)
    {
        var flights = FlightPrinter.PrintFlights(FlightQuery.FilterFlights(arrivalAirport : arrivalAirport, afterDate: DateTime.UtcNow.AddHours(2)), $"Available flights to {arrivalAirport} Airport after {DateTime.UtcNow.AddHours(2)}:\n ");
        Console.WriteLine(flights);
    }
}