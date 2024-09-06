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
public class PassengerUI
{
    public static void BookAFlight()
    {
        Console.Write("\nEnter Passenger ID: ");
        if (int.TryParse(Console.ReadLine(), out int passengerId))
        {
            Passenger? passenger = PassenegersManager.GetById(passengerId);
            if (passenger == null)
            {
                Console.WriteLine($"Passenger with ID {passengerId} not found.");
                return;
            }

            Console.WriteLine("Please enter the flight ID you want to book:");
            int.TryParse(Console.ReadLine(), out int flightId);

            Console.WriteLine("Select a class: (1) Economy, (2) Business, (3) First Class");
            int.TryParse(Console.ReadLine(), out int classOption);

            ClassOfFlight classOfFlight = classOption switch
            {
                1 => ClassOfFlight.Economy,
                2 => ClassOfFlight.Business,
                3 => ClassOfFlight.FirstClass,
                _ => throw new ArgumentException("Invalid class option")
            };

            Book? booking = BookingManager.BookAFlight(classOfFlight, flightId, passengerId);
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

    public static void SearchAvailableFlights()
    {
        Console.WriteLine("Search by: \n1. Price \n2. Departure Country \n3. Destination Country \n4. Departure Airport \n5. Arrival Airport \n6. Date \n7. Exit");
        int.TryParse(Console.ReadLine(), out int searchOption);

        switch (searchOption)
        {
            case 1:
                Console.WriteLine("Enter price:");
                decimal.TryParse(Console.ReadLine(),out decimal price);
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
                DateTime.TryParse(Console.ReadLine() ,out DateTime departureDate);
                FlightBookingFilter.ShowFlightsByDate(departureDate);
                Console.WriteLine(departureDate);
                break;
            case 7:
                break;
            default:
                Console.WriteLine("Invalid option.");
            break;
        }
    }

    public static void ManageBookings()
    {
        Console.Write("\nEnter Passenger ID: ");
        if (int.TryParse(Console.ReadLine(), out int passengerId))
        {
            Passenger? passenger = PassenegersManager.GetById(passengerId);
            if (passenger == null)
            {
                Console.WriteLine($"Passenger with ID {passengerId} not found.");
                return;
            }
            Console.WriteLine("Manage your bookings: \n1. View all bookings \n2. Modify booking \n3. Cancel booking");
            int.TryParse(Console.ReadLine(),out int manageOption );

            switch (manageOption)
            {
                case 1:
                    BookingFilter.ShowBookingsByPassenger(passengerId);
                    break;

                case 2:
                    Console.WriteLine("Enter booking ID to modify:");
                    int.TryParse(Console.ReadLine(),out int bookingId );

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
                        int.TryParse(Console.ReadLine(),out int _newFlightId);
                        newFlightId = _newFlightId;
                    }

                    BookingManager.ModifyAbooking(bookingId, passengerId, newClassOfFlight, newFlightId);
                    Console.WriteLine("Booking modified successfully.");
                    break;

                case 3:
                    Console.WriteLine("Enter booking ID to cancel:");
                    int.TryParse(Console.ReadLine(),out int cancelBookingId );
                    BookingManager.CancelAbooking(cancelBookingId, passengerId);
                    Console.WriteLine("Booking cancelled successfully.");
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}
