using eFlight.Domain.Features.Flights;
using MediatR;

namespace eFlight.Application.Features.Flights.Queries
{
    public class FlightReservationLoadByIdQuery : IRequest<FlightReservation>
    {
        public int FlightReservationId { get; set; }
    }
}
