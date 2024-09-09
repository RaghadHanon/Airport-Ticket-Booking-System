using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Claims;
using Airport_Ticket_Booking_System.Entites.PassengersManager;
using Airport_Ticket_Booking_System.Entites.FlightManagement;

namespace Airport_Ticket_Booking_System.Entites.FlightManagment;
public static class FlightRepository
{
    private static List<Flight> _flights = new List<Flight>();
    public static List<Flight> Flights { get; } = _flights;
    public static Flight? AddFlight(Flight flight)
    {
        if (FlightValidation.ValidateFlight(flight, out string errors))
        {
            throw new ArgumentException($"""

                                         {errors}
                                         """
             );
        }
        _flights.Add(flight);
        return flight;
    }


}