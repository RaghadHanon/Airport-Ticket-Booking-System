using Airport_Ticket_Booking_System.Entities.Flights.Core;
using Airport_Ticket_Booking_System.Entities.Flights.Repository;

namespace Airport_Ticket_Booking_System.Entities.Flights.Query;
public interface IFlightQuery
{
    public IFlightRepository FlightRepository { get; }
    List<Flight> FilterFlights(DateTime? departureDate = null, string? departureCountry = null, string? destinationCountry = null, string? departureAirport = null, string? arrivalAirport = null, decimal? price = null, DateTime? afterDate = null);
    Flight? GetById(int? id);
}