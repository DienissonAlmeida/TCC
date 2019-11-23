using eFlight.API.Controllers.Features.TravelPackages;
using eFlight.Application.Features.TravelPackages.Queries;
using eFlight.Domain.Features.TravelPackages;
using eFlight.Tests.Common.Features.TravelPackages;
using FluentAssertions;
using MediatR;
using Moq;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace eFlight.Controller.Test.Features.TravelPackages
{
    public class TravelPackagesControllerTest : BaseControllerTest
    {
        private TravelPackageController _controller;
        private Mock<IMediator> _fakeMediator;

        public TravelPackagesControllerTest()
        {
            _fakeMediator = new Mock<IMediator>();
            _controller = new TravelPackageController(_fakeMediator.Object);
        }

        [Fact]
        public async void Test_Flight_Controller_GetAsync_ShouldBeOk()
        {
            //arrange
            int expectedCount = 1;
            List<TravelPackage> hotels = new List<TravelPackage>() { TravelPackageBuilder.Start().Build() };

            _fakeMediator.Setup(mdtr => mdtr.Send(It.IsAny<TravelPackageLoadAllQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(hotels);

            //action
            var callback = await _controller.Get();

            //assert
            var response = callback.Should().BeOfType<List<TravelPackage>>().Subject;
            response.Count.Should().Be(expectedCount);
        }
    }
}
