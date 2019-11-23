using eFlight.Domain.Features.Flights;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Application.Features.Hotels.Commands
{
    public class HotelReservationRegisterCommand : IRequest<bool>
    {
        public DateTime InputDate { get; set; }
        public DateTime OutputDate { get; set; }
        public string Description { get; set; }
        public IList<Customer> HotelCustomers { get; set; }
        public int HotelId { get; set; }

    }
}
