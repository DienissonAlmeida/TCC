using System;
using eFlight.Application.Features.Hotels.Commands;

namespace eFlight.Tests.Common.Features.Hotels
{
    public class HotelReservationRegisterCommandBuilder
    {
        private static HotelReservationRegisterCommand _command;

        public static HotelReservationRegisterCommandBuilder Start()
        {
            _command = new HotelReservationRegisterCommand()
            {
                Description = "Reserva de Hotel",
                InputDate = DateTime.Now,
                OutputDate = DateTime.Now.AddDays(10)

            };

            return new HotelReservationRegisterCommandBuilder();
        }

        public HotelReservationRegisterCommand Build() => _command;

        public HotelReservationRegisterCommandBuilder WithDescription(string description)
        {
            _command.Description = description;
            return this;
        }
    }
}
