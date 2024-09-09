using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Airport_Ticket_Booking_System.Utilities;
using System.IO;

namespace Airport_Ticket_Booking_System.Entites.FlightManagment;
public class Flight
{
    private static int _currentId = 0;
    private readonly int _id;

    private Dictionary<ClassOfFlight, decimal> _classPriceMap;

    public Flight(decimal economyPrice, decimal businessPrice, decimal firstClassPrice, string departureCountry, string destinationCountry, DateTime? departureDate,
        string departureAirport, string arrivalAirport)
    {
        _id = ++_currentId;
        DepartureCountry = departureCountry;
        DestinationCountry = destinationCountry;
        DepartureDate = departureDate;
        DepartureAirport = departureAirport;
        ArrivalAirport = arrivalAirport;

        _classPriceMap = new Dictionary<ClassOfFlight, decimal>
        {
            { ClassOfFlight.Economy, economyPrice },
            { ClassOfFlight.Business, businessPrice},
            { ClassOfFlight.FirstClass, firstClassPrice }
        };

    }

    public int Id { get { return _id; } }

    public Dictionary<ClassOfFlight, decimal> ClassPriceMap { get => _classPriceMap; }

    [FieldType("Decimal"), ValidationRule("Required, Must be greater than 0")]
    public decimal EconomyPrice { get=> _classPriceMap[ClassOfFlight.Economy]; set { _classPriceMap[ClassOfFlight.Economy] = value; } }

    [FieldType("Decimal"), ValidationRule("Required, Must be greater than 0")]
    public decimal BusinessPrice { get => _classPriceMap[ClassOfFlight.Business]; set { _classPriceMap[ClassOfFlight.Business] = value; } }

    [FieldType("Decimal"), ValidationRule("Required, Must be greater than 0")]
    public decimal FirstClassPrice { get => _classPriceMap[ClassOfFlight.FirstClass]; set { _classPriceMap[ClassOfFlight.FirstClass] = value; } }



    [FieldType("Free Text"), ValidationRule("Required")]
    public string? DepartureCountry { get; set; }

    [FieldType("Free Text"), ValidationRule("Required")]
    public string? DestinationCountry { get; set; }


    [FieldType("Date Time"), ValidationRule("Required, Allowed Range: Today to Future")]
    public DateTime? DepartureDate { get; set; }


    [FieldType("Free Text"), ValidationRule("Required")]
    public string? DepartureAirport { get; set; }

    [FieldType("Free Text"), ValidationRule("Required")]
    public string? ArrivalAirport { get; set; }


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
                  Prices: 
                  - Economy: {{EconomyPrice}}
                  - Business: {{BusinessPrice}}
                  - First Class: {{FirstClassPrice}}
              }

            """;

    }
}
