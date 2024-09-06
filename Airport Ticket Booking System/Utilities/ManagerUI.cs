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
public class ManagerUI
{
    public static void ShowMenu()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\n--- Manager Menu ---");
            Console.WriteLine("1. Show All Bookings");
            Console.WriteLine("2. Search Bookings");
            Console.WriteLine("3. Show All Flights");
            Console.WriteLine("4. Batch Flight Upload");
            Console.WriteLine("5. Validate Imported Flight Data");
            Console.WriteLine("6. View Validation Error List");
            Console.WriteLine("7. Display Validation Rules");
            Console.WriteLine("8. Exit");
            Console.Write("Select an option: ");

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
                    ManagerController.ViewValidationErrorList();
                    break;
                case "7":
                    DisplayValidationRules();
                    break;
                case "8":
                    exit = true;
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
        foreach (var flight in FlightsManager.GetAllFlights())
        {
            Console.WriteLine($"{flight}");
        }
    }
    public static void SearchBookings()
    {
        Console.WriteLine("\n--- Search Bookings ---");
        Console.WriteLine("1. By Flight ID");
        Console.WriteLine("2. By Price");
        Console.WriteLine("3. By Departure Country");
        Console.WriteLine("4. By Destination Country");
        Console.WriteLine("5. By Departure Date");
        Console.WriteLine("6. By Departure Airport");
        Console.WriteLine("7. By Arrival Airport");
        Console.WriteLine("8. By Passenger ID");
        Console.WriteLine("9. By Flight Class");
        Console.WriteLine("10. Exit");
        Console.Write("Select a filter option: ");
        string filterOption = Console.ReadLine();
        switch (filterOption)
        {
            case "1":
                Console.Write("Enter Flight ID: ");
                if (int.TryParse(Console.ReadLine(), out int flightId))
                {
                    BookingFilter.ShowBookingsByFlight(flightId);
                }
                else
                {
                    Console.WriteLine("Invalid Flight ID.");
                }
                break;
            case "2":
                Console.Write("Enter Price: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal price))
                {
                    BookingFilter.ShowBookingsByPrice(price);
                }
                else
                {
                    Console.WriteLine("Invalid Price.");
                }
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
                if (DateTime.TryParse(Console.ReadLine(), out DateTime depDate))
                {
                    BookingFilter.ShowBookingsByDate(depDate);
                }
                else
                {
                    Console.WriteLine("Invalid Date.");
                }
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
                if (int.TryParse(Console.ReadLine(), out int passengerId))
                {
                    BookingFilter.ShowBookingsByPassenger(passengerId);
                }
                else
                {
                    Console.WriteLine("Invalid Passenger ID.");
                }
                break;
            case "9":
                Console.WriteLine("Select Class: (1) Economy, (2) Business, (3) First Class");
                if (int.TryParse(Console.ReadLine(), out int classOption))
                {
                    ClassOfFlight flightClass = classOption switch
                    {
                        1 => ClassOfFlight.Economy,
                        2 => ClassOfFlight.Business,
                        3 => ClassOfFlight.FirstClass,
                        _ => throw new ArgumentException("Invalid class option")
                    };
                    BookingFilter.ShowBookingsByClassFlight(flightClass);
                }
                else
                {
                    Console.WriteLine("Invalid Class Option.");
                }
                break;
            case "10":
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }

    }

    public static void BatchUploadFlights()
    {
        Console.Write("\nEnter the file name for batch flight upload (CSV format): ");
        string filePath = Console.ReadLine();
        try
        {
            ManagerController.BatchUploadFlights(filePath);
            Console.WriteLine("Batch flight upload successful.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during batch upload: {ex.Message}");
        }
    }

    public static void ValidateFlightData()
    {
        ManagerController.ValidateImportedFlightData();
        ManagerController.ViewValidationErrorList();
    }

    public static void DisplayValidationRules()
    {
        FlightValidator.DisplayValidationRules();
    }
}