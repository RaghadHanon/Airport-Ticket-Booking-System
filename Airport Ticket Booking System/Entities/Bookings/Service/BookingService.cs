using Airport_Ticket_Booking_System.Entities.Bookings.Core;
using Airport_Ticket_Booking_System.Entities.Bookings.Query;
using Airport_Ticket_Booking_System.Entities.Bookings.Repository;
using Airport_Ticket_Booking_System.Entities.Flights.Core;
using Airport_Ticket_Booking_System.Entities.Flights.Query;
using Airport_Ticket_Booking_System.Entities.Passengers.Core;
using Airport_Ticket_Booking_System.Entities.Passengers.Repository;
using Airport_Ticket_Booking_System.Utilities;

namespace Airport_Ticket_Booking_System.Entities.Bookings.Service;
public class BookingService : IBookingService
{
    public IBookingRepository BookingRepository { get; }
    public IBookingQuery BookingQuery { get; }
    public IFlightQuery FlightQuery { get; }
    public IPassenegerRepository PassenegerRepository { get; }
    public BookingService(IBookingRepository bookingRepository, IBookingQuery bookingQuery, IFlightQuery flightQuery, IPassenegerRepository passenegerRepository)
    {
        BookingRepository = bookingRepository;
        BookingQuery = bookingQuery;
        FlightQuery = flightQuery;
        PassenegerRepository = passenegerRepository;
    }

    public Book? BookAFlight(Book booking)
    {
        if (!BookingValidation.ValidateBook(booking, out string errors))
            ErrorException.error($"{errors}", ErrorMessages.BookingFlightError);

        booking!.Passenger!.Bookings.Add(booking);
        BookingRepository.AddBooking(booking);
        return booking;
    }

    public Book? CancelAbooking(int bookingId, int passengerId)
    {
        Book? booking = BookingQuery.GetById(bookingId);
        if (booking == null)
            ErrorException.error(ErrorMessages.BookingNotFound, ErrorMessages.CancelBookingError);

        if (!BookingValidation.ValidatePassenger(booking, out string errors))
            ErrorException.error($"{errors}", ErrorMessages.CancelBookingError);

        Passenger passenger = PassenegerRepository.GetById(passengerId)!;
        if (!HasAccessToBooking(passenger, booking, out string accessError))
            ErrorException.error($"{accessError}", ErrorMessages.CancelBookingError);

        passenger.Bookings.Remove(booking);
        BookingRepository.RemoveBooking(booking);
        return booking;
    }

    private bool HasAccessToBooking(Passenger passenger, Book booking, out string accessError)
    {
        accessError = string.Empty;
        if (booking!.Passenger!.Id != passenger.Id)
        {
            accessError = ErrorMessages.AccessDenied;
            return false;
        }
        return true;
    }

    public Book? ModifyBooking(int bookingId, int passengerId, ClassOfFlight? classOfFlight = null, int? flightId = null)
    {
        Book? booking = BookingQuery.GetById(bookingId);
        if (booking == null)
            ErrorException.error(ErrorMessages.BookingNotFound, ErrorMessages.ModifyBookingError);

        Passenger passenger = PassenegerRepository.GetById(passengerId)!;
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

    public List<Book> ShowBookings(int passengerId)
    {
        Passenger passenger = PassenegerRepository.GetById(passengerId)!;
        if (passenger is null)
            ErrorException.error(ErrorMessages.PassengerNotFound);

        return passenger.Bookings;
    }
}
