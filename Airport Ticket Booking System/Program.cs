using Airport_Ticket_Booking_System.Entites.BookingManagement;
using Airport_Ticket_Booking_System.Entites.FlightManagement;
using Airport_Ticket_Booking_System.Entites.FlightManagment;
using Airport_Ticket_Booking_System.Entites.PassengersManager;
using Airport_Ticket_Booking_System.Utilities;
using System.Security.Cryptography;

namespace Airport_Ticket_Booking_System;
internal class Program
{
    static void Main(string[] args)
    {
        SampleData.InitializeSampleData();
        
        bool isExit = false;
        while (!isExit)
        {
            Console.WriteLine("""

                              You want to use the system as:
                              1. Passenger
                              2. Manager
                              3. Exit

                              """);
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PassengerUI.ShowMenu();
                    break;
                case "2":
                    ManagerUI.ShowMenu();
                    break;
                case "3":
                    isExit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }

        }
        
        Console.WriteLine("Thank you for using the Airport Ticket Booking System!");
    }

   


   
}
