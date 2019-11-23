using eFlight.Application.Features.Cars.Commands;
using eFlight.Application.Features.TravelPackages.Commands;
using eFlight.Domain.Features.Cars;
using eFlight.Domain.Features.TravelPackages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eFlight.Application.Features.Cars.Handlers
{
    public class TravelPackageReservationDeleteHandler : IRequestHandler<TravelPackageReservationDeleteCommand, bool>
    {
        private readonly ITravelPackageReservationRepository _travelPackageRepository;

        public TravelPackageReservationDeleteHandler(ITravelPackageReservationRepository repository)
        {
            _travelPackageRepository = repository;
        }

        public async Task<bool> Handle(TravelPackageReservationDeleteCommand request, CancellationToken cancellationToken)
        {
            var travelPackageReservation = await _travelPackageRepository.GetById(request.TravelPackageId);

            if (travelPackageReservation == null)
                return false;
            else
            {
                await _travelPackageRepository.DeleteById(request.TravelPackageId);
                return true;
            }

        }
    }
}
