using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using eFlight.Domain.Features.Hotels;

namespace eFlight.Data.Features.Hotels
{
    public class HotelEntityConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(p => p.City).HasMaxLength(50);
            builder.Property(p => p.Name).HasMaxLength(50);
            builder.Property(p => p.Stars).HasMaxLength(10);

            //builder.HasMany(b => b.Reservations).WithOne(x => x.Hotel).HasForeignKey(x => x.HotelId);
        }
    }
}
