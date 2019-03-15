using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestEstrategyTurism.Data.Features.Hotels;
using TestEstrategyTurism.Domain;

namespace TestEstrategyTurism.Data.Context
{
    public class TestingEstrategyTurismDbContext : DbContext
    {
        public TestingEstrategyTurismDbContext(DbContextOptions<TestingEstrategyTurismDbContext> options) : base(options)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HotelEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
