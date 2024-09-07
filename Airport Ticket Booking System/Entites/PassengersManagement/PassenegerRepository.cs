using Airport_Ticket_Booking_System.Entites.BookingManagement;
using Airport_Ticket_Booking_System.Entites.FlightManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.Entites.PassengersManager
{
    public class PassenegerRepository
    {
        public static List<Passenger> Passengers { get; } = new List<Passenger>();

        public static Passenger AddAPassenger(string name)
        {
            Passenger passenger = new Passenger(name);
            Passengers.Add(passenger);
            return passenger;
        }
        public static Passenger? GetById(int id)
        {
            return Passengers.FirstOrDefault(p => p.Id == id);
        }
    }
}
