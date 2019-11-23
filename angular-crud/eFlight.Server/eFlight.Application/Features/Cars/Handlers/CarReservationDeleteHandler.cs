using eFlight.Application.Features.Cars.Commands;
using eFlight.Domain.Features.Cars;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eFlight.Application.Features.Cars.Handlers
{
    public class CarReservationDeleteHandler : IRequestHandler<CarReservationDeleteCommand, bool>
    {
        private readonly ICarReservationRepository _carReservationRepository;

        public CarReservationDeleteHandler(ICarReservationRepository repository)
        {
            _carReservationRepository = repository;
        }
        public async Task<bool> Handle(CarReservationDeleteCommand request, CancellationToken cancellationToken)
        {
            var carReservation = await _carReservationRepository.GetById(request.CarReservationId);

            if (carReservation == null)
                return false;

            else
            {
                await _carReservationRepository.DeleteById(request.CarReservationId);
                return true;
            }

        }
    }
}
