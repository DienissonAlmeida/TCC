using eFlight.API.Controllers;
using eFlight.Application.Features.Hotels.Queries;
using eFlight.Domain.Features.Hotels;
using eFlight.Tests.Common.Features.Hotels;
using FluentAssertions;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace eFlight.Controller.Test.Features.Hotels
{
    public class HotelControllerTest : BaseControllerTest
    {
        private HotelsController _controller;
        private Mock<IMediator> _fakeMediator;

        public HotelControllerTest()
        {
            _fakeMediator = new Mock<IMediator>();
            _controller = new HotelsController(_fakeMediator.Object);
        }

        [Fact]
        public async void Test_Flight_Controller_GetAsync_ShouldBeOk()
        {
            //arrange
            int expectedCount = 1;
            List<Hotel> hotels = new List<Hotel>() { HotelBuilder.Start().Build() };

            _fakeMediator.Setup(mdtr => mdtr.Send(It.IsAny<HotelLoadAllQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(hotels);

            //action
            var callback = await _controller.Get();

            //assert
            var response = callback.Should().BeOfType<List<Hotel>>().Subject;
            response.Count.Should().Be(expectedCount);
        }
    }
}
