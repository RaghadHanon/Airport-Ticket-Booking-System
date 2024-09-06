using Airport_Ticket_Booking_System.Entites.FlightManagment;
using Airport_Ticket_Booking_System.Entites.PassengersManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.Entites.BookingManagement;
public class BookingManager
{

    public static List<Book> Bookings { get; } = new List<Book>();
    public static Book BookAFlight(ClassOfFlight classOfFlight, int flgihtId,int passengerId)
    {
        Passenger? passenger = PassenegersManager.Passengers.FirstOrDefault(p => p.Id == passengerId);

        if (passenger == null)
        {
            Console.WriteLine($"Passenger with ID {passengerId} not found.");
            return null;
        }

        Book? book = new Book(classOfFlight, flgihtId);
        

        passenger?.Bookings.Add(book);
        Bookings.Add(book);
        return book;
    }

    public static Book CancelAbooking(int bookId, int passengerId)
    {
        Passenger? passenger = PassenegersManager.Passengers.FirstOrDefault(p => p.Id == passengerId);

        if (passenger == null)
        {
            Console.WriteLine($"Passenger with ID {passengerId} not found.");
            return null;
        }
        
        Book? book = passenger.Bookings.FirstOrDefault(b => b.Id == bookId);

        if (book == null)
        {
            Console.WriteLine($"Booking with ID {bookId} for passenger {passengerId} not found.");
            return null;
        }

        passenger?.Bookings.Remove(book);
        return book;
    }
    public static Book ModifyAbooking(int bookId, int passengerId, ClassOfFlight? newClassOfFlight, int newFlgihtId)
    {
        Passenger? passenger = PassenegersManager.Passengers.FirstOrDefault(p => p.Id == passengerId);

        if (passenger == null)
        {
            Console.WriteLine($"Passenger with ID {passengerId} not found.");
            return null;
        }

        Book? book = passenger.Bookings.FirstOrDefault(b => b.Id == bookId);

        if (book == null)
        {
            Console.WriteLine($"Booking with ID {bookId} for passenger {passengerId} not found.");
            return null;
        }

        book.ClassOfFlight = newClassOfFlight?? book.ClassOfFlight;
        book.Flight = FlightsManager.GetById(newFlgihtId)?? book.Flight;
        
        return book;
    }
    public static void ShowAvailableFlights()
    {
        var flights = FlightsManager.GetAllFlights(DateTime.Now);
        if (flights.Any())
        {
            Console.WriteLine($"Available flights departing after {DateTime.Now}:\n ");
            foreach (var flight in flights)
                Console.WriteLine(flight);
        }
        else
        {
            Console.WriteLine("No available flights at the moment.");
        }
    }
    public static void ShowFlightsByDate(DateTime date)
    {
        if (date.CompareTo(DateTime.Now) <= 0)
            Console.WriteLine("You’ve chosen a date that has already passed. Please pick a future date.");
        else
        {
            var flights = FlightsManager.GetAllFlights(date);
            if (flights.Any())
            {
                Console.WriteLine($"Available flights departing after {date}:\n ");
                foreach (var flight in flights)
                    Console.WriteLine(flight);
            }
            else
            {
                Console.WriteLine("No available flights at the moment.");
            }
        }
    }
    public static void ShowFlightsByPrice(decimal price)
    {
        var flights = FlightsManager.GetByPrice(price, DateTime.Now);
        if (flights.Any())
        {
            Console.WriteLine($"Available flights matching the price {price} after {DateTime.Now}:\n ");
            foreach (var flight in flights)
            {
                ClassOfFlight classOfFlight = flight.ClassPriceMap.FirstOrDefault(x => x.Value == price).Key;

                Console.WriteLine($"\"{classOfFlight} class\" matches your specifications\n {flight}");
            }
        }
        else
        {
            Console.WriteLine("No available flights at the moment.");
        }
    }
    public static void ShowFlightsByDepartureCountry(string departureCountry)
    {
        var flights = FlightsManager.GetByDepartureCountry(departureCountry, DateTime.Now);
        if (flights.Any())
        {
            Console.WriteLine($"Available flights departing from {departureCountry} after {DateTime.Now}:\n ");
            foreach (var flight in flights)
            {
                Console.WriteLine(flight);
            }
        }
        else
        {
            Console.WriteLine("No available flights at the moment.");
        }
    }
    public static void ShowFlightsByDestinationCountry(string destinationCountry)
    {
        var flights = FlightsManager.GetByDestinationCountry(destinationCountry, DateTime.Now);
        if (flights.Any())
        {
            Console.WriteLine($"Available flights to {destinationCountry} after {DateTime.Now}:\n ");
            foreach (var flight in flights)
            {
                Console.WriteLine(flight);
            }
        }
        else
        {
            Console.WriteLine("No available flights at the moment.");
        }
    }
    public static void ShowFlightsByDepartureAirport(string departureAirport)
    {
        var flights = FlightsManager.GetByDepartureAirport(departureAirport, DateTime.Now);
        if (flights.Any())
        {
            Console.WriteLine($"Available flights departing from {departureAirport} Airport after {DateTime.Now}:\n ");
            foreach (var flight in flights)
            {
                Console.WriteLine(flight);
            }
        }
        else
        {
            Console.WriteLine("No available flights at the moment.");
        }
    }
    public static void ShowFlightsByArrivalAirport(string arrivalAirport)
    {
        var flights = FlightsManager.GetByArrivalAirport(arrivalAirport, DateTime.Now);
        if (flights.Any())
        {
            Console.WriteLine($"Available flights to {arrivalAirport} Airport after {DateTime.Now}:\n ");
            foreach (var flight in flights)
            {
                Console.WriteLine(flight);
            }
        }
        else
        {
            Console.WriteLine("No available flights at the moment.");
        }
    }

}

