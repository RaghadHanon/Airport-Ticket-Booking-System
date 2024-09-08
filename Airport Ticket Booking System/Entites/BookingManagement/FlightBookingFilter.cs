using Airport_Ticket_Booking_System.Entites.FlightManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.Entites.BookingManagement;
public static class FlightBookingFilter
{
    public static void ShowAvailableFlights()
    {
        var flights = FlightsRepository.GetAllFlights(DateTime.Now.AddHours(2));
        if (flights.Any())
        {
            Console.WriteLine($"Available flights departing after {DateTime.Now.AddHours(2)}:\n ");
            foreach (var flight in flights)
                Console.WriteLine(flight);
        }
        else
        {
            Console.WriteLine("No available flights at the moment.");
        }
    }
    public static void ShowAvailableFlightsByDate(DateTime? date)
    {
        if (date?.CompareTo(DateTime.Now.AddHours(2)) <= 0)
        {
            Console.WriteLine("The selected date is either in the past or less than 2 hours from now. Please choose a date at least 2 hours in the future.");
            return;
        }

        var flights = FlightsRepository.GetByDate(date);
        if (flights.Any())
        {
            Console.WriteLine($"Available flights departing at {date}:\n ");
            foreach (var flight in flights)
                Console.WriteLine(flight);
        }
        else
        {
            Console.WriteLine("No available flights at the moment.");
        }
        
    }
    public static void ShowFlightsByPrice(decimal price)
    {
        var flights = FlightsRepository.GetByPrice(price, DateTime.Now.AddHours(2));
        if (flights.Any())
        {
            Console.WriteLine($"Available flights matching the price {price} after {DateTime.Now.AddHours(2)}:\n ");
            foreach (var flight in flights)
            {
                ClassOfFlight classOfFlight = flight.ClassPriceMap.FirstOrDefault(x => x.Value == price).Key;

                Console.WriteLine($"\"{classOfFlight} class\" matches your specifications\n {flight}");
            }
        }
        else
        {
            Console.WriteLine("No available flights at the moment.");
        }
    }
    public static void ShowFlightsByDepartureCountry(string departureCountry)
    {
        var flights = FlightsRepository.GetByDepartureCountry(departureCountry, DateTime.Now.AddHours(2));
        if (flights.Any())
        {
            Console.WriteLine($"Available flights departing from {departureCountry} after {DateTime.Now.AddHours(2)}:\n ");
            foreach (var flight in flights)
            {
                Console.WriteLine(flight);
            }
        }
        else
        {
            Console.WriteLine("No available flights at the moment.");
        }
    }
    public static void ShowFlightsByDestinationCountry(string destinationCountry)
    {
        var flights = FlightsRepository.GetByDestinationCountry(destinationCountry, DateTime.Now.AddHours(2));
        if (flights.Any())
        {
            Console.WriteLine($"Available flights to {destinationCountry} after {DateTime.Now.AddHours(2)}:\n ");
            foreach (var flight in flights)
            {
                Console.WriteLine(flight);
            }
        }
        else
        {
            Console.WriteLine("No available flights at the moment.");
        }
    }
    public static void ShowFlightsByDepartureAirport(string departureAirport)
    {
        var flights = FlightsRepository.GetByDepartureAirport(departureAirport, DateTime.Now.AddHours(2));
        if (flights.Any())
        {
            Console.WriteLine($"Available flights departing from {departureAirport} Airport after {DateTime.Now.AddHours(2)}:\n ");
            foreach (var flight in flights)
            {
                Console.WriteLine(flight);
            }
        }
        else
        {
            Console.WriteLine("No available flights at the moment.");
        }
    }
    public static void ShowFlightsByArrivalAirport(string arrivalAirport)
    {
        var flights = FlightsRepository.GetByArrivalAirport(arrivalAirport, DateTime.Now.AddHours(2));
        if (flights.Any())
        {
            Console.WriteLine($"Available flights to {arrivalAirport} Airport after {DateTime.Now.AddHours(2)}:\n ");
            foreach (var flight in flights)
            {
                Console.WriteLine(flight);
            }
        }
        else
        {
            Console.WriteLine("No available flights at the moment.");
        }
    }
}