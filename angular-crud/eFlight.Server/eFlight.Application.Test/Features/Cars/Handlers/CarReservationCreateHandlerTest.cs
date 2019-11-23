using eFlight.Application.Features.Cars.Commands;
using eFlight.Application.Features.Hotels.Handlers;
using eFlight.Domain.Features.Cars;
using eFlight.Domain.Features.Flights;
using eFlight.Tests.Common.Features.Cars;
using FluentAssertions;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace eFlight.Application.Test.Features.Cars.Handlers
{
    public class CarReservationCreateHandlerTest : IClassFixture<BaseTest>
    {
        private CarReservationCreateHandler _handler;
        private Mock<ICarReservationRepository> _fakeRepository;

        public CarReservationCreateHandlerTest()
        {
            _fakeRepository = new Mock<ICarReservationRepository>();
            _handler = new CarReservationCreateHandler(_fakeRepository.Object);
        }

        [Fact]
        public async Task Deveria_criar_reserva_de_pacote_de_viagem_com_sucesso()
        {
            int expected = 1;
            List<CarReservation> reservations = new List<CarReservation>()
            {
                CarReservationBuilder.Start().Build(),
            };


            var cmd = CarReservationRegisterCommandBuilder.Start().Build();

            var result = await _handler.Handle(cmd, It.IsAny<CancellationToken>());

            result.Should().BeTrue();
            _fakeRepository.Verify(x => x.Add(It.IsAny<CarReservation>()), Times.Once);

        }
    }
}
