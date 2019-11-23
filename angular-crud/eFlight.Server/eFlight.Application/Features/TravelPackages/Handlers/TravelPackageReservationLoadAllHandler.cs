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
    public class TravelPackageReservationLoadAllHandler : IRequestHandler<TravelPackageReservationLoadAllQuery, List<TravelPackageReservation>>
    {
        private readonly ITravelPackageReservationRepository _repository;
        public TravelPackageReservationLoadAllHandler(ITravelPackageReservationRepository hotelRepository)
        {
            _repository = hotelRepository;
        }

        public Task<List<TravelPackageReservation>> Handle(TravelPackageReservationLoadAllQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetAll();
        }
    }
}
