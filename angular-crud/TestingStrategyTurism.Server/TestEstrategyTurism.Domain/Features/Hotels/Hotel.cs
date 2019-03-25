using System;

namespace TestEstrategyTurism.Domain.Features.Hotels
{
    public class Hotel : Entity
    {
        public string City { get; set; }

        public string Name { get; set; }

        public int Stars { get; set; }
    }
}
