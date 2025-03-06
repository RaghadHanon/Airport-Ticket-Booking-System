using Airport_Ticket_Booking_System.Entities.Flights.Core;

namespace Airport_Ticket_Booking_System.Entities.Flights.Repository;
public interface IFlightRepository
{
    List<Flight> Flights { get; set; }
    Flight? AddFlight(Flight flight);
}