//using eFlight.API.Controllers.Features.TravelPackage;
//using eFlight.Application.Features.TravelPackages.Commands;
//using eFlight.Application.Features.TravelPackages.Queries;
//using eFlight.Domain.Features.TravelPackages;
//using eFlight.Tests.Common.Features.TravelPackages;
//using FluentAssertions;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading;
//using Xunit;

//namespace eFlight.Controller.Test.Features.TravelPackages
//{
//    public class TravelPackageReservationControllerTest : BaseControllerTest
//    {
//        private TravelPackageReservationController _controller;
//        private Mock<IMediator> _fakeMediator;

//        public TravelPackageReservationControllerTest()
//        {
//            _fakeMediator = new Mock<IMediator>();
//            _controller = new TravelPackageReservationController(_fakeMediator.Object);
//        }

//        [Fact]
//        public async void Test_Flight_Controller_GetAsync_ShouldBeOk()
//        {
//            //arrange
//            int expectedCount = 1;
//            List<TravelPackageReservation> flights = new List<TravelPackageReservation>() { new TravelPackageReservation() };

//            _fakeMediator.Setup(mdtr => mdtr.Send(It.IsAny<TravelPackageReservationLoadAllQuery>(), It.IsAny<CancellationToken>()))
//                .ReturnsAsync(flights);

//            //action
//            var callback = await _controller.Get();

//            //assert
//            var response = callback.Should().BeOfType<List<TravelPackageReservation>>().Subject;
//            response.Count.Should().Be(expectedCount);
//        }

//        [Fact]
//        public async void Test_FlightController_PostAsync_ShouldBeOk()
//        {
//            var registerCommand = TravelPackageReservationRegisterCommandBuilder.Start().Build();

//            _fakeMediator.Setup(mdtr => mdtr.Send(registerCommand, It.IsAny<CancellationToken>()))
//                .ReturnsAsync(true);

//            var callback = await _controller.CreateReservation(registerCommand);

//            var response = callback.Should().BeOfType<OkResult>().Subject;
//        }

//        [Fact]
//        public async void Test_FlightController_PutAsync_ShouldBeOk()
//        {
//            var updateCommand = TravelPackageReservationUpdateCommandBuilder.Start().WithId(1).Build();

//            _fakeMediator.Setup(mdtr => mdtr.Send(updateCommand, It.IsAny<CancellationToken>()))
//                .ReturnsAsync(true);

//            var callback = await _controller.Update(updateCommand);


//            var response = callback.Should().BeOfType<OkResult>().Subject;

//        }

//        [Fact]
//        public async void Test_FlightController_DeleteAsync_ShouldBeOk()
//        {
//            var deleteCommand = new TravelPackageReservationDeleteCommand() { TravelPackageId = 1 };

//            _fakeMediator.Setup(mdtr => mdtr.Send(deleteCommand, It.IsAny<CancellationToken>()))
//                .ReturnsAsync(true);

//            var callback = await _controller.Delete(deleteCommand);


//            var response = callback.Should().BeOfType<OkResult>().Subject;
//        }
//    }
//}
