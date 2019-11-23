using eFlight.API.Controllers.Features.Flights;
using eFlight.Data.Context;
using eFlight.Domain.Features.Flights;
using System;
using Xunit;
using System.Collections.Generic;
using eFlight.Application.Features.Flights;
using Moq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.OData;
using eFlight.Tests.Common.Features.Flights;
using MediatR;
using eFlight.Application.Features.Flights.Queries;
using System.Threading;
using eFlight.Application.Features.Flights.Commands;

namespace eFlight.Controller.Test.Features.Flights
{
    public class FlightReservationControllerTest : BaseControllerTest
    {
        private FlightReservationController _controller;
        private Mock<IMediator> _fakeMediator;

        public FlightReservationControllerTest()
        {
            _fakeMediator = new Mock<IMediator>();
            _controller = new FlightReservationController(_fakeMediator.Object);
        }

        [Fact]
        public async void Test_FlightController_PostAsync_ShouldBeOk()
        {
            var registerCommand = FlightReservationRegisterCommandBuilder.Start().Build();

            _fakeMediator.Setup(mdtr => mdtr.Send(registerCommand, It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var callback = await _controller.CreateReservation(registerCommand);

            var response = callback.Should().BeOfType<OkResult>().Subject;
        }

        [Fact]
       public async void Test_Flight_Controller_GetAsync_ShouldBeOk()
        {
            //arrange
            int expectedCount = 1;
            List<FlightReservation> flights = new List<FlightReservation>() { new FlightReservation() };

            _fakeMediator.Setup(mdtr => mdtr.Send(It.IsAny<FlightReservationLoadAllQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(flights);

            //action
            var callback = await _controller.Get();

            //assert
            var response = callback.Should().BeOfType<List<FlightReservation>>().Subject;
            response.Count.Should().Be(expectedCount);
        }


        [Fact]
        public async void Test_FlightController_PutAsync_ShouldBeOk()
        {
            var updateCommand = FlightReservationUpdateCommandBuilder.Start().WithId(1).Build();

            _fakeMediator.Setup(mdtr => mdtr.Send(updateCommand, It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var callback = await _controller.Update(updateCommand);


            var response = callback.Should().BeOfType<OkResult>().Subject;

        }

        [Fact]
        public async void Test_FlightController_DeleteAsync_ShouldBeOk()
        {
            var deleteCommand = new FlightReservationDeleteCommand() { FlightReservationId = 1 };

            _fakeMediator.Setup(mdtr => mdtr.Send(deleteCommand, It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var callback = await _controller.Delete(deleteCommand);


            var response = callback.Should().BeOfType<OkResult>().Subject;
        }
    }
}
