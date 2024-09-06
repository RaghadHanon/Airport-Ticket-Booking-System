using Airport_Ticket_Booking_System.Entites.FlightManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.Entites.BookingManagement;
public class BookingFilter
{
    public static void ShowBookings()
    {
        var bookings = BookingManager.GetAllBookings();
        if (bookings.Any())
        {
            Console.WriteLine($"Bookings List:\n ");
            foreach (var book in bookings)
                Console.WriteLine(book);
        }
        else
        {
            Console.WriteLine("No available bookings at the moment.");
        }
    }
    public static void ShowBookingsByDate(DateTime date)
    {

        var bookings = BookingManager.GetAllBookings(date);
        if (bookings.Any())
        {
            Console.WriteLine($"Bookings on flights departing after {date}:\n ");
            foreach (var book in bookings)
                Console.WriteLine(book);
        }
        else
        {
            Console.WriteLine("No available Bookings at the moment.");
        }

    }

    public static void ShowBookingsByPrice(decimal price)
    {
        var bookings = BookingManager.GetByPrice(price);
        if (bookings.Any())
        {
            Console.WriteLine($"Bookings matching the price {price}:\n ");
            foreach (var book in bookings)
            {
                Console.WriteLine(book);
            }
        }
        else
        {
            Console.WriteLine("No available bookings at the moment.");
        }
    }

    public static void ShowBookingsByDepartureCountry(string departureCountry)
    {
        var bookings = BookingManager.GetByDepartureCountry(departureCountry);
        if (bookings.Any())
        {
            Console.WriteLine($"Available bookings on flights departing from {departureCountry}:\n ");
            foreach (var book in bookings)
            {
                Console.WriteLine(book);
            }
        }
        else
        {
            Console.WriteLine("No available bookings at the moment.");
        }
    }

    public static void ShowBookingsByDestinationCountry(string destinationCountry)
    {
        var bookings = BookingManager.GetByDestinationCountry(destinationCountry);
        if (bookings.Any())
        {
            Console.WriteLine($"Available bookings on flights to {destinationCountry}:\n ");
            foreach (var book in bookings)
            {
                Console.WriteLine(book);
            }
        }
        else
        {
            Console.WriteLine("No available bookings at the moment.");
        }
    }

    public static void ShowBookingsByDepartureAirport(string departureAirport)
    {
        var bookings = BookingManager.GetByDepartureAirport(departureAirport);
        if (bookings.Any())
        {
            Console.WriteLine($"Available flights departing from {departureAirport} Airport:\n ");
            foreach (var book in bookings)
            {
                Console.WriteLine(book);
            }
        }
        else
        {
            Console.WriteLine("No available bookings at the moment.");
        }
    }

    public static void ShowFlightsByArrivalAirport(string arrivalAirport)
    {
        var bookings = FlightsManager.GetByArrivalAirport(arrivalAirport, DateTime.Now);
        if (bookings.Any())
        {
            Console.WriteLine($"Available flights to {arrivalAirport} Airport:\n ");
            foreach (var book in bookings)
            {
                Console.WriteLine(book);
            }
        }
        else
        {
            Console.WriteLine("No available bookings at the moment.");
        }
    }
        
}