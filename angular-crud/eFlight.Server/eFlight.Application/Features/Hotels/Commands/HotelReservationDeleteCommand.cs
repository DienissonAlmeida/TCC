using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Application.Features.Hotels.Commands
{
    public class HotelReservationDeleteCommand : IRequest<bool>
    {
        public int HotelReservationId { get; set; }
    }
}
