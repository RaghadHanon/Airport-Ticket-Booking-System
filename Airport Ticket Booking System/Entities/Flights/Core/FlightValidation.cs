using Airport_Ticket_Booking_System.Utilities;
using System.Reflection;
using System.Text;

namespace Airport_Ticket_Booking_System.Entities.Flights.Core;
public static class FlightValidation
{
    public static bool ValidateFlight(Flight flight, out string errors)
    {
        if (flight == null)
        {
            errors = ErrorMessages.FlightCannotBeNull;
            return true;
        }

        var stringBuilder = new StringBuilder();
        if (!ValidtePrice(flight, out string priceErrors))
            stringBuilder.Append($"{priceErrors}\n");

        if (!ValidateDepartureDate(flight, out string dateErrors))
            stringBuilder.Append($"{dateErrors}\n");

        if (!ValidateCountry(flight, out string countryErrors))
            stringBuilder.Append($"{countryErrors}\n");

        if (!ValidateAirport(flight, out string airportErrors))
            stringBuilder.Append($"{airportErrors}\n");

        errors = stringBuilder.ToString();
        return string.IsNullOrEmpty(errors);
    }

    public static bool ValidtePrice(Flight flight, out string priceErrors)
    {
        var errorList = new List<string>();
        if (flight.EconomyPrice <= 0)
            errorList.Add(ErrorMessages.EconomyPriceInvalid);

        if (flight.BusinessPrice <= 0)
            errorList.Add(ErrorMessages.BusinessPriceInvalid);

        if (flight.FirstClassPrice <= 0)
            errorList.Add(ErrorMessages.FirstClassPriceInvalid);

        priceErrors = string.Join("\n", errorList);
        return !errorList.Any();
    }

    public static bool ValidateDepartureDate(Flight flight, out string dateErrors)
    {
        var errorList = new List<string>();
        if (flight.DepartureDate is null)
            errorList.Add(ErrorMessages.DepartureDateInvalidFormat);

        if (flight.DepartureDate <= DateTime.UtcNow.AddHours(4))
            errorList.Add(ErrorMessages.DepartureDateTooClose);

        dateErrors = string.Join("\n", errorList);
        return !errorList.Any();
    }

    public static bool ValidateCountry(Flight flight, out string countryErrors)
    {
        var errorList = new List<string>();
        if (string.IsNullOrWhiteSpace(flight.DepartureCountry))
            errorList.Add(ErrorMessages.DepartureCountryRequired);

        if (string.IsNullOrWhiteSpace(flight.DestinationCountry))
            errorList.Add(ErrorMessages.DestinationCountryRequired);

        countryErrors = string.Join("\n", errorList);
        return !errorList.Any();
    }

    public static bool ValidateAirport(Flight flight, out string airportErrors)
    {
        var errorList = new List<string>();
        if (string.IsNullOrWhiteSpace(flight.DepartureAirport))
            errorList.Add(ErrorMessages.DepartureAirportRequired);

        if (string.IsNullOrWhiteSpace(flight.ArrivalAirport))
            errorList.Add(ErrorMessages.ArrivalAirportRequired);

        airportErrors = string.Join("\n", errorList);
        return !errorList.Any();
    }

    public static void DisplayValidationRules()
    {
        var flightType = typeof(Flight);
        Console.WriteLine("\n--- Validation Rules ---");
        foreach (var property in flightType.GetProperties())
        {
            var fieldTypeAttr = property.GetCustomAttribute<FieldTypeAttribute>();
            var validationRuleAttr = property.GetCustomAttribute<ValidationRuleAttribute>();
            if (fieldTypeAttr != null && validationRuleAttr != null)
            {
                Console.WriteLine($"""
                                   - {property.Name}:
                                        Type: {fieldTypeAttr.Type}
                                        Constraints: {validationRuleAttr.Constraints}

                                   """);
            }
        }
    }
}
