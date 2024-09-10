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
        Console.Write("\nEnter Passenger ID: ");
        if (!int.TryParse(Console.ReadLine(), out int passengerId))
        {
            Console.WriteLine("Invalid input.");
            return;
        }
        Passenger? passenger = PassenegerRepository.GetById(passengerId);


        Console.WriteLine("Please enter the flight ID you want to book:");
        if(! int.TryParse(Console.ReadLine(), out int flightId))
        {
            Console.WriteLine("Invalid input.");
            return;
        }
        Flight? flight = FlightQuery.GetById(flightId);


        Console.WriteLine("Select a class: (1) Economy, (2) Business, (3) First Class");
        int.TryParse(Console.ReadLine(), out int classOption);

        Enum classOfFlight = classOption switch
        {
            1 => ClassOfFlight.Economy,
            2 => ClassOfFlight.Business,
            3 => ClassOfFlight.FirstClass,
            _ => throw new ArgumentException("Invalid class option")
        };
        try
        {
            Book? booking = BookingService.BookAFlight(new Book((ClassOfFlight)classOfFlight, flight, passenger));
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
                    Console.WriteLine("Enter price:");
                    if (! decimal.TryParse(Console.ReadLine(), out decimal price))
                    {
                        Console.WriteLine("Invalid input.");
                        break;
                    }
                    FlightBookingFilter.ShowFlightsByPrice(price);
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
                    if (!DateTime.TryParse(Console.ReadLine(), out DateTime departureDate))
                    {
                        Console.WriteLine("Invalid date.");
                        break;
                    }
                    FlightBookingFilter.ShowAvailableFlightsByDate(departureDate);
                    Console.WriteLine($"Selected Date: {departureDate:yyyy-MM-dd}");
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
        Console.Write("\nEnter Passenger ID: ");
        if (!int.TryParse(Console.ReadLine(), out int passengerId))
        {
            Console.WriteLine("Invalid input.");
            return;
        }


        Passenger? passenger = PassenegerRepository.GetById(passengerId);

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
                    ViewAllBookings(passengerId);
                    break;

                case 2:
                    ModifyBooking(passengerId);
                    break;

                case 3:
                    CancleBooking(passengerId);
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
        Console.WriteLine("Enter booking ID to cancel:");
        if(! int.TryParse(Console.ReadLine(), out int cancelBookingId))
        {
            Console.WriteLine("Invalid option.");
            return;
        }


        try
        {
            BookingService.CancelAbooking(cancelBookingId, passengerId);
            Console.WriteLine("Booking cancelled successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }

    private static void ModifyBooking(int passengerId)
    {
        Console.WriteLine("Enter booking ID to modify:");
        if (! int.TryParse(Console.ReadLine(), out int bookingId))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        Console.WriteLine("Do you want to change the class? (y/n)");
        string changeClassOption = Console.ReadLine().ToLower();

        Enum? newClassOfFlight = null;
        if (changeClassOption != "y" && changeClassOption != "n")
        {
            Console.WriteLine("Invalid option.");
            return;
        }
       

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
            try
            {
                BookingService.ModifyBookingClassFlight(bookingId, (ClassOfFlight)newClassOfFlight, passengerId);
                Console.WriteLine("Booking modified successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

        }

        Console.WriteLine("Do you want to change the flight? (y/n)");
        string changeFlightOption = Console.ReadLine().ToLower();

        if (changeClassOption != "y" && changeClassOption != "n")
        {
            Console.WriteLine("Invalid option.");
            return;
        }


        int? newFlightId = null;
        if (changeFlightOption == "y")
        {
            Console.WriteLine("Enter new flight ID:");
            if (! int.TryParse(Console.ReadLine(), out int _newFlightId))
            {
                Console.WriteLine("Invalid input.");
                return;
            }


            newFlightId = _newFlightId;
            try
            {
                BookingService.ModifyBookingFlight(bookingId, passengerId, newFlightId);
                Console.WriteLine("Booking modified successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
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