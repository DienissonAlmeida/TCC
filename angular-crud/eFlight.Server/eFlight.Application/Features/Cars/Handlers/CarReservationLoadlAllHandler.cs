using eFlight.Application.Features.Cars.Queries;
using eFlight.Domain.Features.Cars;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eFlight.Application.Features.Cars.Handlers
{
    public class CarReservationLoadlAllHandler : IRequestHandler<CarReservationLoadAllQuery, List<CarReservation>>
    {
        private readonly ICarReservationRepository _repository;
        public CarReservationLoadlAllHandler(ICarReservationRepository _carRepository)
        {
            _repository = _carRepository;
        }

        public Task<List<CarReservation>> Handle(CarReservationLoadAllQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetAll();
        }
    }

    public class CarReservationLoadAByIdHandler : IRequestHandler<CarReservationLoadByIdQuery, CarReservation>
    {
        private readonly ICarReservationRepository _repository;
        public CarReservationLoadAByIdHandler(ICarReservationRepository flightRepository)
        {
            _repository = flightRepository;
        }


        public Task<CarReservation> Handle(CarReservationLoadByIdQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetById(request.CarReservationId);
        }
    }

    public class CarReservationLoadAByCarIdHandler : IRequestHandler<CarReservationLoadByCarIdQuery, List<CarReservation>>
    {
        private readonly ICarReservationRepository _repository;
        public CarReservationLoadAByCarIdHandler(ICarReservationRepository flightRepository)
        {
            _repository = flightRepository;
        }

        public Task<List<CarReservation>> Handle(CarReservationLoadByCarIdQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetByCarId(request.CarId);
        }

    }
}
