using Airport_Ticket_Booking_System.Entites.FlightManagment;
using Airport_Ticket_Booking_System.Entites.PassengersManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.Entites.BookingManagement;
public static class BookingRepository
{

    public static List<Book> Bookings { get; } = new List<Book>();
    public static Book? BookAFlight(ClassOfFlight classOfFlight, int flgihtId,int passengerId)
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
        Book? book = new Book(classOfFlight, flight,passenger);
        

        passenger?.Bookings.Add(book);
        Bookings.Add(book);
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
        Bookings.Remove(book);
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

        book.ClassOfFlight = newClassOfFlight?? book.ClassOfFlight;
        if(newFlgihtId is not null)
            book.Flight = FlightsRepository.GetById(newFlgihtId) ?? book.Flight;

        return book;
    }
    public static Book? GetById(int id)
    {
        return Bookings.FirstOrDefault(b => b.Id == id);
    }

    public static List<Book> GetAllBookings()
    {
        return Bookings;
    }
    
    public static List<Book> GetAllBookings(DateTime date)
    {
        return Bookings.Where(b => b.Flight.DepartureDate.CompareTo(date) >= 0).ToList();
    }
    public static List<Book> GetByPassenger(int id)
    {
        return Bookings.Where(b => b.Passenger.Id == id).ToList();
    }
    public static List<Book> GetByFlight(int id)
    {
        return Bookings.Where(b => b.Flight.Id == id).ToList();
    }
    public static List<Book> GetByClassFlight(ClassOfFlight classOfFlight)
    {
        return Bookings.Where(b => b.ClassOfFlight == classOfFlight).ToList();
    }

    public static List<Book> GetByPrice(decimal price)
    {
        return Bookings.Where(b => b.Flight.ClassPriceMap[b.ClassOfFlight]==price).ToList();
    }
    
    public static List<Book> GetByPrice(decimal price, DateTime date)
    {
        return Bookings.Where(b => b.Flight.ClassPriceMap[b.ClassOfFlight] == price && b.Flight.DepartureDate.CompareTo(date) >= 0).ToList();
    }

    public static List<Book> GetByDepartureCountry(string departureCountry)
    {
        return Bookings.Where(b => b.Flight.DepartureCountry == departureCountry).ToList();
    }
    
    public static List<Book> GetByDepartureCountry(string departureCountry, DateTime date)
    {
        return Bookings.Where(b => b.Flight.DepartureCountry == departureCountry && b.Flight.DepartureDate.CompareTo(date) >= 0).ToList();
    }

    
    public static List<Book> GetByDestinationCountry(string destinationCountry)
    {
        return Bookings.Where(b => b.Flight.DestinationCountry == destinationCountry).ToList();
    }
    
    public static List<Book> GetByDestinationCountry(string destinationCountry, DateTime date)
    {
        return Bookings.Where(b => b.Flight.DestinationCountry == destinationCountry && b.Flight.DepartureDate.CompareTo(date) >= 0).ToList();
    }
    

    public static List<Book> GetByDepartureDate(DateTime departureDate)
    {
        return Bookings.Where(b => b.Flight.DepartureDate == departureDate).ToList();
    }

    

    public static List<Book> GetByDepartureAirport(string departureAirport)
    {
        return Bookings.Where(b => b.Flight.DepartureAirport == departureAirport).ToList();
    }
    
    public static List<Book> GetByDepartureAirport(string departureAirport, DateTime date)
    {
        return Bookings.Where(b => b.Flight.DepartureAirport == departureAirport && b.Flight.DepartureDate.CompareTo(date) >= 0).ToList();
    }

    

    public static List<Book> GetByArrivalAirport(string arrivalAirport)
    {
        return Bookings.Where(b => b.Flight.ArrivalAirport == arrivalAirport).ToList();
    }
    
    public static List<Book> GetByArrivalAirport(string arrivalAirport, DateTime date)
    {
        return Bookings.Where(b => b.Flight.ArrivalAirport == arrivalAirport && b.Flight.DepartureDate.CompareTo(date) >= 0).ToList();
    }

    


}

