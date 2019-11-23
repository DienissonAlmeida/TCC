using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Domain
{
    public abstract class Entity
    {
        public virtual int Id { get; set; }

        public void SetId()
        {
            Random random = new Random();
            Id = random.Next();
        }
    }
}
