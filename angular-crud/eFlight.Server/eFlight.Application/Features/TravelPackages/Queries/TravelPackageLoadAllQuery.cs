using eFlight.Domain.Features.TravelPackages;
using MediatR;
using System.Collections.Generic;

namespace eFlight.Application.Features.TravelPackages.Queries
{
    public class TravelPackageLoadAllQuery : IRequest<List<TravelPackage>>
    {
    }
}
