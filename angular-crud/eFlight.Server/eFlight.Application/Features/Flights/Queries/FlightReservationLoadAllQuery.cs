using eFlight.Domain.Features.Flights;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Application.Features.Flights.Queries
{
    public class FlightReservationLoadAllQuery : IRequest<List<FlightReservation>>
    {
        public int FlightReservationId { get; set; }
    }
}
