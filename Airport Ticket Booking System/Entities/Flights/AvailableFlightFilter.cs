using Airport_Ticket_Booking_System.Entites.BookingManagement;
using Airport_Ticket_Booking_System.Entites.FlightManagement;
using Airport_Ticket_Booking_System.Entites.FlightManagment;
using Airport_Ticket_Booking_System.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Airport_Ticket_Booking_System.Entities.Flights;
public static class AvailableFlightFilter
{
    public static void ShowAvailableFlights()
    {
        string flights = FlightPrinter.PrintFlights(FlightQuery.GetAll(DateTime.Now.AddHours(2)), $"Available flights departing after {DateTime.Now.AddHours(2)}:\n ");
        Console.WriteLine(flights);
    }
    public static void ShowAvailableFlightsByDate(DateTime? date)
    {
        if (date?.CompareTo(DateTime.Now.AddHours(2)) <= 0)
        {
            Console.WriteLine("The selected date is either in the past or less than 2 hours from now. Please choose a date at least 2 hours in the future.");
            return;
        }
        string flights = FlightPrinter.PrintFlights(FlightQuery.GetByDepartureDate(date), $"Available flights departing at {date}:\n ");
        Console.WriteLine(flights);
    }
    public static void ShowFlightsByPrice(decimal price)
    {
        var flights = FlightQuery.GetByPrice(price, DateTime.Now.AddHours(2));
        if (flights.Any())
        {
            Console.WriteLine($"Available flights matching the price {price} after {DateTime.Now.AddHours(2)}:\n ");
            foreach (var flight in flights)
            {
                ClassOfFlight classOfFlight = flight.ClassPriceMap.FirstOrDefault(x => x.Value == price).Key;
                Console.WriteLine($"\n \"{classOfFlight} class\" matches your specifications\n {new FlightPrinter(flight).PrintFlight()}");
            }
        }
        else
        {
            Console.WriteLine("No available flights at the moment.");
        }
    }
    public static void ShowFlightsByDepartureCountry(string departureCountry)
    {
        string flights = FlightPrinter.PrintFlights(FlightQuery.GetByDepartureCountry(departureCountry, DateTime.Now.AddHours(2)), $"Available flights departing from {departureCountry} after {DateTime.Now.AddHours(2)}:\n ");
        Console.WriteLine(flights);
    }
    public static void ShowFlightsByDestinationCountry(string destinationCountry)
    {
        string flights = FlightPrinter.PrintFlights(FlightQuery.GetByDestinationCountry(destinationCountry, DateTime.Now.AddHours(2)), $"Available flights to {destinationCountry} after {DateTime.Now.AddHours(2)}:\n ");
        Console.WriteLine(flights);
    }
    public static void ShowFlightsByDepartureAirport(string departureAirport)
    {
        string flights = FlightPrinter.PrintFlights(FlightQuery.GetByDepartureAirport(departureAirport, DateTime.Now.AddHours(2)), $"Available flights departing from {departureAirport} Airport after {DateTime.Now.AddHours(2)}:\n ");
        Console.WriteLine(flights);
    }
    public static void ShowFlightsByArrivalAirport(string arrivalAirport)
    {
        string flights = FlightPrinter.PrintFlights(FlightQuery.GetByArrivalAirport(arrivalAirport, DateTime.Now.AddHours(2)), $"Available flights to {arrivalAirport} Airport after {DateTime.Now.AddHours(2)}:\n ");
        Console.WriteLine(flights);
    }
}