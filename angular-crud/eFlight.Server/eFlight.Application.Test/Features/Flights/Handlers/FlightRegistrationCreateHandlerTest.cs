using eFlight.Application.Features.Flights.Handlers;
using eFlight.Domain.Features.Flights;
using eFlight.Tests.Common.Features.Flights;
using eFlight.Tests.Common.Features.Hotels;
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
    public class FlightReservationCreateHandlerTest : IClassFixture<BaseTest>
    {
        private FlightReservationCreateHandler _handler;
        private Mock<IFlightReservationRepository> _fakeRepository;

        public FlightReservationCreateHandlerTest()
        {
            _fakeRepository = new Mock<IFlightReservationRepository>();
            _handler = new FlightReservationCreateHandler(_fakeRepository.Object);
        }

        [Fact]
        public async Task Deveria_criar_reserva_de_voo_com_sucesso()
        {
            var flight = FlightBuilder.Start().WithVacancies(40).Build();
            flight.Id = 1;

            List<FlightReservation> reservations = new List<FlightReservation>()
            {
                FlightReservationBuilder.Start().WithFlightId(1).WithFlight(flight).Build(),
                FlightReservationBuilder.Start().WithFlightId(1).Build()
            };

            _fakeRepository.Setup(x => x.GetAllIncludeCustomers()).ReturnsAsync(reservations);
            _fakeRepository.Setup(x => x.GetAllIncludeFlight()).ReturnsAsync(reservations);

            var cmd = FlightReservationRegisterCommandBuilder.Start().Build();

            var result = await _handler.Handle(cmd, It.IsAny<CancellationToken>());

            result.Should().BeTrue();
            _fakeRepository.Verify(x => x.Add(It.IsAny<FlightReservation>()), Times.Once);

        }
    }
}
