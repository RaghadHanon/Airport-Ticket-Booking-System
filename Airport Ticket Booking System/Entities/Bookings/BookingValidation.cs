using Airport_Ticket_Booking_System.Presentation;
using Airport_Ticket_Booking_System.Utilities;
using System.Text;

namespace Airport_Ticket_Booking_System.Entities.Bookings;
public static class BookingValidation
{
    public static bool ValidateBook(Book booking, out string errors)
    {
        if (booking == null)
        {
            errors = ErrorMessages.BookingCannotBeNull;
            return true;
        }
        var stringBuilder = new StringBuilder();
        if (!ValidateClassOfFlight(booking, out string classOfFlightErrors))
            stringBuilder.Append($"{classOfFlightErrors}\n");

        if (!ValidatePassenger(booking, out string passengerErrors))
            stringBuilder.Append($"{passengerErrors}\n");

        if (!ValidateFlight(booking, out string flightErrors))
            stringBuilder.Append($"{flightErrors}\n");

        if (!ValidateBookingCollisions(booking, out string collisionErrors))
            stringBuilder.Append($"{collisionErrors}\n");

        errors = stringBuilder.ToString();
        return string.IsNullOrEmpty(errors);
    }
    public static bool ValidateClassOfFlight(Book booking, out string classOfFlightErrors)
    {
        classOfFlightErrors= string.Empty;
        if (booking.ClassOfFlight is null )
            classOfFlightErrors =(ErrorMessages.ClassOfFlightCannotBeNull);

        return string.IsNullOrEmpty(classOfFlightErrors);
    }
    public static bool ValidatePassenger(Book booking, out string passengerErrors)
    {
        passengerErrors= string.Empty;  
        if (booking.Passenger == null)
            passengerErrors=(ErrorMessages.PassengerNotFound);

        return string.IsNullOrEmpty(passengerErrors);
    }
    public static bool ValidateFlight(Book booking, out string flightErrors)
    {
        var errorList = new List<string>();
        if (booking.Flight == null)
            errorList.Add($"{ErrorMessages.FlightCannotBeNull}\n{ErrorMessages.FlightMustBaValidScheduledFlight}");

        if (booking?.Flight?.DepartureDate <= DateTime.UtcNow.AddHours(2))
            errorList.Add(ErrorMessages.DepartureDateTooCloseForBooking);

        flightErrors = string.Join("\n", errorList);
        return !errorList.Any();
    }
    public static bool ValidateBookingCollisions(Book booking, out string collisionErrors)
    {
        var passengerBookings = booking!.Passenger?.Bookings;
        var currentBookingFlight = booking!.Flight;

        collisionErrors = string.Empty;
        if (currentBookingFlight != null && passengerBookings != null && passengerBookings!.Any())
        {
            List<Book> collidingBooking = null;
            collidingBooking = passengerBookings!.Where(b => b?.Flight?.DepartureDate == currentBookingFlight?.DepartureDate).ToList();

            if (collidingBooking.Any())
                collisionErrors = BookPrinter.PrintBookings(collidingBooking, $" {ErrorMessages.FlightCollisionMessage} on {currentBookingFlight.DepartureDate}:\n");
        }
        return string.IsNullOrEmpty(collisionErrors);
    }
}