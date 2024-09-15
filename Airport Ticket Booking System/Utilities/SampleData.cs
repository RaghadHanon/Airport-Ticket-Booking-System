using Airport_Ticket_Booking_System.Entities.DataManagement;
using Airport_Ticket_Booking_System.Entities.Passenegers;

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
