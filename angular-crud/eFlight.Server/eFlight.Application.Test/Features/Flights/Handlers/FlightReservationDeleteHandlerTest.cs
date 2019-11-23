using eFlight.Application.Features.Flights.Commands;
using eFlight.Application.Features.Flights.Handlers;
using eFlight.Domain.Features.Flights;
using eFlight.Tests.Common.Features.Flights;
using FluentAssertions;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace eFlight.Application.Test.Features.Flights.Handlers
{
    public class FlightReservationDeleteHandlerTest : IClassFixture<BaseTest>
    {
        private FlightReservationDeleteHandler _handler;
        private Mock<IFlightReservationRepository> _fakeRepository;

        public FlightReservationDeleteHandlerTest()
        {
            _fakeRepository = new Mock<IFlightReservationRepository>();
            _handler = new FlightReservationDeleteHandler(_fakeRepository.Object);
        }

        [Fact]
        public async Task Deveria_excluir_reserva_de_voo_com_sucesso()
        {
            int expected = 1;

            FlightReservation reservation = FlightReservationBuilder.Start()
                .WithInputDate(DateTime.Now.AddDays(11))
                .Build();

            _fakeRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(reservation);

            var cmd = new FlightReservationDeleteCommand() { FlightReservationId = 1 };

            var result = await _handler.Handle(cmd, It.IsAny<CancellationToken>());

            result.Should().BeTrue();
            _fakeRepository.Verify(x => x.GetById(cmd.FlightReservationId), Times.Once);
            _fakeRepository.Verify(x => x.DeleteById(cmd.FlightReservationId), Times.Once);

        }
    }
}
