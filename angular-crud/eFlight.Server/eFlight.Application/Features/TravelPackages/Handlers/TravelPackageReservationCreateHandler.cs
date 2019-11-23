using AutoMapper;
using eFlight.Application.Features.TravelPackages.Commands;
using eFlight.Domain.Features.TravelPackages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eFlight.Application.Features.TravelPackages.Handlers
{
    public class TravelPackageReservationCreateHandler : IRequestHandler<TravelPackageReservationRegisterCommand, bool>
    {
        private readonly ITravelPackageReservationRepository _travelPackageReservationRepository;
        private readonly IMapper _mapper;

        public TravelPackageReservationCreateHandler(ITravelPackageReservationRepository repository, IMapper mapper)
        {
            _travelPackageReservationRepository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(TravelPackageReservationRegisterCommand request, CancellationToken cancellationToken)
        {
            var travelPackageReservation = _mapper.Map<TravelPackageReservation>(request);

            await _travelPackageReservationRepository.Add(travelPackageReservation);

            return true;
        }
    }
}
