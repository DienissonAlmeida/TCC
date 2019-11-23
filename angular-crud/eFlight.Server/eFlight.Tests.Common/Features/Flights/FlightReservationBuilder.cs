using eFlight.Domain.Features.Flights;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Tests.Common.Features.Flights
{
    public class FlightReservationBuilder
    {
        private static FlightReservation _reservation;

        public static FlightReservationBuilder Start()
        {
            _reservation = new FlightReservation()
            {
                InputDate = DateTime.Now,
                OutputDate = DateTime.Now.AddDays(10),
                Flight = FlightBuilder.Start().Build(),
                FlightReservationCustomers = new List<Customer>()
            };

            return new FlightReservationBuilder();
        }

        public FlightReservationBuilder WithFlight(Flight flight)
        {
            _reservation.Flight = flight;
            return this;
        }

        public FlightReservation Build() => _reservation;

        public FlightReservationBuilder WithFlightId(int flightId)
        {
            _reservation.FlightId = flightId;
            return this;
        }

        public FlightReservationBuilder WithInputDate(DateTime date)
        {
            _reservation.InputDate = date;
            return this;
        }

        public FlightReservationBuilder WithOutputDate(DateTime date)
        {
            _reservation.OutputDate = date;
            return this;
        }


        public FlightReservationBuilder WithCustomer(Customer customer)
        {
            _reservation.FlightReservationCustomers.Add(customer);
            return this;
        }

        public FlightReservationBuilder WithId(int id)
        {
            _reservation.Id = id;
            return this;
        }

    }
}
