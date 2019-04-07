using System;
using System.Collections.Generic;
using System.Text;

namespace TestEstrategyTurism.Domain.Features.Users
{
    public class User : Entity
    {
        public string Name { get; set; }

        public string Cpf { get; set; }
    }
}
