using eFlight.Application.Features.Cars.Commands;
using eFlight.Application.Features.Cars.Handlers;
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
    public class CarReservationDeleteHandlerTest : IClassFixture<BaseTest>
    {
        private CarReservationDeleteHandler _handler;
        private Mock<ICarReservationRepository> _fakeRepository;

        public CarReservationDeleteHandlerTest()
        {
            _fakeRepository = new Mock<ICarReservationRepository>();
            _handler = new CarReservationDeleteHandler(_fakeRepository.Object);
        }

        [Fact]
        public void Deveria_excluir_reserva_de_carro_com_sucesso()
        {
            int expected = 1;

            CarReservation reservation = CarReservationBuilder.Start()
                .WithInputDate(DateTime.Now.AddDays(11))
                .Build();

            _fakeRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(reservation);

            var cmd = new CarReservationDeleteCommand() { CarReservationId = 1 };

            var result = _handler.Handle(cmd, It.IsAny<CancellationToken>());

            result.Result.Should().BeTrue();
            _fakeRepository.Verify(x => x.GetById(cmd.CarReservationId), Times.Once);
            _fakeRepository.Verify(x => x.DeleteById(cmd.CarReservationId), Times.Once);

        }
    }
}
