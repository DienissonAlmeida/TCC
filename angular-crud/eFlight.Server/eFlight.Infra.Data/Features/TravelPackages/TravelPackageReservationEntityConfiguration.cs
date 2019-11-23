using eFlight.Domain.Features.Hotels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Infra.Data.Features.TravelPackages
{
    public class TravelPackageReservationEntityConfiguration : IEntityTypeConfiguration<HotelReservation>
    {
        public void Configure(EntityTypeBuilder<HotelReservation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.InputDate);
            builder.Property(x => x.OutputDate);
        }
    }
}
