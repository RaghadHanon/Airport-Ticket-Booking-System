﻿using Airport_Ticket_Booking_System.Presentation;
using Airport_Ticket_Booking_System.Utilities;

namespace Airport_Ticket_Booking_System;
internal class Program
{
    static void Main(string[] args)
    {
        SampleData.InitializeSampleData();
        var isExit = false;
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
                    Console.WriteLine(ErrorMessages.InvalidChoice);
                    break;
            }
        }
        Console.WriteLine("Thank you for using the Airport Ticket Booking System!");
    }
}
