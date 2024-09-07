using Airport_Ticket_Booking_System.Entites.FlightManagement;
using Airport_Ticket_Booking_System.Entites.FlightManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.Entites.ManagerManagemnt;
public class DataRepository
{
    private static List<string> ErrorList = new List<string>();
    private static string[]? Data;
    public static void BatchUploadFlights(string fileName)
    {

        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string _filePath = Path.Combine(baseDirectory, "../../../../", fileName);
        if (!File.Exists(_filePath))
        {
            Console.WriteLine("File not found.");
            return;
        }
        try
        {
            Data = File.ReadAllLines(_filePath);
            if (Data.Length == 0)
            {
                Console.WriteLine("The file is empty.");
                return;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing file: {ex.Message}");
        }
    }

    public static List<string> ValidateImportedFlightData()
    {
        if (Data == null || !Data.Any())
        {
            ErrorList.Add("No new data found.");
            return ErrorList;
        }
        foreach (var line in Data?.Skip(1))
        {
            Flight? flight = null;
            var flightDetails = line.Split(',');
            if (FlightValidator.ValidateFlight(flightDetails, out string validationErrors))
            {
                flight = new Flight(
                economyPrice: decimal.Parse(flightDetails[0]),
                businessPrice: decimal.Parse(flightDetails[1]),
                firstClassPrice: decimal.Parse(flightDetails[2]),
                departureCountry: flightDetails[3],
                destinationCountry: flightDetails[4],
                departureDate: DateTime.Parse(flightDetails[5]),
                departureAirport: flightDetails[6],
                arrivalAirport: flightDetails[7]
                );


                FlightsRepository.AddAFlight(flight);
            }
            else
            {
                ErrorList.Add($"""
                                Error with Flight {line}:
                                 - {validationErrors}

                               """);
            }
        }
        Data = null;
        return ErrorList;
    }
    public static void ViewValidationErrorList()
    {
        if (ErrorList?.Count > 0)
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

