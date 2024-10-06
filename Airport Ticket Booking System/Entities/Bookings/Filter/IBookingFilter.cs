using Airport_Ticket_Booking_System.Entities.Bookings.Query;
using Airport_Ticket_Booking_System.Entities.Flights.Core;

namespace Airport_Ticket_Booking_System.Entities.Bookings.Filter
{
    public interface IBookingFilter
    {
        public IBookingQuery BookingQuery { get; }
        void ShowBookings();
        void ShowBookingsAfterDate(DateTime date);
        void ShowBookingsByClassFlight(ClassOfFlight classOfFlight);
        void ShowBookingsByDate(DateTime date);
        void ShowBookingsByDepartureAirport(string departureAirport);
        void ShowBookingsByDepartureCountry(string departureCountry);
        void ShowBookingsByDestinationCountry(string destinationCountry);
        void ShowBookingsByFlight(int flightId);
        void ShowBookingsByPassenger(int passengerId);
        void ShowBookingsByPrice(decimal price);
        void ShowFlightsByArrivalAirport(string arrivalAirport);
    }
}