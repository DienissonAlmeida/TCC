using eFlight.Application.Features.Flights.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Tests.Common.Features.Flights
{
    public class PassengerUpdateCommandBuilder
    {
        private static CustomerUpdateCommand _command;

        public static PassengerUpdateCommandBuilder Start()
        {
            _command = new CustomerUpdateCommand()
            {
                Name = "Dienisson",
                LastName = "Almeida",
                Sex = Domain.Features.Flights.SexEnum.Male
            };
            return new PassengerUpdateCommandBuilder();
        }

        public CustomerUpdateCommand Build() => _command;

        public PassengerUpdateCommandBuilder WithName(string name)
        {
            _command.Name = name;
            return this;
        }

        public PassengerUpdateCommandBuilder WithLastName(string lastName)
        {
            _command.LastName = lastName;
            return this;
        }

        public PassengerUpdateCommandBuilder WithLastName(Domain.Features.Flights.SexEnum sex)
        {
            _command.Sex = sex;
            return this;
        }
    }
}
