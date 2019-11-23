using eFlight.Domain.Features.TravelPackages;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Tests.Common.Features.TravelPackages
{
    public class TravelPackageBuilder
    {
        private static TravelPackage _traavelPackage;

        public static TravelPackageBuilder Start()
        {
            _traavelPackage = new TravelPackage()
            {
                Name = "Pacote Buenos Aires"
            };

            return new TravelPackageBuilder();
        }

        public TravelPackage Build() => _traavelPackage;
    }
}
