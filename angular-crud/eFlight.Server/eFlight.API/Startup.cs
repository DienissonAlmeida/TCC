using AutoMapper;
using eFlight.API.Extensions;
using eFlight.Application.Features.Cars.Commands;
using eFlight.Application.Features.Flights.Commands;
using eFlight.Application.Features.Hotels.Commands;
using eFlight.Application.Features.TravelPackages.Commands;
using eFlight.Data.Context;
using eFlight.Domain;
using eFlight.Domain.Features.Cars;
using eFlight.Domain.Features.Flights;
using eFlight.Domain.Features.Hotels;
using eFlight.Domain.Features.TravelPackages;
using eFlight.Infra.Data.Features;
using eFlight.Infra.Data.Features.Cars;
using eFlight.Infra.Data.Features.Flights;
using eFlight.Infra.Data.Features.Hotels;
using eFlight.Infra.Data.Features.TravelPackages;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Reflection;

namespace eFlight.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<eFlightDbContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("eFlightDbContext"),
                    b => b.MigrationsAssembly("eFlight.API"));
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).
                AddJsonOptions(
                options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.Formatting = Formatting.Indented;
                });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(FlightReservationRegisterCommand).GetTypeInfo().Assembly);

            AddScoped(services);

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FlightReservationRegisterCommand, FlightReservation>();
                cfg.CreateMap<FlightReservationUpdateCommand, FlightReservation>();

                cfg.CreateMap<CarReservationRegisterCommand, CarReservation>();
                cfg.CreateMap<CarReservationUpdateCommand, CarReservation>();

                cfg.CreateMap<HotelReservationRegisterCommand, HotelReservation>();
                cfg.CreateMap<HotelReservationUpdateCommand, HotelReservation>();

                cfg.CreateMap<TravelPackageReservationRegisterCommand, TravelPackageReservation>();
                cfg.CreateMap<TravelPackageReservationUpdateCommand, TravelPackageReservation>();


            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            //services.AddAutoMapper();

        }

        private static void AddScoped(IServiceCollection services)
        {
            services.AddScoped<IFlightReservationRepository, FlightReservationRepository>();
            services.AddScoped<IRepositoryBase<Flight>, RepositoryBase<Flight>>();

            services.AddScoped<IHotelReservationRepository, HotelReservationRepository>();
            services.AddScoped<IRepositoryBase<Hotel>, RepositoryBase<Hotel>>();

            services.AddScoped<ICarReservationRepository, CarReservationRepository>();
            services.AddScoped<IRepositoryBase<Car>, RepositoryBase<Car>>();

            services.AddScoped<ITravelPackageReservationRepository, TravelPackageReservationRepository>();
            services.AddScoped<IRepositoryBase<TravelPackage>, RepositoryBase<TravelPackage>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseMvc();

        }
    }
}
