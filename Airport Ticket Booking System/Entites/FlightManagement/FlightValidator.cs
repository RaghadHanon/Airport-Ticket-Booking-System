using Airport_Ticket_Booking_System.Entites.FlightManagment;
using Airport_Ticket_Booking_System.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        var flightType = typeof(Flight); 

        Console.WriteLine("\n--- Validation Rules ---");

        foreach (var property in flightType.GetProperties())
        {
            var fieldTypeAttr = property.GetCustomAttribute<FieldTypeAttribute>();
            var validationRuleAttr = property.GetCustomAttribute<ValidationRuleAttribute>();

            if (fieldTypeAttr != null && validationRuleAttr != null)
            {
                Console.WriteLine($"- {property.Name}:");
                Console.WriteLine($"    Type: {fieldTypeAttr.Type}");
                Console.WriteLine($"    Constraints: {validationRuleAttr.Constraints}\n");
            }
        }
    }
    
}
