using eFlight.Application.Features.Cars.Handlers;
using eFlight.Application.Features.Cars.Queries;
using eFlight.Domain.Features.Cars;
using eFlight.Tests.Common.Features.Cars;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace eFlight.Application.Test.Features.Cars.Handlers
{
    public class CarReservationLoadAllHandlerTest : IClassFixture<BaseTest>
    {
        private CarReservationLoadlAllHandler _handler;
        private Mock<ICarReservationRepository> _fakeRepository;

        public CarReservationLoadAllHandlerTest()
        {
            _fakeRepository = new Mock<ICarReservationRepository>();
            _handler = new CarReservationLoadlAllHandler(_fakeRepository.Object);
        }

        [Fact]
        public async Task Deveria_recuperar_reserva_de_carro_com_sucesso()
        {
            int expected = 1;
            List<CarReservation> reservations = new List<CarReservation>()
            {
                CarReservationBuilder.Start().Build(),
                CarReservationBuilder.Start().Build()
            };

            _fakeRepository.Setup(x => x.GetAll()).ReturnsAsync(reservations);

            var cmd = new CarReservationLoadAllQuery();

            var result = await _handler.Handle(cmd, It.IsAny<CancellationToken>());

            result.Should().BeOfType<List<CarReservation>>();
            result.Should().HaveCount(2);
            _fakeRepository.Verify(x => x.GetAll(), Times.Once);

            //TODO: Verificar registro atualizado.

        }
    }
}
