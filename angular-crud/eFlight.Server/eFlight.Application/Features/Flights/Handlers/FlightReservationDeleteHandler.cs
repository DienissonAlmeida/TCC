using eFlight.Application.Features.Flights.Commands;
using eFlight.Domain.Features.Flights;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace eFlight.Application.Features.Flights.Handlers
{
    public class FlightReservationDeleteHandler : IRequestHandler<FlightReservationDeleteCommand, bool>
    {
        private readonly IFlightReservationRepository _flightRepository;

        public FlightReservationDeleteHandler(IFlightReservationRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<bool> Handle(FlightReservationDeleteCommand request, CancellationToken cancellationToken)
        {
            var hotel = await _flightRepository.GetById(request.FlightReservationId);

            if (hotel == null)
                return false;

            if (hotel.CanDelete())
            {
                await _flightRepository.DeleteById(request.FlightReservationId);
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
