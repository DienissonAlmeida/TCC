using AutoMapper;
using eFlight.Application.Features.Cars.Commands;
using eFlight.Application.Features.Flights.Commands;
using eFlight.Application.Features.Hotels.Commands;
using eFlight.Application.Features.TravelPackages.Commands;
using eFlight.Domain.Features.Cars;
using eFlight.Domain.Features.Flights;
using eFlight.Domain.Features.Hotels;
using eFlight.Domain.Features.TravelPackages;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Application.Features.Flights
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FlightReservationRegisterCommand, FlightReservation>();
            CreateMap<FlightReservationUpdateCommand, FlightReservation>();
            CreateMap<CustomerUpdateCommand, Customer>();

            CreateMap<CarReservationRegisterCommand, CarReservation>();
            CreateMap<CarReservationUpdateCommand, CarReservation>();

            CreateMap<HotelReservationRegisterCommand, HotelReservation>();
            CreateMap<HotelReservationUpdateCommand, HotelReservation>();

            CreateMap<TravelPackageReservationRegisterCommand, TravelPackageReservation>();
            CreateMap<TravelPackageReservationUpdateCommand, TravelPackageReservation>();


        }
    }
}
