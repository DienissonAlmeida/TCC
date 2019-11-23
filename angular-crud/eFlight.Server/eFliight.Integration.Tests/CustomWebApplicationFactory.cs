using eFlight.API;
using eFlight.Data.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using eFlight.Domain.Features.Cars;
using Xunit;
using System.Linq;

namespace eFliight.Integration.Tests
{
    [CollectionDefinition("integration collection")]
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<Startup>, IDisposable
    {
        public static eFlightDbContext appDb;
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {

            builder.ConfigureServices(services =>
            {
                // Create a new service provider.
                var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

                // Add a database context (AppDbContext) using an in-memory database for testing.
                services.AddDbContext<eFlightDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryAppDb");
                options.UseInternalServiceProvider(serviceProvider);
            });

                // Build the service provider.
                var sp = services.BuildServiceProvider();

                // Create a scope to obtain a reference to the database contexts
                //using (var scope = sp.CreateScope())
                //{
                var scope = sp.CreateScope();
                var scopedServices = scope.ServiceProvider;
                appDb = scopedServices.GetRequiredService<eFlightDbContext>();

                var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                // Ensure the database is created.
                appDb.Database.EnsureCreated();

                try
                {
                    if (!appDb.HotelReservation.Any())
                        SeedData.PopulateTestData(appDb);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred seeding the " +
                                        "database with test messages. Error: {ex.Message}");
                }
                //}
            });

        }

        protected override void Dispose(bool disposing)
        {
            if (appDb != null)
            {
                appDb.Dispose();
                base.Dispose(disposing);
            }

        }
    }

    [CollectionDefinition("integration collection")]
    public class DatabaseCollection : ICollectionFixture<CustomWebApplicationFactory<Startup>>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
