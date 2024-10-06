using Airport_Ticket_Booking_System.Entities.Bookings.Query;
using Airport_Ticket_Booking_System.Entities.Flights.Core;
using Airport_Ticket_Booking_System.Entities.Flights.Query;
using Airport_Ticket_Booking_System.Presentation.EntitiesPrinters;
using Airport_Ticket_Booking_System.Utilities;

namespace Airport_Ticket_Booking_System.Entities.Flights.Filter;
public class AvailableFlightFilter : IAvailableFlightFilter
{
    public IFlightQuery FlightQuery {  get; }
    public AvailableFlightFilter(IFlightQuery flightQuery)
    {
        FlightQuery = flightQuery;
    }

    public void ShowAvailableFlights()
    {
        var flights = FlightPrinter.PrintFlights(FlightQuery.FilterFlights(afterDate: DateTime.UtcNow.AddHours(2)), $"Available flights departing after {DateTime.UtcNow.AddHours(2)}:\n ");
        Console.WriteLine(flights);
    }

    public void ShowAvailableFlightsByDate(DateTime? date)
    {
        if (date?.CompareTo(DateTime.UtcNow.AddHours(2)) <= 0)
        {
            Console.WriteLine(ErrorMessages.SelectedDateInvalid);
            return;
        }
        var flights = FlightPrinter.PrintFlights(FlightQuery.FilterFlights(departureDate: date), $"Available flights departing at {date}:\n ");
        Console.WriteLine(flights);
    }

    public void ShowFlightsByPrice(decimal price)
    {
        var flights = FlightQuery.FilterFlights(price: price, afterDate: DateTime.UtcNow.AddHours(2));
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

    public void ShowFlightsByDepartureCountry(string departureCountry)
    {
        var flights = FlightPrinter.PrintFlights(FlightQuery.FilterFlights(departureCountry: departureCountry, afterDate: DateTime.UtcNow.AddHours(2)), $"Available flights departing from {departureCountry} after {DateTime.UtcNow.AddHours(2)}:\n ");
        Console.WriteLine(flights);
    }

    public void ShowFlightsByDestinationCountry(string destinationCountry)
    {
        var flights = FlightPrinter.PrintFlights(FlightQuery.FilterFlights(destinationCountry: destinationCountry, afterDate: DateTime.UtcNow.AddHours(2)), $"Available flights to {destinationCountry} after {DateTime.UtcNow.AddHours(2)}:\n ");
        Console.WriteLine(flights);
    }

    public void ShowFlightsByDepartureAirport(string departureAirport)
    {
        var flights = FlightPrinter.PrintFlights(FlightQuery.FilterFlights(departureAirport: departureAirport, afterDate: DateTime.UtcNow.AddHours(2)), $"Available flights departing from {departureAirport} Airport after {DateTime.UtcNow.AddHours(2)}:\n ");
        Console.WriteLine(flights);
    }

    public void ShowFlightsByArrivalAirport(string arrivalAirport)
    {
        var flights = FlightPrinter.PrintFlights(FlightQuery.FilterFlights(arrivalAirport: arrivalAirport, afterDate: DateTime.UtcNow.AddHours(2)), $"Available flights to {arrivalAirport} Airport after {DateTime.UtcNow.AddHours(2)}:\n ");
        Console.WriteLine(flights);
    }
}