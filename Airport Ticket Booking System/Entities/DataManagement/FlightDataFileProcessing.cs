using Airport_Ticket_Booking_System.Entities.Flights.Core;
using Airport_Ticket_Booking_System.Entities.Flights.Repository;
using Airport_Ticket_Booking_System.Utilities;

namespace Airport_Ticket_Booking_System.Entities.DataManagement;
public class FlightDataFileProcessing : IFlightDataFileProcessing
{
    private List<string> ErrorList = new List<string>();
    private string[]? Data;
    public IFlightRepository FlightRepository {  get; }
    public FlightDataFileProcessing(IFlightRepository flightRepository)
    {
        FlightRepository = flightRepository;
    }

    public void BatchUploadFlights(string fileName)
    {
        var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        var filePath = Path.Combine(baseDirectory, @"..\..\..\..\", fileName);
        var fullPath = Path.GetFullPath(filePath);

        if (!File.Exists(fullPath))
        {
            Console.WriteLine(ErrorMessages.FileNotFount);
            return;
        }
        try
        {
            Data = File.ReadAllLines(filePath);
            if (Data.Length == 0)
            {
                Console.WriteLine(ErrorMessages.FileEmpty);
                return;
            }
            Console.WriteLine("Batch flight upload successful.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ErrorMessages.ProcessingFileError} {ex.Message}");
        }
    }

    public List<string> ValidateImportedFlightData()
    {
        if (Data == null || !Data.Any())
        {
            ErrorList.Add(ErrorMessages.NoNewDataFound);
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
                departureDate: DateTime.TryParse(flightDetails[5], out DateTime _departureDate) ? _departureDate : null,
                departureAirport: flightDetails[6],
                arrivalAirport: flightDetails[7]
                );
            try
            {
                FlightRepository.AddFlight(flight);
            }
            catch (Exception ex)
            {
                ErrorList.Add($"""
                                   Error with Flight {line}: {ex.Message}
                                   """);
            }
        }
        Data = null;
        return ErrorList;
    }

    public void ViewValidationErrorList()
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

