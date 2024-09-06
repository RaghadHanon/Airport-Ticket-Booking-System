﻿using Airport_Ticket_Booking_System.Entites.FlightManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.Entites.BookingManagement
{
    public class FlightBookingFilter
    {
        public static void ShowAvailableFlights()
        {
            var flights = FlightsManager.GetAllFlights(DateTime.Now);
            if (flights.Any())
            {
                Console.WriteLine($"Available flights departing after {DateTime.Now}:\n ");
                foreach (var flight in flights)
                    Console.WriteLine(flight);
            }
            else
            {
                Console.WriteLine("No available flights at the moment.");
            }
        }
        public static void ShowFlightsByDate(DateTime date)
        {
            if (date.CompareTo(DateTime.Now) <= 0)
                Console.WriteLine("You’ve chosen a date that has already passed. Please pick a future date.");
            else
            {
                var flights = FlightsManager.GetAllFlights(date);
                if (flights.Any())
                {
                    Console.WriteLine($"Available flights departing after {date}:\n ");
                    foreach (var flight in flights)
                        Console.WriteLine(flight);
                }
                else
                {
                    Console.WriteLine("No available flights at the moment.");
                }
            }
        }
        public static void ShowFlightsByPrice(decimal price)
        {
            var flights = FlightsManager.GetByPrice(price, DateTime.Now);
            if (flights.Any())
            {
                Console.WriteLine($"Available flights matching the price {price} after {DateTime.Now}:\n ");
                foreach (var flight in flights)
                {
                    ClassOfFlight classOfFlight = flight.ClassPriceMap.FirstOrDefault(x => x.Value == price).Key;

                    Console.WriteLine($"\"{classOfFlight} class\" matches your specifications\n {flight}");
                }
            }
            else
            {
                Console.WriteLine("No available flights at the moment.");
            }
        }
        public static void ShowFlightsByDepartureCountry(string departureCountry)
        {
            var flights = FlightsManager.GetByDepartureCountry(departureCountry, DateTime.Now);
            if (flights.Any())
            {
                Console.WriteLine($"Available flights departing from {departureCountry} after {DateTime.Now}:\n ");
                foreach (var flight in flights)
                {
                    Console.WriteLine(flight);
                }
            }
            else
            {
                Console.WriteLine("No available flights at the moment.");
            }
        }
        public static void ShowFlightsByDestinationCountry(string destinationCountry)
        {
            var flights = FlightsManager.GetByDestinationCountry(destinationCountry, DateTime.Now);
            if (flights.Any())
            {
                Console.WriteLine($"Available flights to {destinationCountry} after {DateTime.Now}:\n ");
                foreach (var flight in flights)
                {
                    Console.WriteLine(flight);
                }
            }
            else
            {
                Console.WriteLine("No available flights at the moment.");
            }
        }
        public static void ShowFlightsByDepartureAirport(string departureAirport)
        {
            var flights = FlightsManager.GetByDepartureAirport(departureAirport, DateTime.Now);
            if (flights.Any())
            {
                Console.WriteLine($"Available flights departing from {departureAirport} Airport after {DateTime.Now}:\n ");
                foreach (var flight in flights)
                {
                    Console.WriteLine(flight);
                }
            }
            else
            {
                Console.WriteLine("No available flights at the moment.");
            }
        }
        public static void ShowFlightsByArrivalAirport(string arrivalAirport)
        {
            var flights = FlightsManager.GetByArrivalAirport(arrivalAirport, DateTime.Now);
            if (flights.Any())
            {
                Console.WriteLine($"Available flights to {arrivalAirport} Airport after {DateTime.Now}:\n ");
                foreach (var flight in flights)
                {
                    Console.WriteLine(flight);
                }
            }
            else
            {
                Console.WriteLine("No available flights at the moment.");
            }
        }
    }
}
