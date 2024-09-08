using Airport_Ticket_Booking_System.Entites.FlightManagment;
using Airport_Ticket_Booking_System.Entites.PassengersManager;
using Airport_Ticket_Booking_System.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.Entites.BookingManagement;
public static class BookValidator
{
    public static bool IsBookValid(Enum classOfFlight, Flight flight, Passenger passenger, out string errors)
    {
        var errorList = new List<string>();

        if (!IsClassOfFlightValid(classOfFlight, out string classOfFlightErrors) )
            errorList.Add(classOfFlightErrors);

        if (!IsFlightValid(flight, out string flightErrors))
            errorList.Add(flightErrors);

        if (!IsPassengerValid(passenger, out string passengerErrors))
            errorList.Add(passengerErrors);

        errors = string.Join("\n", errorList);
        return !errorList.Any();
    }

    public static bool IsClassOfFlightValid(Enum classOfFlight,  out string errors)
    {
        var errorList = new List<string>();

        if (classOfFlight is null || Enum.IsDefined(typeof(ClassOfFlight), classOfFlight) )
            errorList.Add($"Invalid or null flight class");

        errors = string.Join("\n - ", errorList);
        return !errorList.Any();
    }

    public static bool IsFlightValid(Flight flight, out string errors)
    {
        var errorList = new List<string>();

        if (flight == null)
        {
            errorList.Add("Flight is invalid or null.");
        }
        else
        {
            if (flight.DepartureDate <= DateTime.Now.AddHours(2))
                errorList.Add("The flight has already departed or is scheduled too soon.");
        }

        errors = string.Join("\n - ", errorList);
        return !errorList.Any();
    }

    public static bool IsPassengerValid(Passenger passenger, out string errors)
    {
        var errorList = new List<string>();
        if (passenger == null)
        errorList.Add($"Passenger with ID {passenger.Id} not found.");

        errors = string.Join("\n - ", errorList);
        return !errorList.Any();
    }
}