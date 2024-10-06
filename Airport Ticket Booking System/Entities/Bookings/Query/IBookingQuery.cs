using Airport_Ticket_Booking_System.Entities.Bookings.Core;
using Airport_Ticket_Booking_System.Entities.Bookings.Repository;
using Airport_Ticket_Booking_System.Entities.Flights.Core;

namespace Airport_Ticket_Booking_System.Entities.Bookings.Query;
public interface IBookingQuery
{
    public IBookingRepository BookingRepository {  get; }
    List<Book> FilterBookings(int? passengerId = null, int? flightId = null, ClassOfFlight? classOfFlight = null, decimal? price = null, string? departureCountry = null, string? destinationCountry = null, DateTime? departureDate = null, string? departureAirport = null, string? arrivalAirport = null, DateTime? afterDate = null);
    Book? GetById(int id);
}