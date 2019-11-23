using eFlight.Application.Features.Flights.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Application.Features.Hotels.Commands
{
    public class HotelReservationUpdateCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<CustomerUpdateCommand> HotelCustomers { get; set; }
        public int HotelId { get; set; }
        public DateTime InputDate { get; set; }
        public DateTime OutputDate { get; set; }

    }
}
