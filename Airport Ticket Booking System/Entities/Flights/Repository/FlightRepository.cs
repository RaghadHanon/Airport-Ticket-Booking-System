using Airport_Ticket_Booking_System.Entities.Flights.Core;
using Airport_Ticket_Booking_System.Utilities;

namespace Airport_Ticket_Booking_System.Entities.Flights.Repository;
public class FlightRepository : IFlightRepository
{
    public List<Flight> Flights { get; set; } = new List<Flight>();
    public Flight? AddFlight(Flight flight)
    {
        if (!FlightValidation.ValidateFlight(flight, out string errors))
        {
            ErrorException.error($"{errors}");
        }
        Flights.Add(flight);
        return flight;
    }
}