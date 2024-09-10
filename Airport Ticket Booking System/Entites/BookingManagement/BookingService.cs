using Airport_Ticket_Booking_System.Entites.FlightManagement;
using Airport_Ticket_Booking_System.Entites.FlightManagment;
using Airport_Ticket_Booking_System.Entites.PassengersManager;
using Airport_Ticket_Booking_System.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Airport_Ticket_Booking_System.Entites.BookingManagement;


public static class BookingService
{
    public static Book? BookAFlight(Book booking, int passengerId)
    {
        string porintialErrorTitle = "Booking Flight failed due to these errors:";
        if (!BookingValidation.ValidateBook(booking, out string errors))
            ErrorException.error($"{errors}",$"{porintialErrorTitle}");
        

        (PassenegerRepository.GetById(passengerId))?.Bookings.Add(booking);
        BookingQuery.Bookings.Add(booking);

        return booking;
    }

    public static Book? CancelAbooking(int bookingId, int passengerId)
    {
        Book? booking = BookingQuery.GetById(bookingId);


        string porintialErrorTitle = "Cancel Booking Failed due to these errors:";
        if (!BookingValidation.PassengerValidation(booking, out string errors))
            ErrorException.error($"{errors}", $"{porintialErrorTitle}");
        

        Passenger passenger = PassenegerRepository.GetById(passengerId)!;
        if (!HasAccessToBooking(passenger, booking, out string accessError))
            ErrorException.error($"{accessError}", $"{porintialErrorTitle}");


        passenger.Bookings.Remove(booking);
        BookingQuery.Bookings.Remove(booking);
        return booking;
    }
    private static bool HasAccessToBooking(Passenger passenger, Book booking ,out string accessError )
    {
        accessError = string.Empty;
        if (booking!.Passenger!.Id != passenger.Id)
        {
            accessError = $"-Booking with ID {booking.Id} does not exist in the booking list of passenger {passenger.Name}.";
            return false;
        }
        return true;
    }

    public static Book? ModifyBookingClassFlight(int bookingId, ClassOfFlight classOfFlight, int passengerId)
    {
        string porintialErrorTitle = $"Modifying Class Flight of booking {bookingId} failed due to these errors:";

        Book? booking = BookingQuery.GetById(bookingId);
        if (booking == null)
            ErrorException.error($"- Booking not found or null.", $"{porintialErrorTitle}");


        Passenger passenger = PassenegerRepository.GetById(passengerId)!;
        Book? newBooking = new(classOfFlight,booking!.Flight, passenger);

        if (!BookingValidation.PassengerValidation(newBooking, out string errors))
            ErrorException.error($"{errors}", $"{porintialErrorTitle}");


        if (!HasAccessToBooking(passenger, booking, out string accessError))
            ErrorException.error($"{accessError}", $"{porintialErrorTitle}");


        if (!BookingValidation.ClassOfFlightValidation(newBooking, out string validationErrors))
            ErrorException.error($"{validationErrors}", $"{porintialErrorTitle}");


        booking.ClassOfFlight = newBooking.ClassOfFlight;
        return booking;
    }
    public static Book? ModifyBookingFlight(int bookingId, int passengerId, int? flightId)
    {
        string porintialErrorTitle = $"Modify Flight of booking {bookingId} failed due to these errors:";


        Book ? booking = BookingQuery.GetById(bookingId);
        if (booking == null)
            ErrorException.error($"- Booking not found or null.",$"{porintialErrorTitle}");

        
        Passenger passenger = PassenegerRepository.GetById(passengerId)!;
        Book? newBooking = new(booking.ClassOfFlight, FlightQuery.GetById(flightId), passenger);

        if (!BookingValidation.PassengerValidation(newBooking, out string errors))
            ErrorException.error($"{errors}", $"{porintialErrorTitle}");

        if (!HasAccessToBooking(passenger, booking, out string accessError))
            ErrorException.error($"{accessError}", $"{porintialErrorTitle}");


        if (!BookingValidation.FlightValidation(booking, out string flightErrors))
            ErrorException.error($"{accessError}", $"{porintialErrorTitle}");

        if (!BookingValidation.BookingCollisionsValidation(booking, out string bookingCollisionsErrors))
            ErrorException.error($"{accessError}", $"{porintialErrorTitle}");


        booking.Flight = newBooking.Flight;
        return booking;
    }
    public static void ShowBookings(int passengerId)
    {
        Passenger passenger = PassenegerRepository.GetById(passengerId)!;

        if (passenger is null)
        {
            ErrorException.error($"- Passenger not found.");
        }

        if (passenger.Bookings.Count() == 0)
        {
            ErrorException.error($"- No Available bookings at the moment.");
        }

        Console.WriteLine($"--- {passenger.Name}'s Bookings ---");
        foreach (var book in passenger.Bookings)
        {
            Console.WriteLine($"{book}");
        }
    }
}
