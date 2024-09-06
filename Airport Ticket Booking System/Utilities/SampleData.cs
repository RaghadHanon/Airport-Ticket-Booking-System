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
            PassenegersManager.AddAPassenger("John Doe");
            PassenegersManager.AddAPassenger("Jane Smith");
            ManagerController.BatchUploadFlights(@"data.txt");
        }
    }
}
