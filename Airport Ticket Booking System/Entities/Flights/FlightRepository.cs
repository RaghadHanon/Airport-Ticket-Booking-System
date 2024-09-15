using Airport_Ticket_Booking_System.Utilities;

namespace Airport_Ticket_Booking_System.Entities.Flights;
public static class FlightRepository
{
    private static List<Flight> _flights = new List<Flight>();
    public static List<Flight> Flights { get; } = _flights;
    public static Flight? AddFlight(Flight flight)
    {
        if (!FlightValidation.ValidateFlight(flight, out string errors))
        {
            ErrorException.error($"{errors}");
        }
        Flights.Add(flight);
        return flight;
    }
}