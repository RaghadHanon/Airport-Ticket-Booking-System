using Airport_Ticket_Booking_System.Entities.Bookings.Core;
using Airport_Ticket_Booking_System.Entities.Flights.Core;
using Airport_Ticket_Booking_System.Utilities;
using System.Text;

namespace Airport_Ticket_Booking_System.Presentation.EntitiesPrinters;
public static class BookPrinter
{
    public static string PrintBooking(Book book)
    {
        return $$"""
                {
                   BookId: {{book.Id}},
                   Booked Class: {{book.ClassOfFlight}},
                   Price: {{book.Flight?.ClassPriceMap[(ClassOfFlight)book.ClassOfFlight]!}}$,
                   Booking Date: {{book.BookingDate}},
                   Passenger Details: {{PassengerPrinter.PrintPassenger(book.Passenger)}},

                   Flight Details: 
                  {{FlightPrinter.PrintFlight(book.Flight)}}

                }     
                """;
    }

    public static string PrintBookings(IEnumerable<Book> bookings, string? title = null)
    {
        if (bookings == null || !bookings.Any())
            return ErrorMessages.NoAvailableBookings;

        var sb = new StringBuilder();
        sb.Append(title);
        sb.Append(string.Join("\n", bookings.Select(b => PrintBooking(b))));
        return sb.ToString();
    }
}
