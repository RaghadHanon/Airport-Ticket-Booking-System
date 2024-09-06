using Airport_Ticket_Booking_System.Entites.FlightManagement;
using Airport_Ticket_Booking_System.Entites.FlightManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.Entites.ManagerManagemnt;
public class ManagerController
{
    private static string[]? Data;
    public static void BatchUploadFlights(string fileName)
    {

        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string _filePath = Path.Combine(baseDirectory,"../../../../", fileName);
        if (!File.Exists(_filePath))
        {
            Console.WriteLine("File not found.");
            return;
        }
        try
        {
            Data = File.ReadAllLines(_filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing file: {ex.Message}");
        }
        ValidateImportedFlightData();
    }
    
    public static List<string> ValidateImportedFlightData()
    {
        List<string> ErrorList = new List<string>();
        foreach (var line in Data?.Skip(1))
        {
            var flightDetails = line.Split(',');

            var flight = new Flight(
                economyPrice: decimal.Parse(flightDetails[0]),
                businessPrice: decimal.Parse(flightDetails[1]),
                firstClassPrice: decimal.Parse(flightDetails[2]),
                departureCountry: flightDetails[3],
                destinationCountry: flightDetails[4],
                departureDate: DateTime.Parse(flightDetails[5]),
                departureAirport: flightDetails[6],
                arrivalAirport: flightDetails[7]
            );

            if (FlightValidator.ValidateFlight(flight, out string validationErrors))
            {
                FlightsManager.AddAFlight(flight);
            }
            else
            {
                ErrorList.Add($"Error with Flight {flight.Id}:\n- {validationErrors}\n");
            }
        }
        return ErrorList;
    }
    public static void ViewValidationErrorList()
    {
        List<string> ErrorList = ValidateImportedFlightData();
        if (ErrorList.Count > 0)
        {
            Console.WriteLine("\nValidation Errors:");
            foreach (var error in ErrorList)
            {
                Console.WriteLine(error);
            }
        }
        else
        {
            Console.WriteLine("All flights are valid.");
        }
    }

}

