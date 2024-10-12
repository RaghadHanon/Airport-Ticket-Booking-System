using Airport_Ticket_Booking_System.Entities.Passengers.Core;

namespace Airport_Ticket_Booking_System.Entities.Passengers.Repository;
public interface IPassenegerRepository
{
    List<Passenger> Passengers { get; set; }
    Passenger? AddAPassenger(string name);
    Passenger? GetById(int? id);
}