using eFlight.Application.Features.Cars.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Tests.Common.Features.Cars
{
    public class CarReservationUpdateCommandBuilder
    {
        private static CarReservationUpdateCommand _command;

        public static CarReservationUpdateCommandBuilder Start()
        {
            _command = new CarReservationUpdateCommand()
            {

            };

            return new CarReservationUpdateCommandBuilder();
        }

        public CarReservationUpdateCommand Build() => _command;

        public CarReservationUpdateCommandBuilder WithId(int Id)
        {
            _command.Id = Id;
            return this;
        }
    }
}
