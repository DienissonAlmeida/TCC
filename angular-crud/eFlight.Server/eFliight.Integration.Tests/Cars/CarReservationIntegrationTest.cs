using eFlight.API;
using eFlight.Application.Features.Cars.Commands;
using eFlight.Data.Context;
using eFlight.Domain.Features.Cars;
using eFlight.Infra.Data.Features.Cars;
using eFlight.Tests.Common.Features.Cars;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Xunit;

namespace eFliight.Integration.Tests.Cars
{
    [Collection("integration collection")]
    public class CarReservationIntegrationTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private const string _url = "api/CarReservation";
        //private eFlightDbContext _context;

        public CarReservationIntegrationTest(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public void GetCarReservations_IntegrationTest()
        {
            var httpResponse = _client.GetAsync("api/CarReservation").Result;

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = httpResponse.Content.ReadAsStringAsync().Result;
            var carReservations = JsonConvert.DeserializeObject<List<CarReservation>>(stringResponse);
            var carReservation = carReservations.First();
            carReservation.InputDate.Date.Should().Be(DateTime.Now.Date);
            carReservation.OutputDate.Date.Should().Be(DateTime.Now.AddDays(10).Date);
            carReservation.Name.Should().Be("Reserva de carro");

        }

        [Fact]
        public void GetCars_IntegrationTest()
        {
            var httpResponse = _client.GetAsync("api/Cars").Result;

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = httpResponse.Content.ReadAsStringAsync().Result;
            var cars = JsonConvert.DeserializeObject<List<Car>>(stringResponse);
            cars.Count.Should().Be(1);
            var car = cars.First();
            car.Model.Should().Be("C4");
            car.Brand.Should().Be("Citroen");
            car.AirConditioning.Should().Be(true);
            car.Transmission.Should().Be(Transmission.Manual);

        }

        [Fact]
        public void PostCarReservation_IntegrationTest()
        {
            //arrange
            var carCmd = CarReservationRegisterCommandBuilder.Start().Build();
            var myContent = JsonConvert.SerializeObject(carCmd);
            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

            //action
            var httpResponse = _client.PostAsync(_url, stringContent).Result;

            //assert
            httpResponse.EnsureSuccessStatusCode();

            CustomWebApplicationFactory<Startup>.appDb.CarReservation.Count().Should().Be(2);
        }

        [Fact]
        public void DeleteCarReservation_IntegrationTest()
        {
            //arrange
            var carReservation = CarReservationBuilder.Start().WithInputDate(DateTime.Now.AddDays(11))
                .WithOutputDate(DateTime.Now.AddDays(20)).Build();
            CustomWebApplicationFactory<Startup>.appDb.CarReservation.Add(carReservation);
            CustomWebApplicationFactory<Startup>.appDb.SaveChanges();

            var flightCmd = new CarReservationDeleteCommand() { CarReservationId = carReservation.Id };
            var myContent = JsonConvert.SerializeObject(flightCmd);
            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

            //action
            var httpResponse = eFlight.Tests.Common.Extensions.HttpClientExtensions.DeleteAsync(_client, _url, stringContent).Result;

            httpResponse.EnsureSuccessStatusCode();

            CustomWebApplicationFactory<Startup>.appDb.CarReservation.Count().Should().Be(1);
        }

        [Fact]
        public void UpdateCarReservation_IntegrationTest()
        {
            var flightCmd = new CarReservationUpdateCommand()
            {
                Id = 1,
                OutputDate = DateTime.Now.AddDays(20).Date,
                Name = "Teste atualização"
            };
            var myContent = JsonConvert.SerializeObject(flightCmd);
            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

            var httpResponse = _client.PutAsync($"{_url}", stringContent).Result;

            httpResponse.EnsureSuccessStatusCode();

            var carReservationUpdated = CustomWebApplicationFactory<Startup>.appDb.CarReservation.Find(1);
            //carReservationUpdated.OutputDate.Date.Should().Be(DateTime.Now.AddDays(20).Date);
            //carReservationUpdated.Name.Should().Be("Teste atualização");
        }
    }
}
