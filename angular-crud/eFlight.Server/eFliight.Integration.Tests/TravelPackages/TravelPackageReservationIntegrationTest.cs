//using eFlight.API;
//using eFlight.Application.Features.TravelPackages.Commands;
//using eFlight.Data.Context;
//using eFlight.Domain.Features.TravelPackages;
//using eFlight.Tests.Common.Features.TravelPackages;
//using FluentAssertions;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Text;
//using Xunit;

//namespace eFliight.Integration.Tests.TravelPackage
//{
//    [Collection("integration collection")]
//    public class TravelPackageReservationIntegrationTest : IClassFixture<CustomWebApplicationFactory<Startup>>
//    {
//        private readonly HttpClient _client;
//        private const string _url = "api/TravelPackageReservation";

//        public TravelPackageReservationIntegrationTest(CustomWebApplicationFactory<Startup> factory)
//        {
//            _client = factory.CreateClient();
//        }

//        [Fact]
//        public void GetTravelPackageReservations_IntegrationTest()
//        {
//            var httpResponse = _client.GetAsync(_url).Result;

//            httpResponse.EnsureSuccessStatusCode();

//            var stringResponse = httpResponse.Content.ReadAsStringAsync().Result;
//            var travelPackageReservations = JsonConvert.DeserializeObject<List<TravelPackageReservation>>(stringResponse);
//            var travelPackageReservation = travelPackageReservations.First();
//            travelPackageReservation.InputDate.Date.Should().Be(DateTime.Now.Date);
//            travelPackageReservation.OutputDate.Date.Should().Be(DateTime.Now.AddDays(10).Date);

//        }

//        [Fact]
//        public void GetTravelPackage_IntegrationTest()
//        {
//            var httpResponse = _client.GetAsync("api/TravelPackage").Result;

//            httpResponse.EnsureSuccessStatusCode();

//            var stringResponse = httpResponse.Content.ReadAsStringAsync().Result;
//            List<eFlight.Domain.Features.TravelPackages.TravelPackage> travelPackages = JsonConvert.DeserializeObject<List<eFlight.Domain.Features.TravelPackages.TravelPackage>>(stringResponse);
//            travelPackages.Count.Should().Be(2);
//            var travelPackage = travelPackages.First();
//            travelPackage.Name.Should().Be("Pacote Buenos Aires");
//        }

//        [Fact]
//        public void PostTravelPackageReservation_IntegrationTest()
//        {
//            arrange
//            var travelPackageCmd = TravelPackageReservationRegisterCommandBuilder.Start().Build();
//            var myContent = JsonConvert.SerializeObject(travelPackageCmd);
//            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

//            action
//            var httpResponse = _client.PostAsync(_url, stringContent).Result;

//            assert
//            httpResponse.EnsureSuccessStatusCode();

//            CustomWebApplicationFactory<Startup>.appDb.TravelPackageReservation.Count().Should().Be(2);
//        }

//        [Fact]
//        public void DeleteTravelPackageReservation_IntegrationTest()
//        {
//            arrange
//            var travelPackageReservation = TravelPackageReservationBuilder.Start().Build();

//            CustomWebApplicationFactory<Startup>.appDb.TravelPackageReservation.Add(travelPackageReservation);
//            CustomWebApplicationFactory<Startup>.appDb.SaveChanges();

//            var travelPackageCmd = new TravelPackageReservationDeleteCommand() { TravelPackageId = travelPackageReservation.Id };
//            var myContent = JsonConvert.SerializeObject(travelPackageCmd);
//            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

//            action
//            var httpResponse = eFlight.Tests.Common.Extensions.HttpClientExtensions.DeleteAsync(_client, _url, stringContent).Result;

//            httpResponse.EnsureSuccessStatusCode();

//            CustomWebApplicationFactory<Startup>.appDb.CarReservation.Count().Should().Be(1);
//        }

//        [Fact]
//        public void UpdateTravelPackageReservation_IntegrationTest()
//        {
//            var flightCmd = new TravelPackageReservationUpdateCommand()
//            {
//                Id = 1,
//                OutputDate = DateTime.Now.AddDays(20).Date,
//            };
//            var myContent = JsonConvert.SerializeObject(flightCmd);
//            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

//            var httpResponse = _client.PutAsync($"{_url}", stringContent).Result;

//            httpResponse.EnsureSuccessStatusCode();

//            var travelPackageReservationUpdated = CustomWebApplicationFactory<Startup>.appDb.TravelPackageReservation.Find(1);
//            travelPackageReservationUpdated.OutputDate.Date.Should().Be(DateTime.Now.AddDays(20).Date);
//        }
//    }
//}
