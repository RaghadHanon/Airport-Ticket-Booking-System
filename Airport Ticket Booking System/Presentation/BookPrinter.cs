using Airport_Ticket_Booking_System.Entites.BookingManagement;
using Airport_Ticket_Booking_System.Entites.FlightManagment;
using System.Text;

namespace Airport_Ticket_Booking_System.Presentation;
public class BookPrinter
{
    private readonly Book _book;
    public BookPrinter(Book book)
    {
        _book = book ?? throw new ArgumentNullException(nameof(book));
    }
    public string PrintBooking()
    {
        return $$"""
                {
                   BookId: {{_book.Id}},
                   Booked Class: {{_book.ClassOfFlight}},
                   Price: {{_book.Flight?.ClassPriceMap[(ClassOfFlight)_book.ClassOfFlight]!}}$,
                   Booking Date: {{_book.BookingDate}},
                   Passenger Details: {{new PassengerPrinter(_book.Passenger).PrintPassenger()}},

                   Flight Details: 
                  {{new FlightPrinter(_book.Flight).PrintFlight()}}

                }     
                """;
    }
    public static string PrintBookings(IEnumerable<Book> bookings,string? title=null)
    {
        if (bookings == null || !bookings.Any())
            return "No bookings available at the moment.";
        
        StringBuilder sb = new StringBuilder();
        sb.Append(title);
        sb.Append(string.Join("\n", bookings.Select(b => new BookPrinter(b).PrintBooking())));
        return sb.ToString();
    }
}
