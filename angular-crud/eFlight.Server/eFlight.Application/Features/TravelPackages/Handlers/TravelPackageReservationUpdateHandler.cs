using AutoMapper;
using eFlight.Application.Features.Cars.Commands;
using eFlight.Application.Features.TravelPackages.Commands;
using eFlight.Domain.Features.TravelPackages;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace eFlight.Application.Features.Cars.Handlers
{
    public class TravelPackageReservationUpdateHandler : IRequestHandler<TravelPackageReservationUpdateCommand, bool>
    {
        private readonly ITravelPackageReservationRepository _travelPackageRepository;
        private readonly IMapper _mapper;

        public TravelPackageReservationUpdateHandler(ITravelPackageReservationRepository repository, IMapper mapper)
        {
            _travelPackageRepository = repository;
            _mapper = mapper;
        }


        public async Task<bool> Handle(TravelPackageReservationUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var travelPackageReservationDb = _travelPackageRepository.GetAll().Result.First(x => x.Id == request.Id);

                _mapper.Map(request, travelPackageReservationDb);

                _travelPackageRepository.Update(travelPackageReservationDb);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
