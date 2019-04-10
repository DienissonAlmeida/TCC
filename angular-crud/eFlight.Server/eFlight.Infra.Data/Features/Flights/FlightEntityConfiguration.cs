using eFlight.Domain.Features.Flights;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Infra.Data.Features.Flights
{
    public class FlightEntityConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(p => p.Origin);
            builder.Property(p => p.Destination);
            builder.Property(p => p.Out);
            builder.Property(p => p.Return);
        }
    }
}
