using eFlight.API.Controllers.Features.Cars;
using eFlight.Application.Features.Cars.Queries;
using eFlight.Domain.Features.Cars;
using eFlight.Tests.Common.Features.Cars;
using FluentAssertions;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace eFlight.Controller.Test.Features.Cars
{
    public class CarsControllerTest : BaseControllerTest
    {
        private CarsController _controller;
        private Mock<IMediator> _fakeMediator;

        public CarsControllerTest()
        {
            _fakeMediator = new Mock<IMediator>();
            _controller = new CarsController(_fakeMediator.Object);
        }

        [Fact]
        public async void Test_Flight_Controller_GetAsync_ShouldBeOk()
        {
            //arrange
            int expectedCount = 1;
            List<Car> cars = new List<Car>() { CarBuilder.Start().Build() };

            _fakeMediator.Setup(mdtr => mdtr.Send(It.IsAny<CarLoadAllQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(cars);

            //action
            var callback = await _controller.Get();

            //assert
            var response = callback.Should().BeOfType<List<Car>>().Subject;
            response.Count.Should().Be(expectedCount);
        }
    }
}
