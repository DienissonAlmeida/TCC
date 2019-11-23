using System;
using System.Collections.Generic;
using System.Text;
using eFlight.Domain.Features.Cars;
using eFlight.Domain.Features.Flights;
using eFlight.Domain.Features.Hotels;
using eFlight.Domain.Features.Users;

namespace eFlight.Domain.Features.TravelPackages
{
    public class TravelPackage : Entity
    {
        public string Name { get; set; }

        public IList<TravelPackageReservation> TravelPackageReservations { get; set; }
    }
}
