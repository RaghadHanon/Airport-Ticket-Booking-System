using Airport_Ticket_Booking_System.Entities.Bookings.Core;
using Airport_Ticket_Booking_System.Entities.Bookings.Service;
using Airport_Ticket_Booking_System.Entities.Flights.Filter;
using Airport_Ticket_Booking_System.Entities.Flights.Query;
using Airport_Ticket_Booking_System.Entities.Passengers.Core;
using Airport_Ticket_Booking_System.Entities.Passengers.Repository;
using Airport_Ticket_Booking_System.Presentation.EntitiesPrinters;
using Airport_Ticket_Booking_System.Utilities;
using System;

namespace Airport_Ticket_Booking_System.Presentation;
public class PassengerUI
{
    public IAvailableFlightFilter AvailableFlightFilter { get; }
    public IPassenegerRepository PassenegerRepository { get; }
    public IFlightQuery FlightQuery { get; }
    public IBookingService BookingService { get; }
    public PassengerUI(IAvailableFlightFilter availableFlightFilter, IPassenegerRepository passenegerRepository, IFlightQuery flightQuery, IBookingService bookingService)
    {
        AvailableFlightFilter = availableFlightFilter;
        PassenegerRepository = passenegerRepository;
        FlightQuery = flightQuery;
        BookingService = bookingService;
    }

    public void ShowMenu()
    {
        var isExit = false;
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
                    AvailableFlightFilter.ShowAvailableFlights();
                    break;
                case "2":
                    SearchAvailableFlights();
                    break;
                case "3":
                    BookAFlight();
                    break;
                case "4":
                    ManageBookings();
                    break;
                case "5":
                    isExit = true;
                    break;
                default:
                    Console.WriteLine(ErrorMessages.InvalidChoice);
                    break;
            }
        }
    }

    public void BookAFlight()
    {
        var passengerId = InputGathering.GetPassengerId();
        if (passengerId == null) return;
            var passenger = PassenegerRepository.GetById(passengerId.Value);

        var flightId = InputGathering.GetFlightId();
        if (flightId == null) return;
            var flight = FlightQuery.GetById(flightId.Value);

        var classOfFlight = InputGathering.GetClassOfFlightInput();
        if (classOfFlight == null)
        {
            Console.WriteLine(ErrorMessages.InvalidFlightClass);
            return;
        }

        try
        {
            var booking = BookingService.BookAFlight(new Book(classOfFlight, flight, passenger));
            Console.WriteLine("Booking successful!");
            Console.WriteLine(BookPrinter.PrintBooking(booking));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }

    public void SearchAvailableFlights()
    {
        var isExit = false;
        while (!isExit)
        {
            Console.WriteLine("""

                           --- Search Flights ---

                           1. By Price
                           2. By Departure Country
                           3. By Destination Country
                           4. By Departure Airport
                           5. By Arrival Airport
                           6. By Date
                           7. Exit
            
                          Select a filter option:
                          """);

            int.TryParse(Console.ReadLine(), out int searchOption);
            switch (searchOption)
            {
                case 1:
                    var price = InputGathering.GetPriceInput();
                    if (price != null) 
                        AvailableFlightFilter.ShowFlightsByPrice(price.Value);
                    break;
                case 2:
                    var departureCountry = InputGathering.GetStringInput("departure country");
                    AvailableFlightFilter.ShowFlightsByDepartureCountry(departureCountry);
                    break;
                case 3:
                    var destinationCountry = InputGathering.GetStringInput("destination country");
                    AvailableFlightFilter.ShowFlightsByDestinationCountry(destinationCountry);
                    break;
                case 4:
                    var departureAirport = InputGathering.GetStringInput("departure airport");
                    AvailableFlightFilter.ShowFlightsByDepartureAirport(departureAirport);
                    break;
                case 5:
                    var arrivalAirport = InputGathering.GetStringInput("arrival airport");
                    AvailableFlightFilter.ShowFlightsByArrivalAirport(arrivalAirport);
                    break;
                case 6:
                    var departureDate = InputGathering.GetDateInput();
                    if (departureDate != null)
                    {
                        AvailableFlightFilter.ShowAvailableFlightsByDate(departureDate.Value);
                        Console.WriteLine($"Selected Date: {departureDate.Value:MM-dd-yyyy}");
                    }
                    break;
                case 7:
                    isExit = true;
                    break;
                default:
                    Console.WriteLine(ErrorMessages.InvalidOption);
                    break;
            }
        }
    }

    public void ManageBookings()
    {
        var passengerId = InputGathering.GetPassengerId();
        if (passengerId == null) return;

        Passenger? passenger = PassenegerRepository.GetById(passengerId.Value);
        var isExit = false;
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
                    Console.WriteLine(ErrorMessages.InvalidOption);
                    break;
            }
        }
    }

    private void CancleBooking(int passengerId)
    {
        var cancelBookingId = InputGathering.GetBookingId("cancel");
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

    private void ModifyBooking(int passengerId)
    {
        var bookingId = InputGathering.GetBookingId("modify");
        if (bookingId == null) return;

        var changeClass = InputGathering.ConfirmModification("class");
        if (changeClass)
        {
            var newClassOfFlight = InputGathering.GetClassOfFlightInput();
            if (newClassOfFlight != null)
            {
                try
                {
                    BookingService.ModifyBooking(bookingId: bookingId.Value, passengerId: passengerId, classOfFlight: newClassOfFlight);
                    Console.WriteLine("Booking class modified successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }

        var changeFlight = InputGathering.ConfirmModification("flight");
        if (changeFlight)
        {
            var newFlightId = InputGathering.GetFlightId();
            if (newFlightId != null)
            {
                try
                {
                    BookingService.ModifyBooking(bookingId :bookingId.Value, passengerId: passengerId, flightId :newFlightId.Value);
                    Console.WriteLine("Booking flight modified successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }
    }

    private void ViewAllBookings(int passengerId)
    {
        try
        {
            string bookings = BookPrinter.PrintBookings(BookingService.ShowBookings(passengerId), $"--- Personal Bookings ---\n");
            Console.WriteLine(bookings);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }
}