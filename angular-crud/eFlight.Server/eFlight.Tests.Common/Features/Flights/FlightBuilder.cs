using eFlight.Domain.Features.Flights;
using System;
using System.Collections.Generic;

namespace eFlight.Tests.Common.Features.Flights
{
    public class FlightBuilder
    {
        private static Flight _flight;

        public static FlightBuilder Start()
        {
            _flight = new Flight()
            {
                Origin = "Lages",
                Destination = "Campinas",
                FlightReservations = new List<FlightReservation>()
            };

            return new FlightBuilder();
        }

        public Flight Build() => _flight;

        public FlightBuilder WithVacancies(int vacancie)
        {
            _flight.AvailableVacancies = vacancie;
            return this;
        }


        public FlightBuilder WithFlighReservation(FlightReservation reservation)
        {
            _flight.FlightReservations.Add(reservation);
            return this;
        }
    }
}
