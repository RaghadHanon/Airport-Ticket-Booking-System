using Airport_Ticket_Booking_System.Entites.BookingManagement;
using Airport_Ticket_Booking_System.Entites.FlightManagement;
using Airport_Ticket_Booking_System.Entites.FlightManagment;
using Airport_Ticket_Booking_System.Entites.ManagerManagemnt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.Utilities; public static class ManagerUI
{
    public static void ShowMenu()
    {
        bool isExit = false;
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
                    DataRepository.ViewValidationErrorList();
                    break;
                case "7":
                    DisplayValidationRules();
                    break;
                case "8":
                    isExit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    public static void VewAllFlights()
    {
        Console.WriteLine("\n--- Flights ---");
        foreach (var flight in FlightQuery.GetAll())
        {
            Console.WriteLine($"{flight}");
        }
    }

    public static void SearchBookings()
    {
        bool isExit = false;
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
                    {
                        BookingFilter.ShowBookingsByFlight(flightId.Value);
                    }
                    break;
                case "2":
                    decimal? price = InputGathering.GetPriceInput();
                    if (price != null)
                    {
                        BookingFilter.ShowBookingsByPrice(price.Value);
                    }
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
                    {
                        BookingFilter.ShowBookingsByDate(depDate.Value);
                    }
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
                    {
                        BookingFilter.ShowBookingsByPassenger(passengerId.Value);
                    }
                    break;
                case "9":
                    ClassOfFlight? flightClass = InputGathering.GetClassOfFlightInput();
                    if (flightClass != null)
                    {
                        BookingFilter.ShowBookingsByClassFlight(flightClass.Value);
                    }
                    break;
                case "10":
                    isExit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    public static void BatchUploadFlights()
    {
        Console.Write("\nEnter the file name for batch flight upload (CSV format): ");
        string filePath = Console.ReadLine();
        try
        {
            DataRepository.BatchUploadFlights(filePath);
            Console.WriteLine("Batch flight upload successful.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during batch upload: {ex.Message}");
        }
    }

    public static void ValidateFlightData()
    {
        DataRepository.ValidateImportedFlightData();
        DataRepository.ViewValidationErrorList();
    }

    public static void DisplayValidationRules()
    {
        FlightValidation.DisplayValidationRules();
    }
}
