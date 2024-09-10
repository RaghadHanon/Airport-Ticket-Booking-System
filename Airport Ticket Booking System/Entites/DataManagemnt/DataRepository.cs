using Airport_Ticket_Booking_System.Entites.FlightManagement;
using Airport_Ticket_Booking_System.Entites.FlightManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.Entites.ManagerManagemnt;
public static class DataRepository
{
    private static List<string> ErrorList = new List<string>();
    private static string[]? Data;
    public static void BatchUploadFlights(string fileName)
    {

        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string filePath = Path.Combine(baseDirectory, @"..\..\..\..\", fileName);
        string fullPath = Path.GetFullPath(filePath);

        if (!File.Exists(fullPath))
        {
            Console.WriteLine("File not found.");
            return;
        }
        try
        {
            Data = File.ReadAllLines(filePath);
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
            var flightDetails = line.Split(',');
            Flight flight = new Flight(
                economyPrice: decimal.Parse(flightDetails[0]),
                businessPrice: decimal.Parse(flightDetails[1]),
                firstClassPrice: decimal.Parse(flightDetails[2]),
                departureCountry: flightDetails[3],
                destinationCountry: flightDetails[4],
                departureDate : DateTime.TryParse(flightDetails[5], out DateTime _departureDate) ? _departureDate : null,
                departureAirport: flightDetails[6],
                arrivalAirport: flightDetails[7]
                );

                try
                {
                    FlightRepository.AddFlight(flight);
                }catch( Exception ex)
                {
                    ErrorList.Add($"""
                                   Error with Flight {line}: {ex.Message}
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

