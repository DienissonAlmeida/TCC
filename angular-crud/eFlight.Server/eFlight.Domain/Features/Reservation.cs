using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Domain.Features
{
    public abstract class Reservation : Entity
    {
        public DateTime InputDate { get; set; }

        public DateTime OutputDate { get; set; }
    }
}
