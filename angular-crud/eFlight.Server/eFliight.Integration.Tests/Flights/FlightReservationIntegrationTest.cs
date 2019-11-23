using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using eFlight.API;
using eFlight.Application.Features.Flights.Commands;
using eFlight.Data.Context;
using eFlight.Domain.Features.Flights;
using eFlight.Tests.Common.Features.Flights;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace eFliight.Integration.Tests.Flights
{
    [Collection("integration collection")]
    public class FlightReservationIntegrationTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private const string _url = "api/FlightReservation";

        public FlightReservationIntegrationTest(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public void PostFlightReservation_IntegrationTest()
        {
            //arrange
            var flightCmd = FlightReservationRegisterCommandBuilder.Start().Build();
            var myContent = JsonConvert.SerializeObject(flightCmd);
            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

            //action
            var httpResponse = _client.PostAsync(_url, stringContent).Result;

            //assert
            httpResponse.EnsureSuccessStatusCode();

            CustomWebApplicationFactory<Startup>.appDb.FlightReservation.Count().Should().Be(2);
        }

        [Fact]
        public void GetFlights_IntegrationTest()
        {
            var httpResponse = _client.GetAsync("api/Flights").Result;

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = httpResponse.Content.ReadAsStringAsync().Result;
            var flights = JsonConvert.DeserializeObject<List<Flight>>(stringResponse);
            flights.Count.Should().Be(1);
            var flight = flights.First();
            flight.Origin.Should().Be("Lages");
            flight.Destination.Should().Be("Campinas");

        }

        [Fact]
        public void GetFlightReservations_IntegrationTest()
        {
            var httpResponse = _client.GetAsync(_url).Result;

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = httpResponse.Content.ReadAsStringAsync().Result;
            var flightReservations = JsonConvert.DeserializeObject<List<FlightReservation>>(stringResponse);
            var flightReservation = flightReservations.First();
            flightReservation.InputDate.Date.Should().Be(DateTime.Now.Date);
            flightReservation.OutputDate.Date.Should().Be(DateTime.Now.AddDays(10).Date);

        }
        [Fact]
        public void DeleteFlightReservation_IntegrationTest()
        {
            //arrange
            var flightReservation = FlightReservationBuilder.Start().WithInputDate(DateTime.Now.AddDays(11))
                .WithOutputDate(DateTime.Now.AddDays(20)).Build();
            CustomWebApplicationFactory<Startup>.appDb.FlightReservation.Add(flightReservation);
            CustomWebApplicationFactory<Startup>.appDb.SaveChanges();

            var flightCmd = new FlightReservationDeleteCommand() { FlightReservationId = flightReservation.Id };
            var myContent = JsonConvert.SerializeObject(flightCmd);
            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

            //action
            var httpResponse = eFlight.Tests.Common.Extensions.HttpClientExtensions.DeleteAsync(_client, _url, stringContent).Result;

            httpResponse.EnsureSuccessStatusCode();

            CustomWebApplicationFactory<Startup>.appDb.FlightReservation.Count().Should().Be(1);
        }

        [Fact]
        public void UpdateFlightReservation_IntegrationTest()
        {
            var flightCmd = new FlightReservationUpdateCommand()
            {
                Id = 1,
                OutputDate = DateTime.Now.AddDays(20).Date,
            };
            var myContent = JsonConvert.SerializeObject(flightCmd);
            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

            var httpResponse = _client.PutAsync($"{_url}", stringContent).Result;

            httpResponse.EnsureSuccessStatusCode();

            CustomWebApplicationFactory<Startup>.appDb.FlightReservation.Find(1);
        }

    }
}
