using eFlight.API.Controllers.Features.Flights;
using eFlight.Application.Features.Flights.Queries;
using eFlight.Domain.Features.Flights;
using eFlight.Tests.Common.Features.Flights;
using FluentAssertions;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace eFlight.Controller.Test.Features.Flights
{
    public class FlightControllerTest : BaseControllerTest
    {
        private FlightsController _controller;
        private Mock<IMediator> _fakeMediator;

        public FlightControllerTest()
        {
            _fakeMediator = new Mock<IMediator>();
            _controller = new FlightsController(_fakeMediator.Object);
        }

        [Fact]
        public async void Test_Flight_Controller_GetAsync_ShouldBeOk()
        {
            //arrange
            int expectedCount = 1;
            List<Flight> flights = new List<Flight>() { FlightBuilder.Start().Build() };

            _fakeMediator.Setup(mdtr => mdtr.Send(It.IsAny<FlightLoadAllQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(flights);

            //action
            var callback = await _controller.Get();

            //assert
            var response = callback.Should().BeOfType<List<Flight>>().Subject;
            response.Count.Should().Be(expectedCount);
        }
    }
}
