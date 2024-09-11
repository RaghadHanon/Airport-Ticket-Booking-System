using Airport_Ticket_Booking_System.Entites.FlightManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.UI;
public static class InputGathering
{
    public static int? GetPassengerId()
    {
        Console.Write("\nEnter Passenger ID: ");
        if (int.TryParse(Console.ReadLine(), out int passengerId))
            return passengerId;
        
        Console.WriteLine("Invalid input.");
        return null;
    }

    public static int? GetFlightId()
    {
        Console.WriteLine("Please enter the flight ID you want to book:");
        if (int.TryParse(Console.ReadLine(), out int flightId))
            return flightId;
        
        Console.WriteLine("Invalid input.");
        return null;
    }

    public static ClassOfFlight? GetClassOfFlightInput()
    {
        Console.WriteLine("Select class: (1) Economy, (2) Business, (3) First Class");
        if (int.TryParse(Console.ReadLine(), out int classOption))
        {
            return classOption switch
            {
                1 => ClassOfFlight.Economy,
                2 => ClassOfFlight.Business,
                3 => ClassOfFlight.FirstClass,
                _ => null
            };
        }
        Console.WriteLine("Invalid input.");
        return null;
    }
    public static decimal? GetPriceInput()
    {
        Console.WriteLine("Enter price:");
        if (decimal.TryParse(Console.ReadLine(), out decimal price))
            return price;
        
        Console.WriteLine("Invalid input.");
        return null;
    }

    public static string GetStringInput(string inputType)
    {
        Console.WriteLine($"Enter {inputType}:");
        return Console.ReadLine();
    }

    public static DateTime? GetDateInput()
    {
        Console.WriteLine("Enter departure date (MM-DD-YYYY):");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
            return date;
        
        Console.WriteLine("Invalid date.");
        return null;
    }
    public static bool ConfirmModification(string itemType)
    {
        Console.WriteLine($"Do you want to change the {itemType}? (y/n)");
        string response = Console.ReadLine()?.ToLower();
        return response == "y";
    }
    public static int? GetBookingId(string action)
    {
        Console.WriteLine($"Enter booking ID to {action}:");
        if (int.TryParse(Console.ReadLine(), out int bookingId))
            return bookingId;
        
        Console.WriteLine("Invalid input.");
        return null;
    }
}