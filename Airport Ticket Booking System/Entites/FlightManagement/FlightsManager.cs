using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Claims;

namespace Airport_Ticket_Booking_System.Entites.FlightManagment;
public class FlightsManager
{
    private static List<Flight> flights = new List<Flight>();


    public static List<Flight> GetAllFlights()
    {
        return flights;
    }
    public static List<Flight> GetAllFlights(DateTime date)
    {
        return flights.Where(f => f.DepartureDate.CompareTo(date) > 0).ToList();
    }
    public static Flight? GetById(int? id)
    {
        return flights.FirstOrDefault(f => f.Id == id);
    }
    public static List<Flight> GetByPrice(decimal price)
    {
        return flights.Where(f => f.ClassPriceMap.Values.Contains(price)).ToList();
    }
    public static List<Flight> GetByPrice(decimal price, DateTime date)
    {
        return flights.Where(f => f.ClassPriceMap.Values.Contains(price) && f.DepartureDate.CompareTo(date) > 0).ToList();
    }


    public static List<Flight> GetByDepartureCountry(string departureCountry)
    {
        return flights.Where(f => f.DepartureCountry == departureCountry).ToList();
    }
    public static List<Flight> GetByDepartureCountry(string departureCountry, DateTime date)
    {
        return flights.Where(f => f.DepartureCountry == departureCountry && f.DepartureDate.CompareTo(date) > 0).ToList();
    }


    public static List<Flight> GetByDestinationCountry(string destinationCountry)
    {
        return flights.Where(f => f.DestinationCountry == destinationCountry).ToList();
    }
    public static List<Flight> GetByDestinationCountry(string destinationCountry, DateTime date)
    {
        return flights.Where(f => f.DestinationCountry == destinationCountry && f.DepartureDate.CompareTo(date) > 0).ToList();
    }


    public static List<Flight> GetByDepartureDate(DateTime departureDate)
    {
        return flights.Where(f => f.DepartureDate == departureDate).ToList();
    }



    public static List<Flight> GetByDepartureAirport(string departureAirport)
    {
        return flights.Where(f => f.DepartureAirport == departureAirport).ToList();
    }
    public static List<Flight> GetByDepartureAirport(string departureAirport, DateTime date)
    {
        return flights.Where(f => f.DepartureAirport == departureAirport && f.DepartureDate.CompareTo(date) > 0).ToList();
    }




    public static List<Flight> GetByArrivalAirport(string arrivalAirport)
    {
        return flights.Where(f => f.ArrivalAirport == arrivalAirport).ToList();
    }
    public static List<Flight> GetByArrivalAirport(string arrivalAirport, DateTime date)
    {
        return flights.Where(f => f.ArrivalAirport == arrivalAirport && f.DepartureDate.CompareTo(date) > 0).ToList();
    }


}