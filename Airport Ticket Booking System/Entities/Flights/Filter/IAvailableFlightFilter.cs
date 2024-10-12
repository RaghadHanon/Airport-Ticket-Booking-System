
using Airport_Ticket_Booking_System.Entities.Flights.Query;

namespace Airport_Ticket_Booking_System.Entities.Flights.Filter;
public interface IAvailableFlightFilter
{
    public IFlightQuery FlightQuery { get; }
    void ShowAvailableFlights();
    void ShowAvailableFlightsByDate(DateTime? date);
    void ShowFlightsByArrivalAirport(string arrivalAirport);
    void ShowFlightsByDepartureAirport(string departureAirport);
    void ShowFlightsByDepartureCountry(string departureCountry);
    void ShowFlightsByDestinationCountry(string destinationCountry);
    void ShowFlightsByPrice(decimal price);
}