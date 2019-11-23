using eFlight.API;
using eFlight.Application.Features.Hotels.Commands;
using eFlight.Data.Context;
using eFlight.Domain.Features.Hotels;
using eFlight.Tests.Common.Features.Hotels;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Xunit;

namespace eFliight.Integration.Tests.Hotels
{
    [Collection("integration collection")]
    public class HotelReservationIntegrationTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private const string _url = "api/HotelReservation";

        public HotelReservationIntegrationTest(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public void GetHotelReservations_IntegrationTest()
        {
            var httpResponse = _client.GetAsync("api/HotelReservation").Result;

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = httpResponse.Content.ReadAsStringAsync().Result;
            var hotelReservations = JsonConvert.DeserializeObject<List<HotelReservation>>(stringResponse);
            var hotelReservation = hotelReservations.First();
            hotelReservation.InputDate.Date.Should().Be(DateTime.Now.Date);
            hotelReservation.OutputDate.Date.Should().Be(DateTime.Now.AddDays(10).Date);

        }

        [Fact]
        public void GetHotel_IntegrationTest()
        {
            var httpResponse = _client.GetAsync("api/Hotels").Result;

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = httpResponse.Content.ReadAsStringAsync().Result;
            var hotels = JsonConvert.DeserializeObject<List<Hotel>>(stringResponse);
            //hotels.Count.Should().Be(1);
            var hotel = hotels.First();
            hotel.City.Should().Be("Paris");
            hotel.Daily.Should().Be(500.00);
            hotel.Name.Should().Be("Hôtel Paris Lagayette");
            hotel.Stars.Should().Be(4);

        }

        [Fact]
        public void PostHotelReservation_IntegrationTest()
        {
            //arrange
            var carCmd = HotelReservationRegisterCommandBuilder.Start().Build();
            var myContent = JsonConvert.SerializeObject(carCmd);
            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

            //action
            var httpResponse = _client.PostAsync(_url, stringContent).Result;

            //assert
            httpResponse.EnsureSuccessStatusCode();

            CustomWebApplicationFactory<Startup>.appDb.HotelReservation.Count().Should().Be(2);
        }

        [Fact]
        public void DeleteFlightReservation_IntegrationTest()
        {
            //arrange
            var hotelReservation = HotelReservationBuilder.Start().Build();
            CustomWebApplicationFactory<Startup>.appDb.HotelReservation.Add(hotelReservation);
            CustomWebApplicationFactory<Startup>.appDb.SaveChanges();

            var flightCmd = new HotelReservationDeleteCommand() { HotelReservationId = hotelReservation.Id };
            var myContent = JsonConvert.SerializeObject(flightCmd);
            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

            //action
            var httpResponse = eFlight.Tests.Common.Extensions.HttpClientExtensions.DeleteAsync(_client, _url, stringContent).Result;

            httpResponse.EnsureSuccessStatusCode();

            CustomWebApplicationFactory<Startup>.appDb.FlightReservation.Count().Should().Be(1);
        }

        [Fact]
        public void UpdateHotelReservation_IntegrationTest()
        {
            var hotelReservationCmd = new HotelReservationUpdateCommand()
            {
                Id = 1,
                OutputDate = DateTime.Now.AddDays(20).Date,
                Description = "Teste atualização"
            };
            var myContent = JsonConvert.SerializeObject(hotelReservationCmd);
            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

            var httpResponse = _client.PutAsync($"{_url}", stringContent).Result;

            httpResponse.EnsureSuccessStatusCode();

            var carReservationUpdated = CustomWebApplicationFactory<Startup>.appDb.HotelReservation.Find(1);
            //carReservationUpdated.OutputDate.Date.Should().Be(DateTime.Now.AddDays(20).Date);
            //carReservationUpdated.Description.Should().Be("Teste atualização");
        }
    }
}
