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
        var bookings = BookingRepository.GetAll();
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

        var bookings = BookingRepository.GetByPassenger(passengerId);
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

        var bookings = BookingRepository.GetByFlight(flightId);
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

        var bookings = BookingRepository.GetByClassFlight(classOfFlight);
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

        var bookings = BookingRepository.GetAll(date);
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
        var bookings = BookingRepository.GetByPrice(price);
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
        var bookings = BookingRepository.GetByDepartureCountry(departureCountry);
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
        var bookings = BookingRepository.GetByDestinationCountry(destinationCountry);
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
        var bookings = BookingRepository.GetByDepartureAirport(departureAirport);
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
        var bookings = BookingRepository.GetByArrivalAirport(arrivalAirport);
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