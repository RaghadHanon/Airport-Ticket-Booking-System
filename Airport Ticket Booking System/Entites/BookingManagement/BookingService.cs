using Airport_Ticket_Booking_System.Entites.FlightManagement;
using Airport_Ticket_Booking_System.Entites.FlightManagment;
using Airport_Ticket_Booking_System.Entites.PassengersManager;
using Airport_Ticket_Booking_System.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Airport_Ticket_Booking_System.Entites.BookingManagement;

public static class BookingService
{
    public static Book? BookAFlight(Book booking,int passengerId)
    {
        if (!BookingValidation.ValidateBook(booking, out string errors))
        {

            ErrorException.error($"""
                                   Booking Flight failed due to these errors:
                                   {errors}
                                  """
            );
        }

        (PassenegerRepository.GetById(passengerId))?.Bookings.Add(booking);
        BookingQuery.Bookings.Add(booking);

        return booking;
    }

    public static Book? CancelAbooking(int bookingId, int passengerId)
    {
        Book? booking = BookingQuery.GetById(bookingId);
        if (booking == null)
        {
            throw new ArgumentException($"- Booking not found or null.\n");
        }

        if (!BookingValidation.PassengerValidation(booking, out string errors))
        {
            ErrorException.error($"""
                                   Cancel Booking Failed due to these errors:
                                   {errors}
                                  """
            );
        }
        Passenger passenger = PassenegerRepository.GetById(passengerId)!;
        if (!passenger.Bookings.Any(b=> b.Id == booking.Id))
        {
            ErrorException.error($"- Booking with ID {booking.Id} does not exist in the booking list of passenger {passenger.Name}.");
        }

        passenger.Bookings.Remove(booking);
        BookingQuery.Bookings.Remove(booking);

        return booking;
    }

    public static Book? ModifyBookingClassFlight(int bookingId,ClassOfFlight classOfFlight,  int passengerId)
    {
        Book? booking = BookingQuery.GetById(bookingId);
        if (booking == null)
        {
            ErrorException.error($"- Booking not found or null.\n");
        }
        Passenger passenger = PassenegerRepository.GetById(passengerId)!;


        Book? newBooking = new(classOfFlight,
            booking.Flight, passenger);

        if (!BookingValidation.PassengerValidation(newBooking, out string errors))
        {
            ErrorException.error($"""
                                   {errors}
                                  """
            );
        }

        if (!passenger.Bookings.Any(b => b.Id == booking.Id))
        {
            ErrorException.error($"- Booking with ID {booking.Id} does not exist in the booking list of passenger {passenger.Name}.");
        }


        if (!BookingValidation.ClassOfFlightValidation(newBooking, out string validationErrors))
        {
            ErrorException.error($"""
                                  Modifying Class Flight of booking {bookingId} failed due to these errors:
                                  {validationErrors}
                                  """
             );
        }

        booking.ClassOfFlight = newBooking.ClassOfFlight;
        return booking;
    }
    public static Book? ModifyBookingFlight(int bookingId, int passengerId,  int?flightId)
    {
        Book? booking = BookingQuery.GetById(bookingId);
        if (booking == null)
        {
            ErrorException.error($"- Booking not found or null.\n");
        }
        Passenger passenger = PassenegerRepository.GetById(passengerId)!;

        Book? newBooking = new(booking.ClassOfFlight, FlightQuery.GetById(flightId), passenger);
        if (!BookingValidation.PassengerValidation(newBooking, out string errors))
        {
            ErrorException.error($"""
                                   {errors}
                                  """
            );
        }

        if (!passenger.Bookings.Any(b => b.Id == booking.Id))
        {
            ErrorException.error($"- Booking with ID {booking.Id} does not exist in the booking list of passenger {passenger.Name}.");
        }


        if (!BookingValidation.FlightValidation(booking, out string flightErrors) )
        {
            ErrorException.error($"""
                                  Modify Flight of booking {bookingId} failed due to these errors:
                                  {flightErrors}
                                  """
             );
        }

        if (!BookingValidation.BookingCollisionsValidation(booking, out string bookingCollisionsErrors))
        {
            ErrorException.error($"""
                                  Modify Flight of booking {bookingId} failed due to these errors:
                                  {bookingCollisionsErrors}
                                  """
            );
        }
       
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
