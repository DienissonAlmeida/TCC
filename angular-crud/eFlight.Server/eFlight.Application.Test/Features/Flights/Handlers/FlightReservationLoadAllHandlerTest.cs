using eFlight.Application.Features.Flights.Handlers;
using eFlight.Application.Features.Flights.Queries;
using eFlight.Domain.Features.Flights;
using eFlight.Tests.Common.Features.Flights;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace eFlight.Application.Test.Features.Flights.Handlers
{
    public class FlightReservationLoadAllHandlerTest : IClassFixture<BaseTest>
    {
        private FlightReservationLoadAllHandler _handler;
        private Mock<IFlightReservationRepository> _fakeRepository;

        public FlightReservationLoadAllHandlerTest()
        {
            _fakeRepository = new Mock<IFlightReservationRepository>();
            _handler = new FlightReservationLoadAllHandler(_fakeRepository.Object);
        }

        [Fact]
        public async Task Deveria_recuperar_reserva_de_voo_com_sucesso()
        {
            int expected = 1;
            List<FlightReservation> reservations = new List<FlightReservation>()
            {
                FlightReservationBuilder.Start().Build(),
                FlightReservationBuilder.Start().Build()
            };

            _fakeRepository.Setup(x => x.GetAll()).ReturnsAsync(reservations);

            var cmd = new FlightReservationLoadAllQuery();

            var result = await _handler.Handle(cmd, It.IsAny<CancellationToken>());

            result.Should().BeOfType<List<FlightReservation>>();
            result.Should().HaveCount(2);
            _fakeRepository.Verify(x => x.GetAll(), Times.Once);

            //TODO: Verificar registro atualizado.

        }
    }
}
