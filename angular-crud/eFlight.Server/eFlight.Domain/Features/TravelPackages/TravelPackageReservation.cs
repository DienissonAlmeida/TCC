using eFlight.Domain.Features.Flights;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Domain.Features.TravelPackages
{
    public class TravelPackageReservation : Reservation
    {
        public string Description { get; set; }
        public TravelPackage TravelPackage { get; set; }
        public int TravelPackageId { get; set; }
        public List<Customer> TravelPackageCustomers { get; set; }
    }
}
