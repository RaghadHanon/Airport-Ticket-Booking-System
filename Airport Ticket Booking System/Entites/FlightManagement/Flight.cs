using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Airport_Ticket_Booking_System.Utilities;

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
    [FieldType("Decimal"), ValidationRule("Required, Must be greater than 0")]
    public decimal EconomyPrice
    {
        get => _classPriceMap[ClassOfFlight.Economy];
        set { _classPriceMap[ClassOfFlight.Economy] = value; }
    }

    [FieldType("Decimal"), ValidationRule("Required, Must be greater than 0")]
    public decimal BusinessPrice
    {
        get => _classPriceMap[ClassOfFlight.Business];
        set { _classPriceMap[ClassOfFlight.Business] = value; }
    }

    [FieldType("Decimal"), ValidationRule("Required, Must be greater than 0")]
    public decimal FirstClassPrice
    {
        get => _classPriceMap[ClassOfFlight.FirstClass];
        set { _classPriceMap[ClassOfFlight.FirstClass] = value; }
    }
    public Dictionary<ClassOfFlight, decimal> ClassPriceMap { get=>_classPriceMap; }

    private string _departureCountry;

    [FieldType("Free Text"), ValidationRule("Required")]
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

    [FieldType("Free Text"), ValidationRule("Required")]
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
    [FieldType("Date Time"), ValidationRule("Required, Allowed Range: Today to Future")]
    public DateTime DepartureDate { get; set; }

    private string _departureAirport;

    [FieldType("Free Text"), ValidationRule("Required")]
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

    [FieldType("Free Text"), ValidationRule("Required")]
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
        EconomyPrice = economyPrice;
        BusinessPrice = businessPrice;
        FirstClassPrice = firstClassPrice;
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
        return $$""" 
                {
                      FlightId {{_id}}:
                      DepartureCountry: "{{DepartureCountry}}",
                      DestinationCountry: "{{DestinationCountry}}\",
                      DepartureDate: "{{DepartureDate}}",
                      DepartureAirport: "{{DepartureAirport}}",
                      ArrivalAirport: "{{ArrivalAirport}}"
                      {{GetPriceList()}}
                   }
                """;
    }
}
