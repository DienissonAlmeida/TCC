using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestEstrategyTurism.Domain.Features.Reservations;

namespace TestEstrategyTurism.Domain.Features.Users
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
