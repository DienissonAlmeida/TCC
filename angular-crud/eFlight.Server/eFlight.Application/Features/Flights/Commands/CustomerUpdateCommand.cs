using eFlight.Domain.Features.Flights;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Application.Features.Flights.Commands
{
    /// <summary>
    ///
    /// Representa o comando (dados necessário) para registrar um novo Passenger.
    ///
    /// </summary>
    public class CustomerUpdateCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public SexEnum Sex { get; set; }
    }
}
