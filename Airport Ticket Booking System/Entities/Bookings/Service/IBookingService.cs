using Airport_Ticket_Booking_System.Entities.Bookings.Core;
using Airport_Ticket_Booking_System.Entities.Bookings.Query;
using Airport_Ticket_Booking_System.Entities.Bookings.Repository;
using Airport_Ticket_Booking_System.Entities.Flights.Core;
using Airport_Ticket_Booking_System.Entities.Flights.Query;
using Airport_Ticket_Booking_System.Entities.Passengers.Repository;

namespace Airport_Ticket_Booking_System.Entities.Bookings.Service;
public interface IBookingService
{
    public IBookingRepository BookingRepository { get; }
    public IBookingQuery BookingQuery { get; }
    public IFlightQuery FlightQuery {  get; }
    public IPassenegerRepository PassenegerRepository {  get; }
    Book? BookAFlight(Book booking);
    Book? CancelAbooking(int bookingId, int passengerId);
    Book? ModifyBooking(int bookingId, int passengerId, ClassOfFlight? classOfFlight = null, int? flightId = null);
    List<Book> ShowBookings(int passengerId);
}