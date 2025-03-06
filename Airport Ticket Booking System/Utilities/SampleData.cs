using Airport_Ticket_Booking_System.Entities.DataManagement;
using Airport_Ticket_Booking_System.Entities.Passengers.Repository;

namespace Airport_Ticket_Booking_System.Utilities;
public class SampleData
{
    private IPassenegerRepository _passenegerRepository;
    private IFlightDataFileProcessing _flightDataFileProcessing;
    public SampleData(IPassenegerRepository passenegerRepository, IFlightDataFileProcessing flightDataFileProcessing)
    {
        _passenegerRepository = passenegerRepository;
        _flightDataFileProcessing = flightDataFileProcessing;
    }

    public void InitializeSampleData()
    {
        _passenegerRepository.AddAPassenger("John Doe");
        _passenegerRepository.AddAPassenger("Jane Smith");
        _flightDataFileProcessing.BatchUploadFlights(@"Data.CSV");
        _flightDataFileProcessing.ValidateImportedFlightData();
    }
}
