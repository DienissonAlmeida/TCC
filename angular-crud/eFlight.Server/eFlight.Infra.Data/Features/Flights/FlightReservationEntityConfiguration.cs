using eFlight.Domain.Features.Flights;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Infra.Data.Features.Flights
{
    public class FlightReservationEntityConfiguration : IEntityTypeConfiguration<FlightReservation>
    {
        public void Configure(EntityTypeBuilder<FlightReservation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.InputDate);
            builder.Property(x => x.OutputDate);
            builder.Property(x => x.Description);
        }
    }
}
