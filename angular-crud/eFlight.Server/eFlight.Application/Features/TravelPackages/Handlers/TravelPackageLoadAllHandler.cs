using eFlight.Application.Features.TravelPackages.Queries;
using eFlight.Domain;
using eFlight.Domain.Features.TravelPackages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eFlight.Application.Features.TravelPackages.Handlers
{
    public class TravelPackageLoadAllHandler : IRequestHandler<TravelPackageLoadAllQuery, List<TravelPackage>>
    {
        private readonly IRepositoryBase<TravelPackage> _repository;
        public TravelPackageLoadAllHandler(IRepositoryBase<TravelPackage> repository)
        {
            _repository = repository;
        }

        public Task<List<TravelPackage>> Handle(TravelPackageLoadAllQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetAll();
        }
    }
}
