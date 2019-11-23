using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using eFlight.Domain.Features.TravelPackages;

namespace eFlight.Infra.Data.Features.TravelPackages
{
    public class TravelPackageEntityConfiguration : IEntityTypeConfiguration<TravelPackage>
    {
        public void Configure(EntityTypeBuilder<TravelPackage> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
        }
    }
}
