namespace Airport_Ticket_Booking_System.Entites.PassengersManager;
public static class PassenegerRepository
{
    public static List<Passenger> Passengers { get; } = new List<Passenger>();
    public static Passenger? AddAPassenger(string name)
    {
        Passenger? passenger = null;
        try
        {
            passenger = new Passenger(name);
            Passengers.Add(passenger);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error Adding passenger: {e.Message}");
        }
        return passenger;
    }
    public static Passenger? GetById(int? id)
    {
        return Passengers.FirstOrDefault(p => p.Id == id);
    }
}
