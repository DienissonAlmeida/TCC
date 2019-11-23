using eFlight.Domain.Features.Flights;
using MediatR;
using System.Collections.Generic;

namespace eFlight.Application.Features.Flights.Queries
{
    public class FlightLoadAllQuery : IRequest<List<Flight>>
    {

    }
}
