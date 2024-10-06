using Airport_Ticket_Booking_System.Entities.Flights.Core;
using Airport_Ticket_Booking_System.Utilities;
using System.Text;

namespace Airport_Ticket_Booking_System.Presentation.EntitiesPrinters;
public static class FlightPrinter
{
    public static string PrintFlight(Flight flight)
    {
        return $$""" 
                  {
                     FlightId {{flight.Id}}:
                     DepartureCountry: "{{flight.DepartureCountry}}",
                     DestinationCountry: "{{flight.DestinationCountry}}\",
                     DepartureDate: "{{flight.DepartureDate}}",
                     DepartureAirport: "{{flight.DepartureAirport}}",
                     ArrivalAirport: "{{flight.ArrivalAirport}}"
                     Prices: 
                     - Economy: {{flight.EconomyPrice}}$
                     - Business: {{flight.BusinessPrice}}$
                     - First Class: {{flight.FirstClassPrice}}$
                  }
                 """;

    }

    public static string PrintFlights(IEnumerable<Flight> flights, string? title = null)
    {
        if (flights == null || !flights.Any())
            return ErrorMessages.NoAvailableFlights;

        var sb = new StringBuilder();
        sb.Append(title);
        sb.Append(string.Join("\n", flights.Select(f => PrintFlight(f))));
        return sb.ToString();
    }
}