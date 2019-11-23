using eFlight.Application.Features.Cars.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Tests.Common.Features.Cars
{
    public class CarReservationRegisterCommandBuilder
    {
        private static CarReservationRegisterCommand _command;

        public static CarReservationRegisterCommandBuilder Start()
        {
            _command = new CarReservationRegisterCommand()
            {
                Description = "Reserva de Carro",
                InputDate = DateTime.Now,
                OutputDate = DateTime.Now.AddDays(10)

            };

            return new CarReservationRegisterCommandBuilder();
        }

        public CarReservationRegisterCommand Build() => _command;

        public CarReservationRegisterCommandBuilder WithName(string description)
        {
            _command.Description = description;
            return this;
        }
    }
}
