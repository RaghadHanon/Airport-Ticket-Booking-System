using Airport_Ticket_Booking_System.Entites.BookingManagement;
using Airport_Ticket_Booking_System.Entites.FlightManagment;
using Airport_Ticket_Booking_System.Entites.PassengersManager;
using System.Security.Cryptography;

namespace Airport_Ticket_Booking_System;
internal class Program
{
    static void Main(string[] args)
    {
        PassenegersManager.AddAPassenger("Raghad");


        BookingManager.ShowAvailableFlights();

        Passenger p = PassenegersManager.Passengers.FirstOrDefault(p => p.Name == "Raghad");
        Console.WriteLine($"\n\n");
        BookingManager.BookAFlight(ClassOfFlight.Business, 5, p.Id);
        BookingManager.BookAFlight(ClassOfFlight.Economy, 11, p.Id);
        BookingManager.BookAFlight(ClassOfFlight.FirstClass, 14, p.Id);
        p.ShowBooking();

        BookingManager.CancelAbooking(1, p.Id);
        p.ShowBooking();
    }
}
