using Airport_Ticket_Booking_System.Entites.FlightManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.Entites.FlightManagement;
public static class FlightQuery
{
    public static List<Flight> GetAll(DateTime? date = null)
    {
        if (date.HasValue)
            return FlightRepository.Flights.Where(f => f.DepartureDate?.CompareTo(date) >= 0).ToList();

        return FlightRepository.Flights;
    }
    public static Flight? GetById(int? id)
    {
        return FlightRepository.Flights.FirstOrDefault(f => f.Id == id);
    }
    public static List<Flight> GetByPrice(decimal price, DateTime? date = null)
    {
        if (date.HasValue)
            return FlightRepository.Flights.Where(f => f.ClassPriceMap.Values.Contains(price) && f.DepartureDate?.CompareTo(date) >= 0).ToList();

        return FlightRepository.Flights.Where(f => f.ClassPriceMap.Values.Contains(price)).ToList();
    }
    public static List<Flight> GetByDepartureDate(DateTime? departureDate)
    {
        return FlightRepository.Flights.Where(f => f.DepartureDate == departureDate).ToList();
    }
    public static List<Flight> GetByDepartureCountry(string departureCountry, DateTime? date = null)
    {
        if (date.HasValue)
            return FlightRepository.Flights.Where(f => f.DepartureCountry == departureCountry && f.DepartureDate?.CompareTo(date) >= 0).ToList();

        return FlightRepository.Flights.Where(f => f.DepartureCountry == departureCountry).ToList();
    }

    public static List<Flight> GetByDestinationCountry(string destinationCountry, DateTime? date = null)
    {
        if (date.HasValue)
            return FlightRepository.Flights.Where(f => f.DestinationCountry == destinationCountry && f.DepartureDate?.CompareTo(date) >= 0).ToList();

        return FlightRepository.Flights.Where(f => f.DestinationCountry == destinationCountry).ToList();
    }
    public static List<Flight> GetByDepartureAirport(string departureAirport, DateTime? date = null)
    {
        if (date.HasValue)
            return FlightRepository.Flights.Where(f => f.DepartureAirport == departureAirport && f.DepartureDate?.CompareTo(date) >= 0).ToList();

        return FlightRepository.Flights.Where(f => f.DepartureAirport == departureAirport).ToList();
    }
    public static List<Flight> GetByArrivalAirport(string arrivalAirport, DateTime? date = null)
    {
        if (date.HasValue)
            return FlightRepository.Flights.Where(f => f.ArrivalAirport == arrivalAirport && f.DepartureDate?.CompareTo(date) >= 0).ToList();

        return FlightRepository.Flights.Where(f => f.ArrivalAirport == arrivalAirport).ToList();
    }

}
