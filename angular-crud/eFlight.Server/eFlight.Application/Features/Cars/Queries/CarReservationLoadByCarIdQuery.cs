using eFlight.Domain.Features.Cars;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Application.Features.Cars.Queries
{
    public class CarReservationLoadByCarIdQuery : IRequest<List<CarReservation>>
    {
        public int CarId { get; set; }
    }
}
