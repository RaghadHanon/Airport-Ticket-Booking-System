using Airport_Ticket_Booking_System.Entites.FlightManagement;
using Airport_Ticket_Booking_System.Entites.FlightManagment;
using Airport_Ticket_Booking_System.Entites.PassengersManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.Entites.BookingManagement;

public class BookingService
{
    public static Book? BookAFlight(Enum classOfFlight, int flightId, int passengerId)
    {
        Passenger? passenger = PassenegerRepository.GetById(passengerId);
        Flight? flight = FlightQuery.GetById(flightId);
        

        if (!BookValidator.IsBookValid(classOfFlight, flight, passenger, out string validationErrors))
        {
            Console.WriteLine("Booking failed due to the following errors:");
            Console.WriteLine(validationErrors);
            return null;
        }

        Book newBooking = new Book((ClassOfFlight)classOfFlight, flight, passenger);

        passenger.Bookings.Add(newBooking);
        BookingRepository.Bookings.Add(newBooking);

        return newBooking;
    }

    public static Book? CancelAbooking(int bookId, int passengerId)
    {
        Passenger? passenger = PassenegerRepository.GetById(passengerId);
        if (passenger == null)
        {
            Console.WriteLine($"Passenger with ID {passengerId} not found.");
            return null;
        }

        Book? booking = passenger.Bookings.FirstOrDefault(b => b.Id == bookId);
        if (booking == null)
        {
            Console.WriteLine($"Booking with ID {bookId} for passenger {passengerId} not found.");
            return null;
        }

        passenger.Bookings.Remove(booking);
        BookingRepository.Bookings.Remove(booking);

        return booking;
    }

    public static Book? ModifyBookingClassFlight(int bookId, int passengerId, Enum? newClassOfFlight)
    {
        Passenger? passenger = PassenegerRepository.GetById(passengerId);
        if (passenger == null)
        {
            Console.WriteLine($"Passenger with ID {passengerId} not found.");
            return null;
        }

        Book? booking = passenger.Bookings.FirstOrDefault(b => b.Id == bookId);
        if (booking == null)
        {
            Console.WriteLine($"Booking with ID {bookId} for passenger {passengerId} not found.");
            return null;
        }

        if (!BookValidator.IsClassOfFlightValid(newClassOfFlight,out string validationErrors))
        {
            Console.WriteLine("Modifing booking clight class failed due to the following errors:");
            Console.WriteLine(validationErrors);
            return null;
        }

        booking.ClassOfFlight = (ClassOfFlight) newClassOfFlight;
        return booking;
    }
    public static Book? ModifyBookingFlight(int bookId, int passengerId,  int? newFlightId)
    {
        Passenger? passenger = PassenegerRepository.GetById(passengerId);
        if (passenger == null)
        {
            Console.WriteLine($"Passenger with ID {passengerId} not found.");
            return null;
        }

        Book? booking = passenger.Bookings.FirstOrDefault(b => b.Id == bookId);
        if (booking == null)
        {
            Console.WriteLine($"Booking with ID {bookId} for passenger {passengerId} not found.");
            return null;
        }

        Flight? flight = FlightQuery.GetById(newFlightId);

        if (!BookValidator.IsFlightValid( flight, out string validationErrors))
        {
            Console.WriteLine("Modifing Booking flight failed due to the following errors:");
            Console.WriteLine(validationErrors);
            return null;
        }

        booking.Flight = flight;
        return booking;
    }
}

/*
public class BookingService
{
    public static Book? BookAFlight(ClassOfFlight classOfFlight, int flgihtId, int passengerId)
    {
        Passenger? passenger = PassenegerRepository.GetById(passengerId);

        if (passenger == null)
        {
            Console.WriteLine($"Passenger with ID {passengerId} not found.");
            return null;
        }
        Flight? flight = FlightsRepository.GetById(flgihtId);
        if (flight == null)
        {
            Console.WriteLine($"Passenger with ID {passengerId} not found.");
            return null;
        }
        Book? book = new Book(classOfFlight, flight, passenger);


        passenger?.Bookings.Add(book);
        BookingRepository.Bookings.Add(book);
        return book;
    }

    public static Book? CancelAbooking(int bookId, int passengerId)
    {
        Passenger? passenger = PassenegerRepository.GetById(passengerId);

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
        BookingRepository.Bookings.Remove(book);
        return book;
    }
    public static Book? ModifyAbooking(int bookId, int passengerId, ClassOfFlight? newClassOfFlight, int? newFlgihtId)
    {
        Passenger? passenger = PassenegerRepository.GetById(passengerId);

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

        book.ClassOfFlight = newClassOfFlight ?? book.ClassOfFlight;
        if (newFlgihtId is not null)
            book.Flight = FlightsRepository.GetById(newFlgihtId) ?? book.Flight;

        return book;
    }
}
*/