using Airport_Ticket_Booking_System.Entities.Bookings.Core;
using Airport_Ticket_Booking_System.Entities.Bookings.Query;
using Airport_Ticket_Booking_System.Entities.Bookings.Repository;
using Airport_Ticket_Booking_System.Entities.Flights.Core;
using Airport_Ticket_Booking_System.Entities.Passengers.Core;
using Moq;

namespace Airport_Ticket_Booking_System_Tests.BookingQueryTests;
public class BookingsQueryFixture
{
    public BookingQuery sut { get; private set; }
    private Mock<IBookingRepository> mockBookingRepository;
    private List<Book> Bookings;
    public BookingsQueryFixture()
    {
        Bookings = new List<Book>
            {
                new Book(
                    ClassOfFlight.FirstClass,
                    new Flight(300,700,1200,"USA","UK",DateTime.Parse("2024-10-15"),"JFK","LHR"),
                    new Passenger("John")),
                new Book(
                    ClassOfFlight.Business,
                    new Flight( 630,810,1320,"Brazil","Italy",DateTime.Parse("2024-04-09"),"GRU","FCO"),
                    new Passenger("Sam")),
                new Book(
                    ClassOfFlight.Economy,
                    new Flight(310,760,1300,"France","Brazil",DateTime.Parse("2024-05-07"),"CDG","GRU"),
                    new Passenger("Dany")),
            };
        mockBookingRepository = new Mock<IBookingRepository>();
        mockBookingRepository.Setup(x => x.Bookings).Returns(Bookings);
        sut = new BookingQuery(mockBookingRepository.Object);
    }

}