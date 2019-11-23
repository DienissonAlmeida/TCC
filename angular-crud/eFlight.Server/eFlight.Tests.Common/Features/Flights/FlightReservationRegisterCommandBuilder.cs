using eFlight.Application.Features.Flights.Commands;
using eFlight.Domain.Features.Flights;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Tests.Common.Features.Flights
{
    public class FlightReservationRegisterCommandBuilder
    {
        private static FlightReservationRegisterCommand _command;

        public static FlightReservationRegisterCommandBuilder Start()
        {
            _command = new FlightReservationRegisterCommand()
            {
                Date = DateTime.Now,
                Return = DateTime.Now.AddDays(10),
                FlightId = 1,
                Description = "Reserva de Voo",
                CustomerRegisterCommand = new List<CustomerRegisterCommand>()
                {
                    CustomerRegisterCommandBuilder.Start().Build()
                },
                
            };

            return new FlightReservationRegisterCommandBuilder();
        }

        public FlightReservationRegisterCommand Build() => _command;

        public FlightReservationRegisterCommandBuilder WithDescription(string description)
        {
            _command.Description = description;
            return this;
        }
    }
}
