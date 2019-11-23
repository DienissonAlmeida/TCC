using eFlight.Application.Features.Flights.Queries;
using eFlight.Domain.Features.Flights;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eFlight.Application.Features.Flights.Handlers
{
    public class FlightReservationLoadAllHandler : IRequestHandler<FlightReservationLoadAllQuery, List<FlightReservation>>
    {
        private readonly IFlightReservationRepository _repository;
        public FlightReservationLoadAllHandler(IFlightReservationRepository flightRepository)
        {
            _repository = flightRepository;
        }


        public Task<List<FlightReservation>> Handle(FlightReservationLoadAllQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetAll();
        }
    }

    public class FlightReservationLoadAByIdHandler : IRequestHandler<FlightReservationLoadByIdQuery, FlightReservation>
    {
        private readonly IFlightReservationRepository _repository;
        public FlightReservationLoadAByIdHandler(IFlightReservationRepository flightRepository)
        {
            _repository = flightRepository;
        }


        public Task<FlightReservation> Handle(FlightReservationLoadByIdQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetById(request.FlightReservationId);
        }
    }

    public class FlightReservationLoadAByFlightIdHandler : IRequestHandler<FlightReservationLoadByFlightIdQuery, List<FlightReservation>>
    {
        private readonly IFlightReservationRepository _repository;
        public FlightReservationLoadAByFlightIdHandler(IFlightReservationRepository flightRepository)
        {
            _repository = flightRepository;
        }

        public Task<List<FlightReservation>> Handle(FlightReservationLoadByFlightIdQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetByFlightId(request.FlightId);
        }
    }
}
