using eFlight.Domain.Features.TravelPackages;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Tests.Common.Features.TravelPackages
{
    public class TravelPackageReservationBuilder
    {
        private static TravelPackageReservation _travelPackage;

        public static TravelPackageReservationBuilder Start()
        {
            _travelPackage = new TravelPackageReservation()
            {
                InputDate = DateTime.Now,
                OutputDate = DateTime.Now.AddDays(10),
                TravelPackage = TravelPackageBuilder.Start().Build(),
                TravelPackageCustomers = new List<Domain.Features.Flights.Customer>()
                {
                    CustomerBuilder.Start().Build()
                }
            };

            return new TravelPackageReservationBuilder();
        }

        public TravelPackageReservation Build() => _travelPackage;

        public TravelPackageReservationBuilder WithTravelPackage(TravelPackage travelPackage)
        {
            _travelPackage.TravelPackage = travelPackage;
            return this;
        }

        public TravelPackageReservationBuilder WithInputDate(DateTime inputDate)
        {
            _travelPackage.InputDate = inputDate;
            return this;
        }

        public TravelPackageReservationBuilder WithOutputDate(DateTime outputDate)
        {
            _travelPackage.OutputDate = outputDate;
            return this;
        }
    }
}
