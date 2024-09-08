using Airport_Ticket_Booking_System.Entites.BookingManagement;
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
                    PassengerUI.ShoewAvailableFlights();
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
        Console.Write("\nEnter Passenger ID: ");
        if (int.TryParse(Console.ReadLine(), out int passengerId))
        {
            Passenger? passenger = PassenegerRepository.GetById(passengerId);
            if (passenger == null)
            {
                Console.WriteLine($"Passenger with ID {passengerId} not found.");
                return;
            }

            Console.WriteLine("Please enter the flight ID you want to book:");
            int.TryParse(Console.ReadLine(), out int flightId);
            Flight? flight = FlightsRepository.GetById(flightId);
            if (flight == null)
            {
                Console.WriteLine($"Flight with ID {flightId} not found.");
                return;
            }

            Console.WriteLine("Select a class: (1) Economy, (2) Business, (3) First Class");
            int.TryParse(Console.ReadLine(), out int classOption);

            ClassOfFlight classOfFlight = classOption switch
            {
                1 => ClassOfFlight.Economy,
                2 => ClassOfFlight.Business,
                3 => ClassOfFlight.FirstClass,
                _ => throw new ArgumentException("Invalid class option")
            };

            Book? booking = BookingRepository.BookAFlight(classOfFlight, flightId, passengerId);
            if (booking != null)
            {
                Console.WriteLine("Booking successful!");
                Console.WriteLine(booking);
            }
            else
            {
                Console.WriteLine("Booking failed. Please try again.");
            }
        }

    }

    public static void ShoewAvailableFlights()
    {
        FlightBookingFilter.ShowAvailableFlights();
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

            if (int.TryParse(Console.ReadLine(), out int searchOption))
            {
                switch (searchOption)
                {
                    case 1:
                        Console.WriteLine("Enter price:");
                        if (decimal.TryParse(Console.ReadLine(), out decimal price))
                        {
                            FlightBookingFilter.ShowFlightsByPrice(price);
                        }
                        else
                        {
                            Console.WriteLine("Invalid price.");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Enter departure country:");
                        string departureCountry = Console.ReadLine();
                        FlightBookingFilter.ShowFlightsByDepartureCountry(departureCountry);
                        break;

                    case 3:
                        Console.WriteLine("Enter destination country:");
                        string destinationCountry = Console.ReadLine();
                        FlightBookingFilter.ShowFlightsByDestinationCountry(destinationCountry);
                        break;

                    case 4:
                        Console.WriteLine("Enter departure airport:");
                        string departureAirport = Console.ReadLine();
                        FlightBookingFilter.ShowFlightsByDepartureAirport(departureAirport);
                        break;

                    case 5:
                        Console.WriteLine("Enter arrival airport:");
                        string arrivalAirport = Console.ReadLine();
                        FlightBookingFilter.ShowFlightsByArrivalAirport(arrivalAirport);
                        break;

                    case 6:
                        Console.WriteLine("Enter departure date (YYYY-MM-DD):");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime departureDate))
                        {
                            FlightBookingFilter.ShowAvailableFlightsByDate(departureDate);
                            Console.WriteLine($"Selected Date: {departureDate:yyyy-MM-dd}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid date.");
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
            else
            {
                Console.WriteLine("Invalid option selection.");
            }

        }
    }

    public static void ManageBookings()
    {
        Console.Write("\nEnter Passenger ID: ");
        if (int.TryParse(Console.ReadLine(), out int passengerId))
        {
            Passenger? passenger = PassenegerRepository.GetById(passengerId);
            if (passenger == null)
            {
                Console.WriteLine($"Passenger with ID {passengerId} not found.");
                return;
            }
            bool isExit = false;
            while (!isExit)
            {
                Console.WriteLine("""

                               Manage your bookings: 
                               1. View all bookings 
                               2. Modify booking 
                               3. Cancel booking
                               4. Exit

                               Select a filter option:

                              """);
                int.TryParse(Console.ReadLine(), out int manageOption);

                switch (manageOption)
                {
                    case 1:
                        BookingFilter.ShowBookingsByPassenger(passengerId);
                        break;

                    case 2:
                        Console.WriteLine("Enter booking ID to modify:");
                        int.TryParse(Console.ReadLine(), out int bookingId);

                        Console.WriteLine("Do you want to change the class? (y/n)");
                        string changeClassOption = Console.ReadLine().ToLower();

                        ClassOfFlight? newClassOfFlight = null;
                        if (changeClassOption == "y")
                        {
                            Console.WriteLine("Select new class: (1) Economy, (2) Business, (3) First Class");
                            int newClassOption = int.Parse(Console.ReadLine());
                            newClassOfFlight = newClassOption switch
                            {
                                1 => ClassOfFlight.Economy,
                                2 => ClassOfFlight.Business,
                                3 => ClassOfFlight.FirstClass,
                                _ => throw new ArgumentException("Invalid class option")
                            };
                        }

                        Console.WriteLine("Do you want to change the flight? (y/n)");
                        string changeFlightOption = Console.ReadLine().ToLower();

                        int? newFlightId = null;
                        if (changeFlightOption == "y")
                        {
                            Console.WriteLine("Enter new flight ID:");
                            int.TryParse(Console.ReadLine(), out int _newFlightId);
                            newFlightId = _newFlightId;
                        }

                        BookingRepository.ModifyAbooking(bookingId, passengerId, newClassOfFlight, newFlightId);
                        Console.WriteLine("Booking modified successfully.");
                        break;

                    case 3:
                        Console.WriteLine("Enter booking ID to cancel:");
                        int.TryParse(Console.ReadLine(), out int cancelBookingId);
                        BookingRepository.CancelAbooking(cancelBookingId, passengerId);
                        Console.WriteLine("Booking cancelled successfully.");
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
    }
}