using eFlight.Domain.Features.Flights;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eFlight.Application.Features.Flights
{
    public interface IFlightAppService
    {
        Task<List<Flight>> GetFlights();
    }
}
