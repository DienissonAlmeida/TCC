using AutoMapper;
using eFlight.Application.Features.Cars.Commands;
using eFlight.Domain.Features.Cars;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eFlight.Application.Features.Cars.Handlers
{
    public class CarReservationUpdateHandler : IRequestHandler<CarReservationUpdateCommand, bool>
    {
        private readonly ICarReservationRepository _carReservationRepository;
        private readonly IMapper _mapper;

        public CarReservationUpdateHandler(ICarReservationRepository repository, IMapper mapper)
        {
            _carReservationRepository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(CarReservationUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var carReservationDb = await  _carReservationRepository.GetById(request.Id);

                _mapper.Map(request, carReservationDb);

                 await _carReservationRepository.Update(carReservationDb);

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
