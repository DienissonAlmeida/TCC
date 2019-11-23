using eFlight.Infra.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Application.Test.Features
{
    public class BaseTest
    {
        public BaseTest()
        {
            if (this == null)
                this.ConfigureProfiles(typeof(Application.AppModule));
        }
    }
}
