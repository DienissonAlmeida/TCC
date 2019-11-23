using eFlight.Domain.Features.Flights;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Infra.Data.Features
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.FlightReservationId).IsRequired(false);
            builder.Property(p => p.CarReservationId).IsRequired(false);
            builder.Property(p => p.HotelReservationId).IsRequired(false);
            builder.Property(p => p.TravelPackageReservationId).IsRequired(false);
        }
    }
}
