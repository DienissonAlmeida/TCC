using eFlight.Application.Features.Hotels.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Tests.Common.Features.Hotels
{
    public class HotelReservationUpdateCommandBuilder
    {
        private static HotelReservationUpdateCommand _command;

        public static HotelReservationUpdateCommandBuilder Start()
        {
            _command = new HotelReservationUpdateCommand()
            {
            };

            return new HotelReservationUpdateCommandBuilder();
        }

        public HotelReservationUpdateCommand Build() => _command;

        public HotelReservationUpdateCommandBuilder WithId(int Id)
        {
            _command.Id = Id;
            return this;
        }
    }
}
