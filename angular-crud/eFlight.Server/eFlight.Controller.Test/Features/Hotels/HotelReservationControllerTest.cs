using eFlight.API.Controllers.Features.Hotels;
using eFlight.Application.Features.Hotels.Commands;
using eFlight.Application.Features.Hotels.Queries;
using eFlight.Domain.Features.Hotels;
using eFlight.Tests.Common.Features.Hotels;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace eFlight.Controller.Test.Features.Hotels
{
    public class HotelReservationControllerTest : BaseControllerTest
    {
        private HotelReservationController _controller;
        private Mock<IMediator> _fakeMediator;

        public HotelReservationControllerTest()
        {
            _fakeMediator = new Mock<IMediator>();
            _controller = new HotelReservationController(_fakeMediator.Object);
        }

        [Fact]
        public async void Test_Flight_Controller_GetAsync_ShouldBeOk()
        {
            //arrange
            int expectedCount = 1;
            List<HotelReservation> flights = new List<HotelReservation>() { new HotelReservation() };

            _fakeMediator.Setup(mdtr => mdtr.Send(It.IsAny<HotelReservationLoadAllQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(flights);

            //action
            var callback = await _controller.Get();

            //assert
            var response = callback.Should().BeOfType<List<HotelReservation>>().Subject;
            response.Count.Should().Be(expectedCount);
        }

        [Fact]
        public async void Test_FlightController_PostAsync_ShouldBeOk()
        {
            var registerCommand = HotelReservationRegisterCommandBuilder.Start().Build();

            _fakeMediator.Setup(mdtr => mdtr.Send(registerCommand, It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var callback = await _controller.CreateReservation(registerCommand);

            var response = callback.Should().BeOfType<OkResult>().Subject;
        }

        [Fact]
        public async void Test_FlightController_PutAsync_ShouldBeOk()
        {
            var updateCommand = HotelReservationUpdateCommandBuilder.Start().WithId(1).Build();

            _fakeMediator.Setup(mdtr => mdtr.Send(updateCommand, It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var callback = await _controller.Update(updateCommand);


            var response = callback.Should().BeOfType<OkResult>().Subject;

        }

        [Fact]
        public async void Test_FlightController_DeleteAsync_ShouldBeOk()
        {
            var deleteCommand = new HotelReservationDeleteCommand() { HotelReservationId = 1 };

            _fakeMediator.Setup(mdtr => mdtr.Send(deleteCommand, It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var callback = await _controller.Delete(deleteCommand);


            var response = callback.Should().BeOfType<OkResult>().Subject;
        }
    }
}
