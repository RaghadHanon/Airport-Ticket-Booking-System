using Airport_Ticket_Booking_System.Entites.BookingManagement;
using Airport_Ticket_Booking_System.Entites.FlightManagement;
using Airport_Ticket_Booking_System.Entites.FlightManagment;
using Airport_Ticket_Booking_System.Entites.PassengersManager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.Utilities;
public static class PassengerUI
{
    public static void ShowMenu()
    {
        bool isExit = false;
        while (!isExit)
        {
            Console.WriteLine("""
                                    --- Passenger Menu ---
                                    1. Show Available Flights
                                    2. Search Available Flights
                                    3. Book a Flight
                                    4. Manage Bookings
                                    5. Exit
                                    Please select an option: 
                                  """);

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    FlightBookingFilter.ShowAvailableFlights();
                    break;
                case "2":
                    PassengerUI.SearchAvailableFlights();
                    break;
                case "3":
                    PassengerUI.BookAFlight();
                    break;
                case "4":
                    PassengerUI.ManageBookings();
                    break;
                case "5":
                    isExit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }

    public static void BookAFlight()
    {
        int? passengerId = InputGathering.GetPassengerId();
        if (passengerId == null) return;
        Passenger? passenger = PassenegerRepository.GetById(passengerId.Value);


        int? flightId = InputGathering.GetFlightId();
        if (flightId == null) return;
        Flight? flight = FlightQuery.GetById(flightId.Value);


        ClassOfFlight? classOfFlight = InputGathering.GetClassOfFlightInput();
        if (classOfFlight == null)
        {
            Console.WriteLine("Invalid flight class.");
            return;
        }

        try
        {
            Book? booking = BookingService.BookAFlight(new Book(classOfFlight, flight, passenger));
            Console.WriteLine("Booking successful!");
            Console.WriteLine(booking);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }

    public static void SearchAvailableFlights()
    {
        bool isExit = false;
        while (!isExit)
        {
            Console.WriteLine("""

                           --- Search Flights ---

                           1. By Price
                           2. By Departure Country
                           3. By Destination Country
                           4. By Airport
                           5. By Arrival Airport
                           6. By Date
                           7. Exit
            
                          Select a filter option:
                          """);

            int.TryParse(Console.ReadLine(), out int searchOption);

            switch (searchOption)
            {
                case 1:
                    decimal? price = InputGathering.GetPriceInput();
                    if (price != null) FlightBookingFilter.ShowFlightsByPrice(price.Value);
                    break;

                case 2:
                    string departureCountry = InputGathering.GetStringInput("departure country");
                    FlightBookingFilter.ShowFlightsByDepartureCountry(departureCountry);
                    break;

                case 3:
                    string destinationCountry = InputGathering.GetStringInput("destination country");
                    FlightBookingFilter.ShowFlightsByDestinationCountry(destinationCountry);
                    break;

                case 4:
                    string departureAirport = InputGathering.GetStringInput("departure airport");
                    FlightBookingFilter.ShowFlightsByDepartureAirport(departureAirport);
                    break;

                case 5:
                    string arrivalAirport = InputGathering.GetStringInput("arrival airport");
                    FlightBookingFilter.ShowFlightsByArrivalAirport(arrivalAirport);
                    break;

                case 6:
                    DateTime? departureDate = InputGathering.GetDateInput();
                    if (departureDate != null)
                    {
                        FlightBookingFilter.ShowAvailableFlightsByDate(departureDate.Value);
                        Console.WriteLine($"Selected Date: {departureDate.Value:yyyy-MM-dd}");
                    }
                    break;

                case 7:
                    isExit = true;
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    public static void ManageBookings()
    {
        int? passengerId = InputGathering.GetPassengerId();
        if (passengerId == null) return;

        Passenger? passenger = PassenegerRepository.GetById(passengerId.Value);

        bool isExit = false;
        while (!isExit)
        {
            Console.WriteLine("""
                                    Manage your bookings:
                                    1. View all bookings
                                    2. Modify booking
                                    3. Cancel booking
                                    4. Exit
                                    Select an option:
                                  """);

            int.TryParse(Console.ReadLine(), out int manageOption);
            switch (manageOption)
            {
                case 1:
                    ViewAllBookings(passengerId.Value);
                    break;

                case 2:
                    ModifyBooking(passengerId.Value);
                    break;

                case 3:
                    CancleBooking(passengerId.Value);
                    break;

                case 4:
                    isExit = true;
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    private static void CancleBooking(int passengerId)
    {
        int? cancelBookingId = InputGathering.GetBookingId("cancel");
        if (cancelBookingId == null) return;

        try
        {
            BookingService.CancelAbooking(cancelBookingId.Value, passengerId);
            Console.WriteLine("Booking cancelled successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }

    private static void ModifyBooking(int passengerId)
    {
        int? bookingId = InputGathering.GetBookingId("modify");
        if (bookingId == null) return;

        bool changeClass = InputGathering.ConfirmModification("class");
        if (changeClass)
        {
            ClassOfFlight? newClassOfFlight = InputGathering.GetClassOfFlightInput();
            if (newClassOfFlight != null)
            {
                try
                {
                    BookingService.ModifyBookingClassFlight(bookingId.Value, newClassOfFlight, passengerId);
                    Console.WriteLine("Booking class modified successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }

        bool changeFlight = InputGathering.ConfirmModification("flight");
        if (changeFlight)
        {
            int? newFlightId = InputGathering.GetFlightId();
            if (newFlightId != null)
            {
                try
                {
                    BookingService.ModifyBookingFlight(bookingId.Value, passengerId, newFlightId.Value);
                    Console.WriteLine("Booking flight modified successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }
    }

    private static void ViewAllBookings(int passengerId)
    {
        try
        {
            BookingFilter.ShowBookingsByPassenger(passengerId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }

}