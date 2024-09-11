using Airport_Ticket_Booking_System.Entites.FlightManagment;
using Airport_Ticket_Booking_System.Utilities;
using System.Reflection;
using System.Text;

namespace Airport_Ticket_Booking_System.Entites.FlightManagement;
public static class FlightValidation
{
    public static bool ValidateFlight(Flight flight, out string errors)
    {
        if (flight == null)
        {
            errors = $"- Flight can't be null.\n";
            return true;
        }

        StringBuilder stringBuilder = new StringBuilder();

        if (!PriceValidtion(flight, out string priceErrors))
            stringBuilder.Append($"{priceErrors}\n");
        
        if (!DepartureDateValidation(flight, out string dateErrors))
            stringBuilder.Append($"{dateErrors}\n");
        
        if (!CountryValidation(flight, out string countryErrors))
            stringBuilder.Append($"{countryErrors}\n");
        
        if (!AirportValidation(flight, out string airportErrors))
            stringBuilder.Append($"{airportErrors}\n");
        
        errors = stringBuilder.ToString();
        return string.IsNullOrEmpty(errors);
    }

    public static bool PriceValidtion(Flight flight, out string priceErrors)
    {
        var errorList = new List<string>();
        if (flight.EconomyPrice <= 0)
            errorList.Add("- Economy class price must be greater than 0.");

        if (flight.BusinessPrice <= 0)
            errorList.Add("- Business class price must be greater than 0.");

        if (flight.FirstClassPrice <= 0)
            errorList.Add("- First class price must be greater than 0.");

        priceErrors = string.Join("\n", errorList);
        return !errorList.Any();
    }
    public static bool DepartureDateValidation(string departureDate, out string dateErrors)
    {
        var errorList = new List<string>();
        if (!DateTime.TryParse(departureDate, out DateTime _departureDate))
            errorList.Add("- Departure date can't be null and must be in dd-MM-yyyy format.");

        if (_departureDate <= DateTime.Now.AddHours(4))
            errorList.Add("- Departure date must be at least 4 hours from the current time.");

        dateErrors = string.Join("\n", errorList);
        return !errorList.Any();
    }
    public static bool DepartureDateValidation(Flight flight, out string dateErrors)
    {
        var errorList = new List<string>();
        if( flight.DepartureDate is null)
            errorList.Add("- Departure date can't be null and must be in dd-MM-yyyy format.");

        if (flight.DepartureDate <= DateTime.Now.AddHours(4))
            errorList.Add("- Departure date must be at least 4 hours from the current time.");

        dateErrors = string.Join("\n", errorList);
        return !errorList.Any();
    }
    public static bool CountryValidation(Flight flight, out string countryErrors)
    {
        var errorList = new List<string>();
        if (string.IsNullOrWhiteSpace(flight.DepartureCountry))
            errorList.Add("- Departure Country Name is required.");

        if (string.IsNullOrWhiteSpace(flight.DestinationCountry))
            errorList.Add("- Destination Country is required.");

        countryErrors = string.Join("\n", errorList);
        return !errorList.Any();
    }
    public static bool AirportValidation(Flight flight, out string airportErrors)
    {
        var errorList = new List<string>();
        if (string.IsNullOrWhiteSpace(flight.DepartureAirport))
            errorList.Add("- Departure airport is required.");

        if (string.IsNullOrWhiteSpace(flight.ArrivalAirport))
            errorList.Add("- Arrival airport is required.");

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
