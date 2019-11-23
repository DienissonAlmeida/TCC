using eFlight.Domain.Features.Flights;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Application.Features.TravelPackages.Commands
{
    public class TravelPackageReservationRegisterCommand : IRequest<bool>
    {
        public string Description { get; set; }
        public int TravelPackageId { get; set; }
        public List<Customer> TravelPackageCustomers { get; set; }
        public DateTime InputDate { get; set; }
        public DateTime OutputDate { get; set; }
    }
}
