using Airport_Ticket_Booking_System.Entities.Flights.Core;
using FluentAssertions;

namespace Airport_Ticket_Booking_System_Tests;
public class BookingQueryShould : IClassFixture<BookingsQueryFixture>
{
    private readonly BookingsQueryFixture _bookingsQueryFixture;

    public BookingQueryShould(BookingsQueryFixture bookingsQueryFixture)
    {
        _bookingsQueryFixture = bookingsQueryFixture;
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void FilterBookings_WhenPassengerIdExists_ShouldReturnMatchingBookings(int passengerId)
    {
        var result = _bookingsQueryFixture.sut.FilterBookings(passengerId: passengerId);
        result.Should().NotBeNullOrEmpty("because we expect bookings to be found for passenger ID {0}", passengerId);
        result.First().Passenger.Id.Should().Be(passengerId,
            "the returned booking's PassengerId should match the one being queried for.");
    }

    [Theory]
    [InlineData(999)]
    public void FilterBookings_WhenPassengerIdDoesNotExist_ShouldReturnNoBookings(int nonExistentPassengerId)
    {
        var result = _bookingsQueryFixture.sut.FilterBookings(passengerId: nonExistentPassengerId);
        result.Should().BeEmpty($"because there are no bookings with PassengerId {nonExistentPassengerId}");
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void FilterBookings_WhenFlightIdExists_ShouldReturnMatchingBookings(int flightId)
    {
        var result = _bookingsQueryFixture.sut.FilterBookings(flightId: flightId);
        result.Should().NotBeNullOrEmpty("because we expect bookings to be found for flight ID {0}", flightId);
        result.First().Flight.Id.Should().Be(flightId,
            "the returned booking's FlightId should match the one being queried for.");
    }

    [Theory]
    [InlineData(999)]
    public void FilterBookings_WhenFlightIdDoesNotExist_ShouldReturnNoBookings(int nonExistentFlightId)
    {
        var result = _bookingsQueryFixture.sut.FilterBookings(flightId: nonExistentFlightId);
        result.Should().BeEmpty($"because there are no bookings with FlightId {nonExistentFlightId}");
    }

    [Theory]
    [InlineData(ClassOfFlight.Business)]
    [InlineData(ClassOfFlight.Economy)]
    [InlineData(ClassOfFlight.FirstClass)]
    public void FilterBookings_WhenClassOfFlightExists_ShouldReturnMatchingBookings(ClassOfFlight classOfFlight)
    {
        var result = _bookingsQueryFixture.sut.FilterBookings(classOfFlight: classOfFlight);
        result.Should().NotBeNullOrEmpty("because we expect bookings to be found for classOfFlight {0}", classOfFlight);
        result.First().ClassOfFlight.Should().Be(classOfFlight,
            "the returned booking's classOfFlight should match the one being queried for.");
    }

    [Theory]
    [InlineData(1200)]
    [InlineData(810)]
    [InlineData(310)]
    public void FilterBookings_WhenPriceExists_ShouldReturnMatchingBookings(decimal price)
    {
        var result = _bookingsQueryFixture.sut.FilterBookings(price: price);
        result.Should().NotBeNullOrEmpty("because we expect bookings to be found for price {0}", price);
        var classOfFlight = result.First().ClassOfFlight;
        result.First().Flight.ClassPriceMap[(ClassOfFlight)classOfFlight].Should().Be(price,
            "the returned booking's price should match the one being queried for.");
    }

    [Theory]
    [InlineData("USA")]
    [InlineData("Brazil")]
    [InlineData("France")]
    public void FilterBookings_WhenDepartureCountryExists_ShouldReturnMatchingBookings(string departureCountry)
    {
        var result = _bookingsQueryFixture.sut.FilterBookings(departureCountry: departureCountry);
        result.Should().NotBeNullOrEmpty($"because we expect bookings to be found for departure country {departureCountry}");
        result.First().Flight.DepartureCountry.Should().Be(departureCountry,
            "the returned booking's departure country should match the one being queried for.");
    }

    [Theory]
    [InlineData("UK")]
    [InlineData("Italy")]
    [InlineData("Brazil")]
    public void FilterBookings_WhenDestinationCountryExists_ShouldReturnMatchingBookings(string destinationCountry)
    {
        var result = _bookingsQueryFixture.sut.FilterBookings(destinationCountry: destinationCountry);
        result.Should().NotBeNullOrEmpty($"because we expect bookings to be found for destination country {destinationCountry}");
        result.First().Flight.DestinationCountry.Should().Be(destinationCountry,
            "the returned booking's destination country should match the one being queried for.");
    }

    [Theory]
    [InlineData("2024-10-15")]
    [InlineData("2024-04-09")]
    public void FilterBookings_WhenDepartureDateExists_ShouldReturnMatchingBookings(string departureDateString)
    {
        DateTime departureDate = DateTime.Parse(departureDateString);
        var result = _bookingsQueryFixture.sut.FilterBookings(departureDate: departureDate);
        result.Should().NotBeNullOrEmpty($"because we expect bookings to be found for departure date {departureDate}");
        result.First().Flight.DepartureDate.Should().Be(departureDate,
            "the returned booking's departure date should match the one being queried for.");
    }

    [Theory]
    [InlineData("2024-01-01")]
    public void FilterBookings_WhenAfterSpecificDateExists_ShouldReturnBookingsAfterDate(string afterDateString)
    {
        DateTime afterDate = DateTime.Parse(afterDateString);
        var result = _bookingsQueryFixture.sut.FilterBookings(afterDate: afterDate);
        result.Should().NotBeNullOrEmpty($"because we expect bookings to be found after {afterDate}");
        result.First().Flight.DepartureDate.Should().BeAfter(afterDate,
            "the returned bookings should have a departure date after the date being queried for.");
    }
}
