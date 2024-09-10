using Airport_Ticket_Booking_System.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.Utilities;
public static class ErrorException
{
    public static void error(string message, string title = "")
    {
        throw new ArgumentException($"""

                                     {title}
                                     {message}

                                     """);
    }
}
