using Airport_Ticket_Booking_System.Entities.Flights.Core;
using Airport_Ticket_Booking_System.Utilities;
using FluentAssertions;
using Moq;

namespace Airport_Ticket_Booking_System_Tests.FlightValidationTests
{
    public class FlightValidationShould
    {
        private Flight flight;

        public FlightValidationShould()
        {
            flight = new Flight();
        }

        [Fact]
        public void ValidatePrice_WhenPricesAreValid_ShouldReturnTrue()
        {
            flight.EconomyPrice = 500;
            flight.BusinessPrice = 800;
            flight.FirstClassPrice = 1300;

            var result = FlightValidation.ValidatePrice(flight, out string priceErrors);

            result.Should().BeTrue();
            priceErrors.Should().BeEmpty();
        }

        [Fact]
        public void ValidatePrice_WhenAnyPriceIsInvalid_ShouldReturnFalseAndProvideErrorMessages()
        {
            flight.EconomyPrice = 0;  
            flight.BusinessPrice = -20;  
            flight.FirstClassPrice = -1;

            var result = FlightValidation.ValidatePrice(flight, out string priceErrors);

            result.Should().BeFalse();
            priceErrors.Should().Contain(ErrorMessages.EconomyPriceInvalid)
                                 .And.Contain(ErrorMessages.BusinessPriceInvalid)
                                 .And.Contain(ErrorMessages.FirstClassPriceInvalid);
        }

        [Fact]
        public void ValidateDepartureDate_WhenDateIsValid_ShouldReturnTrue()
        {
            flight.DepartureDate = DateTime.UtcNow.AddHours(6); 

            var result = FlightValidation.ValidateDepartureDate(flight, out string dateErrors);

            result.Should().BeTrue();
            dateErrors.Should().BeEmpty();
        }

        [Fact]
        public void ValidateDepartureDate_WhenDateIsTooClose_ShouldReturnFalseAndProvideErrorMessages()
        {
            flight.DepartureDate = DateTime.UtcNow.AddHours(3);

            var result = FlightValidation.ValidateDepartureDate(flight, out string dateErrors);

            result.Should().BeFalse();
            dateErrors.Should().Contain(ErrorMessages.DepartureDateTooClose);
        }

        [Fact]
        public void ValidateAirport_WhenAirportsAreValid_ShouldReturnTrue()
        {
            flight.DepartureAirport = "JFK";
            flight.ArrivalAirport = "GRU";

            var result = FlightValidation.ValidateAirport(flight, out string airportErrors);

            result.Should().BeTrue();
            airportErrors.Should().BeEmpty();
        }

        [Fact]
        public void ValidateAirport_WhenDepartureAirportIsMissing_ShouldReturnFalseAndProvideErrorMessage()
        {
            flight.DepartureAirport = ""; 
            flight.ArrivalAirport = "GRU";

            var result = FlightValidation.ValidateAirport(flight, out string airportErrors);

            result.Should().BeFalse();
            airportErrors.Should().Contain(ErrorMessages.DepartureAirportRequired)
                                  .And.NotContain(ErrorMessages.ArrivalAirportRequired);
        }

        [Fact]
        public void ValidateAirport_WhenArrivalAirportIsMissing_ShouldReturnFalseAndProvideErrorMessage()
        {
            flight.DepartureAirport = "JFK"; 
            flight.ArrivalAirport = ""; 

            var result = FlightValidation.ValidateAirport(flight, out string airportErrors);

            result.Should().BeFalse();
            airportErrors.Should().Contain(ErrorMessages.ArrivalAirportRequired)
                                  .And.NotContain(ErrorMessages.DepartureAirportRequired);
        }

    }
}
