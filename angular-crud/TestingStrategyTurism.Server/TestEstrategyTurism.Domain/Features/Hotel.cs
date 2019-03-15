using System;

namespace TestEstrategyTurism.Domain
{
    public class Hotel : Entity
    {
        public string City { get; set; }

        public string Name { get; set; }

        public int Stars { get; set; }
    }
}
