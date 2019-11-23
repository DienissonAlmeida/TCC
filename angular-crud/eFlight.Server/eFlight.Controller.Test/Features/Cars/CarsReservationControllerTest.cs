using eCar.API.Controllers.Features.Cars;
using eFlight.Application.Features.Cars.Commands;
using eFlight.Application.Features.Cars.Queries;
using eFlight.Domain.Features.Cars;
using eFlight.Tests.Common.Features.Cars;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace eFlight.Controller.Test.Features.Cars
{
    public class CarsReservationControllerTest : BaseControllerTest
    {
        private CarReservationController _controller;
        private Mock<IMediator> _fakeMediator;

        public CarsReservationControllerTest()
        {
            _fakeMediator = new Mock<IMediator>();
            _controller = new CarReservationController(_fakeMediator.Object);
        }

        [Fact]
        public async void Test_Car_Controller_GetAsync_ShouldBeOk()
        {
            //arrange
            int expectedCount = 1;
            List<CarReservation> flights = new List<CarReservation>() { new CarReservation() };

            _fakeMediator.Setup(mdtr => mdtr.Send(It.IsAny<CarReservationLoadAllQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(flights);

            //action
            var callback = await _controller.Get();

            //assert
            var response = callback.Should().BeOfType<List<CarReservation>>().Subject;
            response.Count.Should().Be(expectedCount);
        }

        [Fact]
        public async void Test_CarController_PostAsync_ShouldBeOk()
        {
            var registerCommand = CarReservationRegisterCommandBuilder.Start().Build();

            _fakeMediator.Setup(mdtr => mdtr.Send(registerCommand, It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var callback = await _controller.CreateReservation(registerCommand);

            var response = callback.Should().BeOfType<OkResult>().Subject;
        }

        [Fact]
        public async void Test_CarController_PutAsync_ShouldBeOk()
        {
            var updateCommand = CarReservationUpdateCommandBuilder.Start().WithId(1).Build();

            _fakeMediator.Setup(mdtr => mdtr.Send(updateCommand, It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var callback =  await _controller.Update(updateCommand);

            var response = callback.Should().BeOfType<OkResult>().Subject;

        }

        [Fact]
        public async void Test_FlightController_DeleteAsync_ShouldBeOk()
        {
            var deleteCommand = new CarReservationDeleteCommand() { CarReservationId = 1 };

            _fakeMediator.Setup(mdtr => mdtr.Send(deleteCommand, It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var callback = await _controller.Delete(deleteCommand);


            var response = callback.Should().BeOfType<OkResult>().Subject;
        }
    }
}
