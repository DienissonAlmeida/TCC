using eFlight.Infra.Extensions;
using System;

namespace eFlight.Controller.Test.Features.Flights
{
    public class SetupTest : IDisposable
    {
        public SetupTest()
        {
            if (this == null)
                this.ConfigureProfiles(typeof(API.Startup), typeof(Application.AppModule));
        }


        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }
    }
}