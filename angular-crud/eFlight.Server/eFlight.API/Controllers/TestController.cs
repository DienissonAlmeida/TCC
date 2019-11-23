using eFlight.Application.Features.Flights.Commands;
using eFlight.Domain.Features.Flights;
using eFlight.Tests.Common.Features.Flights;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eFlight.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly HttpClient client;

        public TestController()
        {
            client = new HttpClient();
        }

        [HttpGet]
        [Route("post/{seat:int}")]
        public async Task<IActionResult> PostFlight(int seat)
        {
            var flightCmd = FlightReservationRegisterCommandBuilder.Start().Build();

            var myContent = JsonConvert.SerializeObject(flightCmd);
            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

            await client.PostAsync("https://localhost:44301/api/flights", stringContent);

            return Ok();
        }

        [HttpGet]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            var flightCmd = new FlightReservationDeleteCommand()
            {
                FlightReservationId = id

            };

            var myContent = JsonConvert.SerializeObject(flightCmd);
            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

            await Tests.Common.Extensions.HttpClientExtensions.DeleteAsync(client, "https://localhost:44301/api/flights", stringContent);

            return Ok();
        }

        [HttpGet]
        [Route("update/{id:int}")]
        public async Task<IActionResult> UpdateFlight(int id)
        {
            var flightCmd = new FlightReservationUpdateCommand()
            {
                Id = id,
                InputDate = DateTime.Now.AddDays(10),
                OutputDate = DateTime.Now.AddDays(10),
                FlightCustomers = new List<CustomerUpdateCommand>() { new CustomerUpdateCommand() { Name = "Roberto", LastName = "Bola", Sex = SexEnum.Male } }
            };

            var myContent = JsonConvert.SerializeObject(flightCmd);
            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

            await client.PutAsync($"https://localhost:44301/api/flights/{id}", stringContent);

            return Ok();
        }

    }

}
