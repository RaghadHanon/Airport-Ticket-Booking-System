using Airport_Ticket_Booking_System.Entites.FlightManagment;
using Airport_Ticket_Booking_System.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.Entites.FlightManagement;
public static class FlightValidator
{
    public static bool ValidateFlight(string[] flightDetails, out string errors)
    {
        var errorList = new List<string>();

        if (string.IsNullOrWhiteSpace(flightDetails[3]))
            errorList.Add("Departure country is required.");

        if (string.IsNullOrWhiteSpace(flightDetails[4]))
            errorList.Add("Destination country is required.");

        if (!DateTime.TryParse(flightDetails[5], out DateTime DepartureDate))
            errorList.Add("Departure date must be in format DD/MM/YYYY");

        if (DepartureDate <= DateTime.Now.AddHours(2))
            errorList.Add("Departure date must be at least 2 hours from the current time.");

        if (string.IsNullOrWhiteSpace(flightDetails[6]))
            errorList.Add("Departure Airport is required.");

        if (string.IsNullOrWhiteSpace(flightDetails[7]))
            errorList.Add("Arrival Airport is required.");

        if (decimal.Parse(flightDetails[0]) <= 0)
            errorList.Add("Economy class price must be greater than zero.");

        if (decimal.Parse(flightDetails[1]) <= 0)
            errorList.Add("Business class price must be greater than zero.");

        if (decimal.Parse(flightDetails[2]) <= 0)
            errorList.Add("First class price must be greater than zero.");

        errors = string.Join("\n - ", errorList);
        return !errorList.Any();
    }
    public static bool ValidateFlight(Flight flight, out string errors)
    {
        var errorList = new List<string>();

        if (string.IsNullOrWhiteSpace(flight?.DepartureCountry))
            errorList.Add("Departure country is required.");

        if (string.IsNullOrWhiteSpace(flight?.DestinationCountry))
            errorList.Add("Destination country is required.");

        if (flight?.DepartureDate <= DateTime.Now.AddHours(2))
            errorList.Add("Departure date must be at least 2 hours from the current time.");

        if (flight?.ClassPriceMap[ClassOfFlight.Economy] <= 0)
            errorList.Add("Economy class price must be greater than zero.");

        if (flight?.ClassPriceMap[ClassOfFlight.Business] <= 0)
            errorList.Add("Business class price must be greater than zero.");

        if (flight?.ClassPriceMap[ClassOfFlight.FirstClass] <= 0)
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
                Console.WriteLine($"""
                                   - {property.Name}:
                                        Type: {fieldTypeAttr.Type}
                                        Constraints: {validationRuleAttr.Constraints}

                                   """);
            }
        }
    }
    
}
