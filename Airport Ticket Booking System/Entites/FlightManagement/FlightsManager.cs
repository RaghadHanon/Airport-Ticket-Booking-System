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
    private static List<Flight> flights = new List<Flight>()
        {
                new Flight(300, 700, 1200, "USA", "UK", new DateTime(2024, 10, 15), "JFK", "LHR"),
new Flight(350, 800, 1300, "France", "Germany", new DateTime(2024, 11, 5), "CDG", "FRA"),
new Flight(650, 900, 1400, "Italy", "Canada", new DateTime(2024, 12, 20), "FCO", "YYZ"),
new Flight(280, 650, 1150, "Japan", "Brazil", new DateTime(2024, 9, 10), "HND", "GRU"),
new Flight(320, 720, 1250, "Australia", "India", new DateTime(2024, 8, 12), "SYD", "DEL"),
new Flight(290, 680, 1180, "Germany", "France", new DateTime(2024, 7, 18), "FRA", "CDG"),
new Flight(310, 760, 1270, "UK", "USA", new DateTime(2024, 5, 22), "LHR", "JFK"),
new Flight(340, 810, 1320, "Brazil", "Italy", new DateTime(2024, 4, 9), "GRU", "FCO"),
new Flight(370, 880, 1350, "Canada", "Australia", new DateTime(2024, 6, 15), "YYZ", "SYD"),
new Flight(350, 650, 1210, "India", "Japan", new DateTime(2024, 3, 1), "DEL", "HND"),
new Flight(330, 770, 1260, "France", "UK", new DateTime(2024, 2, 12), "CDG", "LHR"          ),
new Flight(360, 850, 1370, "Italy", "Germany", new DateTime(2024, 1, 22), "FCO", "FRA"),
new Flight(295, 700, 1200, "Australia", "USA", new DateTime(2024, 12, 5), "SYD", "JFK"),
new Flight(325, 790, 1290, "Germany", "Canada", new DateTime(2024, 11, 9), "FRA", "YYZ"),
new Flight(650, 830, 1330, "Japan", "France", new DateTime(2024, 10, 30), "HND", "CDG"),
new Flight(305, 720, 1190, "Brazil", "India", new DateTime(2024, 9, 18), "GRU", "DEL"),
new Flight(350, 780, 1280, "Canada", "UK", new DateTime(2024, 8, 14), "YYZ", "LHR"),
new Flight(375, 890, 1390, "USA", "Australia", new DateTime(2024, 7, 25), "JFK", "SYD"),
new Flight(290, 700, 1220, "India", "Italy", new DateTime(2024, 6, 11), "DEL", "FCO"),
new Flight(310, 760, 1300, "France", "Brazil", new DateTime(2024, 5, 7), "CDG", "GRU")

        };


    public static List<Flight> GetAllFlights()
    {
        return flights;
    }
    public static List<Flight> GetAllFlights(DateTime date)
    {
        return flights.Where(f => f.DepartureDate.CompareTo(date) > 0).ToList();
    }
    public static Flight GetById(int id)
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