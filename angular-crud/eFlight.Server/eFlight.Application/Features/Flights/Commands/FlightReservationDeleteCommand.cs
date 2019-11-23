using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Application.Features.Flights.Commands
{
    public class FlightReservationDeleteCommand : IRequest<bool>
    {
        public int FlightReservationId { get; set; }
    }
}
