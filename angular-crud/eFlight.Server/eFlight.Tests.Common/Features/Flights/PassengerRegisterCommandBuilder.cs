using eFlight.Application.Features.Flights.Commands;

namespace eFlight.Tests.Common.Features.Flights
{
    public class CustomerRegisterCommandBuilder
    {
        private static CustomerRegisterCommand _command;

        public static CustomerRegisterCommandBuilder Start()
        {
            _command = new CustomerRegisterCommand()
            {
                Name = "Dienisson",
                LastName = "Almeida",
                Sex = Domain.Features.Flights.SexEnum.Male
            };
            return new CustomerRegisterCommandBuilder();
        }

        public CustomerRegisterCommand Build() => _command;

        public CustomerRegisterCommandBuilder WithName(string name)
        {
            _command.Name = name;
            return this;
        }

        public CustomerRegisterCommandBuilder WithLastName(string lastName)
        {
            _command.LastName = lastName;
            return this;
        }

        public CustomerRegisterCommandBuilder WithLastName(Domain.Features.Flights.SexEnum sex)
        {
            _command.Sex = sex;
            return this;
        }

    }
}
