using Airport_Ticket_Booking_System.Entities.Flights.Core;
using Airport_Ticket_Booking_System.Entities.Flights.Repository;

namespace Airport_Ticket_Booking_System.Entities.Flights.Query;
public class FlightQuery : IFlightQuery
{
    public IFlightRepository FlightRepository { get; }
    public FlightQuery(IFlightRepository flightRepository)
    {
        FlightRepository = flightRepository;
    }

    public List<Flight> FilterFlights(
        DateTime? departureDate = null,
        string? departureCountry = null,
        string? destinationCountry = null,
        string? departureAirport = null,
        string? arrivalAirport = null,
        decimal? price = null,
        DateTime? afterDate = null)
    {
        var query = FlightRepository.Flights.AsQueryable();

        if (departureDate.HasValue)
            query = query.Where(f => f.DepartureDate == departureDate);

        if (!string.IsNullOrEmpty(departureCountry))
            query = query.Where(f => f.DepartureCountry == departureCountry);

        if (!string.IsNullOrEmpty(destinationCountry))
            query = query.Where(f => f.DestinationCountry == destinationCountry);

        if (!string.IsNullOrEmpty(departureAirport))
            query = query.Where(f => f.DepartureAirport == departureAirport);

        if (!string.IsNullOrEmpty(arrivalAirport))
            query = query.Where(f => f.ArrivalAirport == arrivalAirport);

        if (price.HasValue)
            query = query.Where(f => f.ClassPriceMap.Values.Contains(price.Value));

        if (afterDate.HasValue)
            query = query.Where(f => f.DepartureDate >= afterDate.Value);

        return query.ToList();
    }
    public Flight? GetById(int? id)
    {
        return FlightRepository.Flights.FirstOrDefault(f => f.Id == id);
    }
}
