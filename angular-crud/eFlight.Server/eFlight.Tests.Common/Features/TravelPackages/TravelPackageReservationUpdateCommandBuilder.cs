using eFlight.Application.Features.TravelPackages.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Tests.Common.Features.TravelPackages
{
    public class TravelPackageReservationUpdateCommandBuilder
    {
        private static TravelPackageReservationUpdateCommand _command;

        public static TravelPackageReservationUpdateCommandBuilder Start()
        {
            _command = new TravelPackageReservationUpdateCommand()
            {
            };

            return new TravelPackageReservationUpdateCommandBuilder();
        }

        public TravelPackageReservationUpdateCommand Build() => _command;

        public TravelPackageReservationUpdateCommandBuilder WithId(int Id)
        {
            _command.Id = Id;
            return this;
        }
    }
}
