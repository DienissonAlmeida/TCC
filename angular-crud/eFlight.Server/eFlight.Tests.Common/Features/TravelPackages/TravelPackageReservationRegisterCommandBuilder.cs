using eFlight.Application.Features.TravelPackages.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Tests.Common.Features.TravelPackages
{
    public class TravelPackageReservationRegisterCommandBuilder
    {
        private static TravelPackageReservationRegisterCommand _command;

        public static TravelPackageReservationRegisterCommandBuilder Start()
        {
            _command = new TravelPackageReservationRegisterCommand()
            {
                InputDate = DateTime.Now,
                OutputDate = DateTime.Now.AddDays(10),
                Description = "Reserva Dienisson",
                TravelPackageId = 1,
                TravelPackageCustomers = new List<Domain.Features.Flights.Customer>
                {
                    CustomerBuilder.Start().Build()
                }

            };

            return new TravelPackageReservationRegisterCommandBuilder();
        }

        public TravelPackageReservationRegisterCommand Build() => _command;
    }
}
