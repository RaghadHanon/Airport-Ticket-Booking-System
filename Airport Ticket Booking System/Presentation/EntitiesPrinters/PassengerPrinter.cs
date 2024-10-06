using Airport_Ticket_Booking_System.Entities.Passengers.Core;
using Airport_Ticket_Booking_System.Utilities;
using System.Text;

namespace Airport_Ticket_Booking_System.Presentation.EntitiesPrinters;
public static class PassengerPrinter
{
    public static string PrintPassenger(Passenger passenger)
    {
        return $" Passenger: {passenger.Id}, Name: {passenger.Name}";
    }

    public static string PrintPassengers(IEnumerable<Passenger> passengers, string? title = null)
    {
        if (passengers == null || !passengers.Any())
        {
            return ErrorMessages.NoAvailableFlights;
        }
        var sb = new StringBuilder();
        sb.Append(title);
        sb.Append(string.Join("\n", passengers.Select(p => PrintPassenger(p))));
        return sb.ToString();
    }
}
