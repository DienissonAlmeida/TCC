using eFlight.Domain.Features.Flights;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Application.Features.Flights.Commands
{
    public class FlightReservationRegisterCommand : IRequest<bool>
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime Return { get; set; }
        public int FlightId { get; set; }
        public IList<CustomerRegisterCommand> CustomerRegisterCommand { get; set; }
    }
}
