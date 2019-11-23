using eFlight.Domain.Features.TravelPackages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Application.Features.TravelPackages.Queries
{
    public class TravelPackageReservationLoadAllQuery : IRequest<List<TravelPackageReservation>>
    {
    }
}
