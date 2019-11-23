using eFlight.Application.Features.Cars.Commands;
using eFlight.Application.Features.Hotels.Commands;
using eFlight.Domain.Features.Cars;
using eFlight.Domain.Features.Hotels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eFlight.Application.Features.Hotels.Handlers
{
    public class CarReservationCreateHandler : IRequestHandler<CarReservationRegisterCommand, bool>
    {
        private readonly ICarReservationRepository _hotelReservationRepository;

        public CarReservationCreateHandler(ICarReservationRepository repository)
        {
            _hotelReservationRepository = repository;
        }

        public async Task<bool> Handle(CarReservationRegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var carReservation = new CarReservation()
                {
                    Name = request.Description,
                    InputDate = request.InputDate,
                    OutputDate = request.OutputDate,
                    CarReservationCustomers = request.CarCustomers,
                    CarId = request.CarId,

                };

                await _hotelReservationRepository.Add(carReservation);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
