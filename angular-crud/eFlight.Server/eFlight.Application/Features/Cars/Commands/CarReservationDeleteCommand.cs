using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Application.Features.Cars.Commands
{
    public class CarReservationDeleteCommand : IRequest<bool>
    {
        public int CarReservationId { get; set; }
    }
}
