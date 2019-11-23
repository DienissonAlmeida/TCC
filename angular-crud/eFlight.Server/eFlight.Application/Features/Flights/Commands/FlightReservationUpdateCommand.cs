using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Application.Features.Flights.Commands
{
    public class FlightReservationUpdateCommand : IRequest<bool>
    {
        public int? Id { get; set; }
        public string Description { get; set; }
        public DateTime? InputDate { get; set; }
        public DateTime? OutputDate { get; set; }
        public virtual IList<CustomerUpdateCommand> FlightCustomers { get; set; }

    }
}
