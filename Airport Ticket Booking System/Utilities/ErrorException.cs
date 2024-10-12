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
