using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Application.Features.TravelPackages.Commands
{
    public class TravelPackageReservationDeleteCommand : IRequest<bool>
    {
        public int TravelPackageId { get; set; }
    }
}
