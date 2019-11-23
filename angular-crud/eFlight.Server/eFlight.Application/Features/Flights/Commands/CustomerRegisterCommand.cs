using eFlight.Domain.Features.Flights;
using MediatR;

namespace eFlight.Application.Features.Flights.Commands
{
    public class CustomerRegisterCommand : IRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public SexEnum Sex { get; set; }
    }
}