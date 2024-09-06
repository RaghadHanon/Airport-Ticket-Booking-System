using Airport_Ticket_Booking_System.Entites.BookingManagement;
using Airport_Ticket_Booking_System.Entites.FlightManagment;
using Airport_Ticket_Booking_System.Entites.PassengersManager;
using Airport_Ticket_Booking_System.Utilities;
using System.Security.Cryptography;

namespace Airport_Ticket_Booking_System;
internal class Program
{
    static void Main(string[] args)
    {
        FileStorage.InitializeSampleData();

        Console.WriteLine("\nYou want to use the system as:");
        Console.WriteLine("1. Passenger");
        Console.WriteLine("2. Manager");
        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                PassengerPage();
                break;
            case "2":
                ManagerPage();
                break;
            default:
                Console.WriteLine("Invalid choice. Please select a valid option.");
                break;
        }


        Console.WriteLine("Welcome to the Airport Ticket Booking System!");
        static void PassengerPage() {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nMain Menu:");
                Console.WriteLine("1. Show Available Flights");
                Console.WriteLine("2. Search Flights");
                Console.WriteLine("3. Book a Flight");
                Console.WriteLine("4. Manage Bookings");
                Console.WriteLine("5. Exit");
                Console.Write("\nPlease select an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        PassengerUI.SearchAvailableFlights();
                        break;
                    case "2":
                        PassengerUI.SearchAvailableFlights();
                        break;
                    case "3":
                        PassengerUI.BookAFlight();
                        break;
                    case "4":
                        PassengerUI.ManageBookings();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }

        static void ManagerPage() { }
        Console.WriteLine("Thank you for using the Airport Ticket Booking System!");
    }

   


   
}
