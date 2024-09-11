using Airport_Ticket_Booking_System.Entites.ManagerManagemnt;
using Airport_Ticket_Booking_System.Entites.PassengersManager;

namespace Airport_Ticket_Booking_System.Utilities;
public static class SampleData
{
    public static void InitializeSampleData()
    {
        PassenegerRepository.AddAPassenger("John Doe");
        PassenegerRepository.AddAPassenger("Jane Smith");
        DataRepository.BatchUploadFlights(@"Data.CSV");
        DataRepository.ValidateImportedFlightData();
    }
}
