using Airport_Ticket_Booking_System.Entities.Flights.Core;
using Airport_Ticket_Booking_System.Utilities;
using FluentAssertions;

namespace Airport_Ticket_Booking_System_Tests.ValidationTests;
public class FlightValidationTests
{
    private Flight flight;

    public FlightValidationTests()
    {
        flight = new Flight();
    }

    [Theory]
    [InlineData(0, false, ErrorMessages.EconomyPriceInvalid)]
    [InlineData(100, true, "")]
    public void ValidateEconomyPrice_ShouldReturnExpectedResult(int economyPrice, bool expectedResult, string expectedError)
    {
        flight.EconomyPrice = economyPrice;

        var result = FlightValidation.ValidatePrice(flight, out string priceErrors);

        result.Should().Be(expectedResult);
        if (!result)
        {
            priceErrors.Should().Contain(expectedError);
        }
    }

    [Theory]
    [InlineData(-20, false, ErrorMessages.BusinessPriceInvalid)]
    [InlineData(200, true, "")]
    public void ValidateBusinessPrice_ShouldReturnExpectedResult(int businessPrice, bool expectedResult, string expectedError)
    {
        flight.BusinessPrice = businessPrice;

        var result = FlightValidation.ValidatePrice(flight, out string priceErrors);

        result.Should().Be(expectedResult);
        if (!result)
        {
            priceErrors.Should().Contain(expectedError);
        }
    }

    [Theory]
    [InlineData(-1, false, ErrorMessages.FirstClassPriceInvalid)]
    [InlineData(300, true, "")]
    public void ValidateFirstClassPrice_ShouldReturnExpectedResult(int firstClassPrice, bool expectedResult, string expectedError)
    {
        flight.FirstClassPrice = firstClassPrice;

        var result = FlightValidation.ValidatePrice(flight, out string priceErrors);

        result.Should().Be(expectedResult);
        if (!result)
        {
            priceErrors.Should().Contain(expectedError);
        }
    }

    [Fact]
    public void ValidateDepartureDate_ShouldReturnTrue_WhenDateIsValid()
    {
        flight.DepartureDate = DateTime.UtcNow.AddHours(6);

        var result = FlightValidation.ValidateDepartureDate(flight, out string dateErrors);

        result.Should().BeTrue();
        dateErrors.Should().BeEmpty();
    }

    [Fact]
    public void ValidateDepartureDate_ShouldReturnFalseAndProvideErrorMessages_WhenDateIsTooClose()
    {
        flight.DepartureDate = DateTime.UtcNow.AddHours(3);

        var result = FlightValidation.ValidateDepartureDate(flight, out string dateErrors);

        result.Should().BeFalse();
        dateErrors.Should().Contain(ErrorMessages.DepartureDateTooClose);
    }

    [Fact]
    public void ValidateAirport_ShouldReturnTrue_WhenAirportsAreValid()
    {
        flight.DepartureAirport = "JFK";
        flight.ArrivalAirport = "GRU";

        var result = FlightValidation.ValidateAirport(flight, out string airportErrors);

        result.Should().BeTrue();
        airportErrors.Should().BeEmpty();
    }

    [Fact]
    public void ValidateAirport_ShouldReturnFalseAndProvideErrorMessage_WhenDepartureAirportIsMissing()
    {
        flight.DepartureAirport = "";
        flight.ArrivalAirport = "GRU";

        var result = FlightValidation.ValidateAirport(flight, out string airportErrors);

        result.Should().BeFalse();
        airportErrors.Should().Contain(ErrorMessages.DepartureAirportRequired)
                              .And.NotContain(ErrorMessages.ArrivalAirportRequired);
    }

    [Fact]
    public void ValidateAirport_ShouldReturnFalseAndProvideErrorMessage_WhenArrivalAirportIsMissing()
    {
        flight.DepartureAirport = "JFK";
        flight.ArrivalAirport = "";

        var result = FlightValidation.ValidateAirport(flight, out string airportErrors);

        result.Should().BeFalse();
        airportErrors.Should().Contain(ErrorMessages.ArrivalAirportRequired)
                              .And.NotContain(ErrorMessages.DepartureAirportRequired);
    }
}