
using Airport_Ticket_Booking_System.Entities.Flights.Repository;

namespace Airport_Ticket_Booking_System.Entities.DataManagement;
public interface IFlightDataFileProcessing
{
    public IFlightRepository FlightRepository { get; }
    void BatchUploadFlights(string fileName);
    List<string> ValidateImportedFlightData();
    void ViewValidationErrorList();
}