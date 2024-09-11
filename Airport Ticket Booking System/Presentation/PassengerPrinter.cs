using Airport_Ticket_Booking_System.Entites.PassengersManager;
using System.Text;

namespace Airport_Ticket_Booking_System.Presentation;
public class PassengerPrinter
{
    private readonly Passenger _passenger;
    public PassengerPrinter(Passenger passenger)
    {
        _passenger = passenger ?? throw new ArgumentNullException(nameof(passenger));
    }
    public string PrintPassenger()
    {
        return $" Passenger: {_passenger.Id}, Name: {_passenger.Name}";
    }
    public static string PrintPassengers(IEnumerable<Passenger> passengers, string? title =null)
    {
        if (passengers == null || !passengers.Any())
        {
            return "No passengers available.";
        }
        StringBuilder sb = new StringBuilder();
        sb.Append(title);
        sb.Append(string.Join("\n", passengers.Select(p => new PassengerPrinter(p).PrintPassenger())));
        return sb.ToString();
    }
}
