using Airport_Ticket_Booking_System.Entites.BookingManagement;
using Airport_Ticket_Booking_System.Entites.FlightManagement;
using Airport_Ticket_Booking_System.Entites.FlightManagment;
using Airport_Ticket_Booking_System.Entites.ManagerManagemnt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.Utilities;
public static class ManagerUI
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
            string filterOption = Console.ReadLine();
            switch (filterOption)
            {
                case "1":
                    Console.Write("Enter Flight ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int flightId))
                    {
                        Console.WriteLine("Invalid input.");
                        break;
                    }
                    BookingFilter.ShowBookingsByFlight(flightId);

                    break;
                case "2":
                    Console.Write("Enter Price: ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal price))
                    {
                        Console.WriteLine("Invalid input.");
                        break;
                    }
                    BookingFilter.ShowBookingsByPrice(price);

                    break;
                case "3":
                    Console.Write("Enter Departure Country: ");
                    string depCountry = Console.ReadLine();
                    BookingFilter.ShowBookingsByDepartureCountry(depCountry);
                    break;
                case "4":
                    Console.Write("Enter Destination Country: ");
                    string destCountry = Console.ReadLine();
                    BookingFilter.ShowBookingsByDestinationCountry(destCountry);
                    break;
                case "5":
                    Console.Write("Enter Departure Date (YYYY-MM-DD): ");
                    if (!DateTime.TryParse(Console.ReadLine(), out DateTime depDate))
                    {
                        Console.WriteLine("Invalid input.");
                        break;
                    }
                    BookingFilter.ShowBookingsByDate(depDate);

                    break;
                case "6":
                    Console.Write("Enter Departure Airport: ");
                    string depAirport = Console.ReadLine();
                    BookingFilter.ShowBookingsByDepartureAirport(depAirport);
                    break;
                case "7":
                    Console.Write("Enter Arrival Airport: ");
                    string arrAirport = Console.ReadLine();
                    BookingFilter.ShowFlightsByArrivalAirport(arrAirport);
                    break;
                case "8":
                    Console.Write("Enter Passenger ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int passengerId))
                    {
                        Console.WriteLine("Invalid input.");
                        break;
                    }
                    BookingFilter.ShowBookingsByPassenger(passengerId);

                    break;
                case "9":
                    ClassOfFlight? flightClass = ClassOfFlightInput();
                    if(flightClass is null)
                    {
                        Console.WriteLine("Invalid input.");
                        break;
                    }
                    BookingFilter.ShowBookingsByClassFlight((ClassOfFlight)flightClass);
                    

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
    private static ClassOfFlight? ClassOfFlightInput()
    {
        Console.WriteLine("Select new class: (1) Economy, (2) Business, (3) First Class");
        int newClassOption = int.TryParse(Console.ReadLine(), out int _newClassOption) ? _newClassOption : 0;

        ClassOfFlight? newClassOfFlight = newClassOption switch
        {
            1 => ClassOfFlight.Economy,
            2 => ClassOfFlight.Business,
            3 => ClassOfFlight.FirstClass,
            _ => null
        };

        return newClassOfFlight;
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