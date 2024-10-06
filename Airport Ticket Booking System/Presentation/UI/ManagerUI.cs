using Airport_Ticket_Booking_System.Entities.Bookings.Filter;
using Airport_Ticket_Booking_System.Entities.DataManagement;
using Airport_Ticket_Booking_System.Entities.Flights.Core;
using Airport_Ticket_Booking_System.Entities.Flights.Query;
using Airport_Ticket_Booking_System.Presentation.EntitiesPrinters;
using Airport_Ticket_Booking_System.Utilities;

namespace Airport_Ticket_Booking_System.Presentation.UI;
public class ManagerUI
{
    public IBookingFilter BookingFilter { get; }
    public IFlightQuery FlightQuery { get; }
    public IFlightDataFileProcessing FlightDataFileProcessing { get; }
    public ManagerUI(IBookingFilter bookingFilter, IFlightQuery flightQuery, IFlightDataFileProcessing flightDataFileProcessing)
    {
        BookingFilter = bookingFilter;
        FlightQuery = flightQuery;
        FlightDataFileProcessing = flightDataFileProcessing;
    }

    public void ShowMenu()
    {
        var isExit = false;
        while (!isExit)
        {
            Console.WriteLine("""

                               --- Manager Menu ---

                               1. Show All Bookings 
                               2. Search Bookings
                               3. Show All Flights
                               4. Batch Flight Upload
                               5. Validate Imported Flight Data
                               6. View Validation Error List
                               7. Display Validation Rules
                               8. Exit

                               Select an option: 
                               """);

            switch (Console.ReadLine())
            {
                case "1":
                    BookingFilter.ShowBookings();
                    break;
                case "2":
                    SearchBookings();
                    break;
                case "3":
                    VewAllFlights();
                    break;
                case "4":
                    BatchUploadFlights();
                    break;
                case "5":
                    ValidateFlightData();
                    break;
                case "6":
                    FlightDataFileProcessing.ViewValidationErrorList();
                    break;
                case "7":
                    DisplayValidationRules();
                    break;
                case "8":
                    isExit = true;
                    break;
                default:
                    Console.WriteLine(ErrorMessages.InvalidOption);
                    break;
            }
        }
    }

    public void VewAllFlights()
    {
        Console.WriteLine(FlightPrinter.PrintFlights(FlightQuery.FilterFlights(), "\n--- Flights ---"));
    }

    public void SearchBookings()
    {
        var isExit = false;
        while (!isExit)
        {
            Console.WriteLine("""

                           --- Search Bookings ---

                           1. By Flight ID
                           2. By Price
                           3. By Departure Country
                           4. By Destination Country
                           5. By Departure Date
                           6. By Departure Airport
                           7. By Arrival Airport
                           8. By Passenger ID
                           9. By Flight Class
                           10. Exit

                          Select a filter option: 
                          """);

            switch (Console.ReadLine())
            {
                case "1":
                    int? flightId = InputGathering.GetFlightId();
                    if (flightId != null)
                        BookingFilter.ShowBookingsByFlight(flightId.Value);
                    break;
                case "2":
                    decimal? price = InputGathering.GetPriceInput();
                    if (price != null)
                        BookingFilter.ShowBookingsByPrice(price.Value);
                    break;
                case "3":
                    string depCountry = InputGathering.GetStringInput("departure country");
                    BookingFilter.ShowBookingsByDepartureCountry(depCountry);
                    break;
                case "4":
                    string destCountry = InputGathering.GetStringInput("destination country");
                    BookingFilter.ShowBookingsByDestinationCountry(destCountry);
                    break;
                case "5":
                    DateTime? depDate = InputGathering.GetDateInput();
                    if (depDate != null)
                        BookingFilter.ShowBookingsByDate(depDate.Value);
                    break;
                case "6":
                    string depAirport = InputGathering.GetStringInput("departure airport");
                    BookingFilter.ShowBookingsByDepartureAirport(depAirport);
                    break;
                case "7":
                    string arrAirport = InputGathering.GetStringInput("arrival airport");
                    BookingFilter.ShowFlightsByArrivalAirport(arrAirport);
                    break;
                case "8":
                    int? passengerId = InputGathering.GetPassengerId();
                    if (passengerId != null)
                        BookingFilter.ShowBookingsByPassenger(passengerId.Value);
                    break;
                case "9":
                    ClassOfFlight? flightClass = InputGathering.GetClassOfFlightInput();
                    if (flightClass != null)
                        BookingFilter.ShowBookingsByClassFlight(flightClass.Value);
                    break;
                case "10":
                    isExit = true;
                    break;
                default:
                    Console.WriteLine(ErrorMessages.InvalidOption);
                    break;
            }
        }
    }

    public void BatchUploadFlights()
    {
        Console.Write("\nEnter the file name for batch flight upload (CSV format): ");
        var filePath = Console.ReadLine();
        try
        {
            FlightDataFileProcessing.BatchUploadFlights(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ErrorMessages.BatchUploadError} {ex.Message}");
        }
    }

    public void ValidateFlightData()
    {
        FlightDataFileProcessing.ValidateImportedFlightData();
    }

    public static void DisplayValidationRules()
    {
        FlightValidation.DisplayValidationRules();
    }
}