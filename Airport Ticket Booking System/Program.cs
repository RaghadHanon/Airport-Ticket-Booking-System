using Airport_Ticket_Booking_System.Entities.Bookings.Filter;
using Airport_Ticket_Booking_System.Entities.Bookings.Query;
using Airport_Ticket_Booking_System.Entities.Bookings.Repository;
using Airport_Ticket_Booking_System.Entities.Bookings.Service;
using Airport_Ticket_Booking_System.Entities.DataManagement;
using Airport_Ticket_Booking_System.Entities.Flights.Filter;
using Airport_Ticket_Booking_System.Entities.Flights.Query;
using Airport_Ticket_Booking_System.Entities.Flights.Repository;
using Airport_Ticket_Booking_System.Entities.Passengers.Repository;
using Airport_Ticket_Booking_System.Presentation;
using Airport_Ticket_Booking_System.Presentation.UI;
using Airport_Ticket_Booking_System.Utilities;

namespace Airport_Ticket_Booking_System;
internal class Program
{
    private static PassengerUI _passengerUI;
    private static ManagerUI _managerUI;
    private static SampleData _sampleData;
    public Program(ManagerUI managerUI , SampleData sampleData, PassengerUI passengerUI)
    {
        _managerUI = managerUI;
        _sampleData = sampleData;
        _passengerUI = passengerUI;
    }

    static void Main(string[] args)
    {
        var program = Setup();
        _sampleData.InitializeSampleData();
        var isExit = false;
        while (!isExit)
        {
            Console.WriteLine("""

                              You want to use the system as:
                              1. Passenger
                              2. Manager
                              3. Exit

                              """);
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    _passengerUI.ShowMenu();
                    break;
                case "2":
                    _managerUI.ShowMenu();
                    break;
                case "3":
                    isExit = true;
                    break;
                default:
                    Console.WriteLine(ErrorMessages.InvalidChoice);
                    break;
            }
        }
        Console.WriteLine("Thank you for using the Airport Ticket Booking System!");
    }

    private static Program Setup()
    {
        var bookingRepository = new BookingRepository();
        var flightRepository = new FlightRepository();
        var bookingQuery = new BookingQuery(bookingRepository);
        var bookingFilter = new BookingFilter(bookingQuery);
        var flightQuery = new FlightQuery(flightRepository);
        var flightDataFileProcessing = new FlightDataFileProcessing(flightRepository);
        var passenegerRepository = new PassenegerRepository();
        var availableFlightFilter = new AvailableFlightFilter(flightQuery);
        return new Program(
            new ManagerUI(
                bookingFilter,
                flightQuery,
                flightDataFileProcessing
            ),
            new SampleData(
                passenegerRepository,
                flightDataFileProcessing
            ),
            new PassengerUI(
                availableFlightFilter,
                passenegerRepository,
                flightQuery,
                new BookingService(
                    bookingRepository,
                    bookingQuery,
                    flightQuery,
                    passenegerRepository
                    )
                )
            );
    }
}
