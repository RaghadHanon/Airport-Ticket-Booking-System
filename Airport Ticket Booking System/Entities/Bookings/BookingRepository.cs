using Airport_Ticket_Booking_System.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.Entites.BookingManagement
{
    public class BookingRepository
    {

        private static List<Book> _bookings= new List<Book>();
        public static List<Book> Bookings { get => _bookings; }
        

    }
}
