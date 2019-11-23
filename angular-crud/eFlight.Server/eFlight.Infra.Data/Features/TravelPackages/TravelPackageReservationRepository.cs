using eFlight.Data.Context;
using eFlight.Domain.Features.TravelPackages;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Infra.Data.Features.TravelPackages
{
    public class TravelPackageReservationRepository : RepositoryBase<TravelPackageReservation>, ITravelPackageReservationRepository
    {
        public TravelPackageReservationRepository(eFlightDbContext eFlightDbContext) : base(eFlightDbContext)
        {

        }
    }
}
