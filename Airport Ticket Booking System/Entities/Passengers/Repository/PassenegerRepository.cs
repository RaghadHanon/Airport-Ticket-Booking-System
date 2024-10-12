using Airport_Ticket_Booking_System.Entities.Passengers.Core;
using Airport_Ticket_Booking_System.Utilities;

namespace Airport_Ticket_Booking_System.Entities.Passengers.Repository;
public class PassenegerRepository : IPassenegerRepository
{
    public List<Passenger> Passengers { get; set; } = new List<Passenger>();
    public Passenger? AddAPassenger(string name)
    {
        Passenger? passenger = null;
        try
        {
            passenger = new Passenger(name);
            Passengers.Add(passenger);
        }
        catch (Exception e)
        {
            Console.WriteLine($"{ErrorMessages.PassengerAddingError} {e.Message}");
        }
        return passenger;
    }

    public Passenger? GetById(int? id)
    {
        return Passengers.FirstOrDefault(p => p.Id == id);
    }
}
