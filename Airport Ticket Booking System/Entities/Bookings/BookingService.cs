using Airport_Ticket_Booking_System.Entities.Flights;
using Airport_Ticket_Booking_System.Entities.Passenegers;
using Airport_Ticket_Booking_System.Presentation;
using Airport_Ticket_Booking_System.Utilities;

namespace Airport_Ticket_Booking_System.Entities.Bookings;
public static class BookingService
{
    public static Book? BookAFlight(Book booking)
    {
        if (!BookingValidation.ValidateBook(booking, out string errors))
            ErrorException.error($"{errors}", ErrorMessages.BookingFlightError);

        booking!.Passenger!.Bookings.Add(booking);
        BookingRepository.Bookings.Add(booking);
        return booking;
    }

    public static Book? CancelAbooking(int bookingId, int passengerId)
    {
        Book? booking = BookingQuery.GetById(bookingId);
        if (booking == null)
            ErrorException.error(ErrorMessages.BookingNotFound, ErrorMessages.CancelBookingError);

        if (!BookingValidation.ValidatePassenger(booking, out string errors))
            ErrorException.error($"{errors}", ErrorMessages.CancelBookingError);

        Passenger passenger = Passenegers.PassenegerRepository.GetById(passengerId)!;
        if (!HasAccessToBooking(passenger, booking, out string accessError))
            ErrorException.error($"{accessError}", ErrorMessages.CancelBookingError);

        passenger.Bookings.Remove(booking);
        BookingRepository.Bookings.Remove(booking);
        return booking;
    }

    private static bool HasAccessToBooking(Passenger passenger, Book booking ,out string accessError )
    {
        accessError = string.Empty;
        if (booking!.Passenger!.Id != passenger.Id)
        {
            accessError = ErrorMessages.AccessDenied;
            return false;
        }
        return true;
    }

    public static Book? ModifyBooking(int bookingId, int passengerId, ClassOfFlight? classOfFlight = null, int? flightId = null)
    {        Book? booking = BookingQuery.GetById(bookingId);
        if (booking == null)
            ErrorException.error(ErrorMessages.BookingNotFound, ErrorMessages.ModifyBookingError);

        Passenger passenger = Passenegers.PassenegerRepository.GetById(passengerId)!;
        Flight? flight = flightId.HasValue ? FlightQuery.GetById(flightId) : booking.Flight;
        Book? newBooking = new(classOfFlight ?? booking.ClassOfFlight, flight, passenger);
        if (!BookingValidation.ValidatePassenger(newBooking, out string passengerErrors))
            ErrorException.error($"{passengerErrors}", ErrorMessages.ModifyBookingError);

        if (!HasAccessToBooking(passenger, booking, out string accessError))
            ErrorException.error($"{accessError}", ErrorMessages.ModifyBookingError);

        if (classOfFlight.HasValue && !BookingValidation.ValidateClassOfFlight(newBooking, out string classOfFlightErrors))
            ErrorException.error($"{classOfFlightErrors}", ErrorMessages.ModifyBookingError);

        if (flightId.HasValue && !BookingValidation.ValidateFlight(newBooking, out string flightErrors))
            ErrorException.error($"{flightErrors}", ErrorMessages.ModifyBookingError);

        if (flightId.HasValue && !BookingValidation.ValidateBookingCollisions(newBooking, out string bookingCollisionsErrors))
            ErrorException.error($"{bookingCollisionsErrors}", ErrorMessages.ModifyBookingError);

        if (classOfFlight.HasValue)
            booking.ClassOfFlight = classOfFlight.Value;

        if (flightId.HasValue)
            booking.Flight = flight;

        return booking;
    }

    public static List<Book> ShowBookings(int passengerId)
    {
        Passenger passenger = Passenegers.PassenegerRepository.GetById(passengerId)!;
        if (passenger is null)
            ErrorException.error(ErrorMessages.PassengerNotFound);

        return passenger.Bookings;
    }
}
