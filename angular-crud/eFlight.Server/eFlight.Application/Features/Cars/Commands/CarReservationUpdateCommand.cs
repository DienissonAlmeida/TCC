using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Application.Features.Cars.Commands
{
    public class CarReservationUpdateCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DateTime InputDate { get; set; }

        public DateTime OutputDate { get; set; }

        public string Name { get; set; }
    }
}
