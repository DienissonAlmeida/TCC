using eFlight.Domain.Features.Cars;
using eFlight.Domain.Features.Flights;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Application.Features.Cars.Commands
{
    public class CarReservationRegisterCommand : IRequest<bool>
    {
        public string Description { get; set; }

        public Car Car { get; set; }

        public int CarId { get; set; }

        public List<Customer> CarCustomers { get; set; }

        public DateTime InputDate { get; set; }

        public DateTime OutputDate { get; set; }
    }
}
