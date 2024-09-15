using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Airport_Ticket_Booking_System.Utilities;

public static class ErrorMessages
{
    public const string AccessDenied = "- Access denied to this booking.";
    public const string ArrivalAirportRequired = "- Arrival airport is required.";
    public const string BookingCannotBeNull = "- Booking can't be null.\n";
    public const string BookingCollisionError = "- Booking collision detected.";
    public const string BookingFlightError = "Booking Flight failed due to these errors:";
    public const string BookingNotFound = "- Booking not found or null.";
    public const string BusinessPriceInvalid = "- Business class price must be greater than 0.";
    public const string CancelBookingError = "Cancel Booking Failed due to these errors:";
    public const string ClassOfFlightCannotBeNull = "- Flight Class can't be null and must be one of these: Economy, Business, First Class.";
    public const string ClassOfFlightValidationError = "- Class of Flight validation failed.";
    public const string DepartureAirportRequired = "- Departure airport is required.";
    public const string DepartureCountryRequired = "- Departure Country Name is required.";
    public const string DepartureDateInvalidFormat = "- Departure date can't be null and must be in dd-MM-yyyy format.";
    public const string DepartureDateTooClose = "- Departure date must be at least 4 hours from the current time.";
    public const string DepartureDateTooCloseForBooking = "- Departure date must be at least 2 hours from the current time.";
    public const string DestinationCountryRequired = "- Destination Country is required.";
    public const string EconomyPriceInvalid = "- Economy class price must be greater than 0.";
    public const string FirstClassPriceInvalid = "- First class price must be greater than 0.";
    public const string FlightCannotBeNull = "- Flight cannot be null.";
    public const string FlightMustBaValidScheduledFlight = "- Flight must be a valid scheduled flight.";
    public const string FlightCollisionMessage = "- The flight collides with an existing booking/s";
    public const string FlightValidationError = "- Flight validation failed.";
    public const string FileNotFount = "File not found.";
    public const string FileEmpty = "The file is empty."; 
    public const string InvalidChoice = "Invalid choice. Please select a valid option.";
    public const string InvalidFlightClass = "Invalid flight class.";
    public const string InvalidOption = "Invalid option.";
    public const string InvalidInput = "Invalid input.";
    public const string ModifyBookingError = "Modifying booking failed due to these errors:";
    public const string NoAvailableBookings = "No available bookings at the moment.";
    public const string NoAvailableFlights = "No available flights at the moment.";
    public const string NoAvailablepassengers = "No passengers available.";
    public const string NoNewDataFound = "No new data found.";
    public const string BatchUploadError = "Error during batch upload:";
    public const string PassengerNotFound = "- Passenger not found.";
    public const string PassengerAddingError = $"- Error Adding passenger:";
    public const string ProcessingFileError = $"- Error processing file:";
    public const string SelectedDateInvalid = "- The selected date is either in the past or less than 2 hours from now. Please choose a date at least 2 hours in the future.";
   

}

