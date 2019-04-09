using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eFlight.Domain.Features.Reservations;

namespace eFlight.Domain.Features.Users
{
    public class User : Entity
    {
        public User()
        {

        }
        public string Name { get; set; }

        public string Cpf { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
