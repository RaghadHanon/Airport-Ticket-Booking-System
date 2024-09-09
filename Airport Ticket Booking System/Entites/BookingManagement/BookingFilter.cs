using Airport_Ticket_Booking_System.Entites.FlightManagement;
using Airport_Ticket_Booking_System.Entites.FlightManagment;
using Airport_Ticket_Booking_System.Entites.PassengersManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.Entites.BookingManagement;
public static class BookingFilter
{
    public static void ShowBookings()
    {
        var bookings = BookingQuery.GetAll();
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
    public static void ShowBookingsByPassenger(int passengerId)
    {

        var bookings = BookingQuery.GetByPassenger(passengerId);
        if (bookings.Any())
        {
            Console.WriteLine($"Bookings by Passenger {passengerId}:\n ");
            foreach (var book in bookings)
                Console.WriteLine(book);
        }
        else
        {
            Console.WriteLine("No available Bookings at the moment.");
        }

    }
    public static void ShowBookingsByFlight(int flightId)
    {

        var bookings = BookingQuery.GetByFlight(flightId);
        if (bookings.Any())
        {
            Console.WriteLine($"Bookings on flight {flightId}:\n ");
            foreach (var book in bookings)
                Console.WriteLine(book);
        }
        else
        {
            Console.WriteLine("No available Bookings at the moment.");
        }

    }
    public static void ShowBookingsByClassFlight(ClassOfFlight classOfFlight)
    {

        var bookings = BookingQuery.GetByClassFlight(classOfFlight);
        if (bookings.Any())
        {
            Console.WriteLine($"{classOfFlight} Class Bookings:\n ");
            foreach (var book in bookings)
                Console.WriteLine(book);
        }
        else
        {
            Console.WriteLine("No available Bookings at the moment.");
        }

    }
    
    public static void ShowBookingsByDate(DateTime date)
    {

        var bookings = BookingQuery.GetAll(date);
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
        var bookings = BookingQuery.GetByPrice(price);
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
        var bookings = BookingQuery.GetByDepartureCountry(departureCountry);
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
        var bookings = BookingQuery.GetByDestinationCountry(destinationCountry);
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
        var bookings = BookingQuery.GetByDepartureAirport(departureAirport);
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
        var bookings = BookingQuery.GetByArrivalAirport(arrivalAirport);
        if (bookings.Any())
        {
            Console.WriteLine($"Available flights departing from {arrivalAirport} Airport:\n ");
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