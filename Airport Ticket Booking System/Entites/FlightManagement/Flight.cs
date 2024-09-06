using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Airport_Ticket_Booking_System.Entites.FlightManagment;
public class Flight
{
    private static int _currentId = 0;
    private readonly int _id;
    public int Id { get { return _id; } }
    private Dictionary<ClassOfFlight, decimal> _classPriceMap = new()
    {
        { ClassOfFlight.Economy, 0m },
        { ClassOfFlight.Business, 0m },
        { ClassOfFlight.FirstClass, 0m }
    };

    public Dictionary<ClassOfFlight, decimal> ClassPriceMap { get=>_classPriceMap; }

    private string _departureCountry;
    public string DepartureCountry
    {
        get => _departureCountry;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Departure Country cannot be null.");
            }
            _departureCountry = value;
        }
    }
    private string _destinationCountry;
    public string DestinationCountry
    {
        get => _destinationCountry;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Destination Country cannot be null.");
            }
            _destinationCountry = value;
        }
    }
    public DateTime DepartureDate { get; set; }

    private string _departureAirport;
    public string DepartureAirport
    {
        get => _departureAirport;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Departure Airport cannot be null.");
            }
            _departureAirport = value;
        }
    }

    private string _arrivalAirport;
    public string ArrivalAirport
    {
        get => _arrivalAirport;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Arrival Airport cannot be null.");
            }
            _arrivalAirport = value;
        }
    }



    public Flight(decimal economyPrice, decimal businessPrice, decimal firstClassPrice, string departureCountry, string destinationCountry, DateTime departureDate,
        string departureAirport, string arrivalAirport)
    {
        _id = ++_currentId;
        DepartureCountry = departureCountry;
        DestinationCountry = destinationCountry;
        DepartureDate = departureDate;
        DepartureAirport = departureAirport;
        ArrivalAirport = arrivalAirport;

        SetClassPrice(ClassOfFlight.Economy, economyPrice);
        SetClassPrice(ClassOfFlight.Business, businessPrice);
        SetClassPrice(ClassOfFlight.FirstClass, firstClassPrice);
    }
    public void SetClassPrice(ClassOfFlight classOfFlight, decimal price)
    {
        if (price < 0)
        {
            throw new ArgumentException("Price cannot be negative.");
        }

        _classPriceMap[classOfFlight] = price;
    }
    public string GetPriceList()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Price List:\n        ");
        foreach (var entry in _classPriceMap)
        {
            sb.Append($" - {entry.Key} : {entry.Value}$\n        ");
        }
        return sb.ToString();
    }
    public override string? ToString()
    {
        return $" {{ \n   FlightId {_id}:\r\n        DepartureCountry: \"{DepartureCountry}\",\r\n        DestinationCountry: \"{DestinationCountry}\",\r\n        DepartureDate: \"{DepartureDate}\",\r\n        DepartureAirport: \"{DepartureAirport}\",\r\n        ArrivalAirport: \"{ArrivalAirport}\"\n\r        {GetPriceList()}\n }}";
    }
}
