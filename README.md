# Airport Ticket Booking System
## Objective:
Develop a .NET console application for an airport ticket booking system. This application should enable passengers to book flight tickets and allow a manager to manage the bookings.

## Data Storage:
Use the file system as the data storage layer.
- ### For the Passenger:
  - #### Features:
     - ##### Book a Flight:
       Select a flight based on various search parameters.
     - ##### Choose a class for the flight:
       (Economy, Business, First Class). Prices should vary according to the class selected.
       
     - ##### Search for Available Flights:
       Parameters:
        - Price
        - Departure Country
        - Destination Country
        - Departure Date
        - Departure Airport
        - Arrival Airport
          
     - ##### Manage Bookings:
        - Cancel a booking
        - Modify a booking
        - View personal bookings
        - 
- ### For the Manager:
  - #### Features:
     - ##### Filter Bookings:
       Parameters:
        - Price
        - Departure Country
        - Destination Country
        - Departure Date
        - Departure Airport
        - Arrival Airport
        - Flight
        - Passenger
        - Class
        - 
     - ##### Batch Flight Upload:
       Import a list of flights into the system using a CSV file.
    
     - ##### Validate Imported Flight Data:
       - Apply model-level validations to the imported file data.
       - Return a detailed list of errors to help the manager identify and rectify issues in the imported file.
         
     - ##### Dynamic Model Validation Details:
       - Provide dynamically generated details about the validation constraints for each field of the flight data model.
       - Example Result:
            - Departure Country:
               - Type: Free Text
               - Constraint: Required
            - Departure Date:
               - Type: Date Time
               - Constraint: Required, Allowed Range (today → future)
