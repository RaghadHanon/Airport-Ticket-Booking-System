using Airport_Ticket_Booking_System.Entities.Flights;

namespace Airport_Ticket_Booking_System.Entities.Bookings;
public static class BookingQuery
{
    public static Book? GetById(int id)
    {
        return BookingRepository.Bookings.FirstOrDefault(b => b.Id == id);
    }

    public static List<Book> FilterBookings(
        int? passengerId = null,
        int? flightId = null,
        ClassOfFlight? classOfFlight = null,
        decimal? price = null,
        string? departureCountry = null,
        string? destinationCountry = null,
        DateTime? departureDate = null,
        string? departureAirport = null,
        string? arrivalAirport = null,
        DateTime? afterDate = null)
    {
        var query = BookingRepository.Bookings.AsQueryable();
        if (passengerId.HasValue)
            query = query.Where(b => b.Passenger.Id == passengerId.Value);

        if (flightId.HasValue)
            query = query.Where(b => b.Flight.Id == flightId.Value);

        if (classOfFlight.HasValue)
            query = query.Where(b => b.ClassOfFlight == classOfFlight.Value);

        if (price.HasValue)
            query = query.Where(b => b.Flight.ClassPriceMap[(ClassOfFlight)b.ClassOfFlight] == price.Value);

        if (!string.IsNullOrEmpty(departureCountry))
            query = query.Where(b => b.Flight.DepartureCountry == departureCountry);

        if (!string.IsNullOrEmpty(destinationCountry))
            query = query.Where(b => b.Flight.DestinationCountry == destinationCountry);

        if (departureDate.HasValue)
            query = query.Where(b => b.Flight.DepartureDate == departureDate.Value);

        if (!string.IsNullOrEmpty(departureAirport))
            query = query.Where(b => b.Flight.DepartureAirport == departureAirport);

        if (!string.IsNullOrEmpty(arrivalAirport))
            query = query.Where(b => b.Flight.ArrivalAirport == arrivalAirport);

        if (afterDate.HasValue)
            query = query.Where(b => b.Flight.DepartureDate >= afterDate.Value);

        return query.ToList();
    }
}
