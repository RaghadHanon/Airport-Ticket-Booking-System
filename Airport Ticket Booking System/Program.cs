﻿using Airport_Ticket_Booking_System.Entites.BookingManagement;
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

        Console.WriteLine("Welcome to the Airport Ticket Booking System!");

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nYou want to use the system as:");
            Console.WriteLine("1. Passenger");
            Console.WriteLine("2. Manager");
            Console.WriteLine("3. Exit");
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
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }

        }
        
        Console.WriteLine("Thank you for using the Airport Ticket Booking System!");
    }

   


   
}
