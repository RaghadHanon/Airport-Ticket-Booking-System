using Airport_Ticket_Booking_System.Entites.ManagerManagemnt;
using Airport_Ticket_Booking_System.Entites.PassengersManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.Utilities
{
    public class SampleData
    {
        public static void InitializeSampleData()
        {
            PassenegerRepository.AddAPassenger("John Doe");
            PassenegerRepository.AddAPassenger("Jane Smith");
            DataRepository.BatchUploadFlights(@"Data.CSV");
            DataRepository.ValidateImportedFlightData();
        }
    }
}
