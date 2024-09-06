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
    public static Book? BookAFlight(ClassOfFlight classOfFlight, int flgihtId,int passengerId)
    {
        Passenger? passenger = PassenegersManager.GetById(passengerId);

        if (passenger == null)
        {
            Console.WriteLine($"Passenger with ID {passengerId} not found.");
            return null;
        }
        Flight? flight = FlightsManager.GetById(flgihtId);
        if (flight == null)
        {
            Console.WriteLine($"Passenger with ID {passengerId} not found.");
            return null;
        }
        Book? book = new Book(classOfFlight, flight,passenger);
        

        passenger?.Bookings.Add(book);
        Bookings.Add(book);
        return book;
    }

    public static Book? CancelAbooking(int bookId, int passengerId)
    {
        Passenger? passenger = PassenegersManager.GetById(passengerId);

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

        book = BookingManager.GetById(bookId);
        Bookings.Remove(book);
        return book;
    }
    public static Book? ModifyAbooking(int bookId, int passengerId, ClassOfFlight? newClassOfFlight, int newFlgihtId)
    {
        Passenger? passenger = PassenegersManager.GetById(passengerId);

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


        book = BookingManager.GetById(bookId);
        book.ClassOfFlight = newClassOfFlight ?? book.ClassOfFlight;
        book.Flight = FlightsManager.GetById(newFlgihtId) ?? book.Flight;

        return book;
    }
    public static Book? GetById(int id)
    {
        return Bookings.FirstOrDefault(b => b.Id == id);
    }



}

