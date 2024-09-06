using Airport_Ticket_Booking_System.Entites.FlightManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.Entites.FlightManagement;
public static class FlightValidator
{
    public static bool ValidateFlight(Flight flight, out string errors)
    {
        var errorList = new List<string>();

        if (string.IsNullOrWhiteSpace(flight.DepartureCountry))
            errorList.Add("Departure country is required.");

        if (string.IsNullOrWhiteSpace(flight.DestinationCountry))
            errorList.Add("Destination country is required.");

        if (flight.DepartureDate < DateTime.Now)
            errorList.Add("Departure date must be in the future.");

        if (flight.ClassPriceMap[ClassOfFlight.Economy] <= 0)
            errorList.Add("Economy class price must be greater than zero.");

        if (flight.ClassPriceMap[ClassOfFlight.Business] <= 0)
            errorList.Add("Business class price must be greater than zero.");

        if (flight.ClassPriceMap[ClassOfFlight.FirstClass] <= 0)
            errorList.Add("First class price must be greater than zero.");

        errors = string.Join("\n- ", errorList);
        return !errorList.Any();
    }
    public static void DisplayValidationRules()
    {
        var validationRules = new List<(string Field, string Type, string Constraints)>
    {
        ("Departure Country", "Free Text", "Required"),
        ("Destination Country", "Free Text", "Required"),
        ("Departure Date", "Date Time", "Required, Allowed Range: Today to Future"),
        ("Departure Airport", "Free Text", "Required"),
        ("Arrival Airport", "Free Text", "Required"),
        ("Economy Price", "Decimal", "Required, Must be greater than 0"),
        ("Business Price", "Decimal", "Required, Must be greater than 0"),
        ("First Class Price", "Decimal", "Required, Must be greater than 0")
    };

        Console.WriteLine("--- Validation Rules ---");
        foreach (var rule in validationRules)
        {
            Console.WriteLine($"- {rule.Field}:\n    Type: {rule.Type}\n    Constraints: {rule.Constraints}");
        }
    }


}
