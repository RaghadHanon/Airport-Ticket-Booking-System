using Airport_Ticket_Booking_System.Entites.FlightManagement;
using Airport_Ticket_Booking_System.Entites.FlightManagment;
using Airport_Ticket_Booking_System.Entites.PassengersManager;
using Airport_Ticket_Booking_System.Presentation;
using System.Text;

namespace Airport_Ticket_Booking_System.Entites.BookingManagement;
public static class BookingValidation
{
    public static bool ValidateBook(Book booking, out string errors)
    {
        if (booking == null)
        {
            errors = $"- Booking can't be null.\n";
            return true;
        }
        StringBuilder stringBuilder = new StringBuilder();

        if (!ClassOfFlightValidation(booking, out string classOfFlightErrors))
            stringBuilder.Append($"{classOfFlightErrors}\n");

        if (!PassengerValidation(booking, out string passengerErrors))
            stringBuilder.Append($"{passengerErrors}\n");

        if (!FlightValidation(booking, out string flightErrors))
            stringBuilder.Append($"{flightErrors}\n");

        if (!BookingCollisionsValidation(booking, out string collisionErrors))
            stringBuilder.Append($"{collisionErrors}\n");

        errors = stringBuilder.ToString();
        return string.IsNullOrEmpty(errors);
    }
    public static bool ClassOfFlightValidation(Book booking, out string classOfFlightErrors)
    {
        classOfFlightErrors= string.Empty;

        if (booking.ClassOfFlight is null )
            classOfFlightErrors =($"- Flight Class can't be null and must be one of these: Economy, Business, First Class.");

        return string.IsNullOrEmpty(classOfFlightErrors);
    }
    public static bool PassengerValidation(Book booking, out string passengerErrors)
    {
        passengerErrors= string.Empty;  

        if (booking.Passenger == null)
            passengerErrors=($"- Passenger not found.");

        return string.IsNullOrEmpty(passengerErrors);
    }
    public static bool FlightValidation(Book booking, out string flightErrors)
    {
        var errorList = new List<string>();
        if (booking.Flight == null)
            errorList.Add("- Flight cannot be null and must be a valid scheduled flight.");

        if (booking?.Flight?.DepartureDate <= DateTime.Now.AddHours(2))
            errorList.Add("- Departure date must be at least 2 hours from the current time.");

        flightErrors = string.Join("\n", errorList);
        return !errorList.Any();
    }
    public static bool BookingCollisionsValidation(Book booking, out string collisionErrors)
    {
        var passengerBookings = booking!.Passenger?.Bookings;
        var currentBookingFlight = booking!.Flight;

        collisionErrors = string.Empty;
        if (currentBookingFlight != null && passengerBookings != null && passengerBookings!.Any())
        {
            List<Book> collidingBooking = null;
            collidingBooking = passengerBookings!.Where(b => b?.Flight?.DepartureDate == currentBookingFlight?.DepartureDate).ToList();

            if (collidingBooking.Any())
                collisionErrors = BookPrinter.PrintBookings(collidingBooking, $"- The flight on {currentBookingFlight.DepartureDate} collides with an existing booking/s:\n");
        }
        return string.IsNullOrEmpty(collisionErrors);
    }
}