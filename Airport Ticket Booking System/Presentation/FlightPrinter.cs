using Airport_Ticket_Booking_System.Entites.FlightManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.Presentation;
public class FlightPrinter
{
    private readonly Flight _flight;

    public FlightPrinter(Flight flight)
    {
        _flight = flight ?? throw new ArgumentNullException(nameof(flight));
    }

    public string PrintFlight()
    {
        return $$""" 
                  {
                     FlightId {{_flight.Id}}:
                     DepartureCountry: "{{_flight.DepartureCountry}}",
                     DestinationCountry: "{{_flight.DestinationCountry}}\",
                     DepartureDate: "{{_flight.DepartureDate}}",
                     DepartureAirport: "{{_flight.DepartureAirport}}",
                     ArrivalAirport: "{{_flight.ArrivalAirport}}"
                     Prices: 
                     - Economy: {{_flight.EconomyPrice}}$
                     - Business: {{_flight.BusinessPrice}}$
                     - First Class: {{_flight.FirstClassPrice}}$
                  }
                 """;

    }
    public static string PrintFlights(IEnumerable<Flight> flights,string? title =null)
    {
        if (flights == null || !flights.Any())
            return "No flights available.";
        
        StringBuilder sb = new StringBuilder();
        sb.Append(title);
        sb.Append(string.Join("\n", flights.Select(f => new FlightPrinter(f).PrintFlight())));
        return sb.ToString();
    }
}