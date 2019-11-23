using eFlight.Application.Features.Flights.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Tests.Common.Features.Flights
{
    public class FlightReservationUpdateCommandBuilder
    {
        private static FlightReservationUpdateCommand _command;

        public static FlightReservationUpdateCommandBuilder Start()
        {
            _command = new FlightReservationUpdateCommand()
            {
                Id = 1,
                InputDate = DateTime.Now,
                OutputDate = DateTime.Now.AddDays(10),
                FlightCustomers = new List<CustomerUpdateCommand>()
                {
                    PassengerUpdateCommandBuilder.Start().Build()
                }
            };

            return new FlightReservationUpdateCommandBuilder();
        }

        public FlightReservationUpdateCommand Build() => _command;

        public FlightReservationUpdateCommandBuilder WithId(int id)
        {
            _command.Id = id;
            return this;
        }
    }
}
