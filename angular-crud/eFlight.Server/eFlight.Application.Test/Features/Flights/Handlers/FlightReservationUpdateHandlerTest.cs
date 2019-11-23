using AutoMapper;
using eFlight.Application.Features.Flights.Handlers;
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
    public class FlightReservationUpdateHandlerTest : IClassFixture<BaseTest>
    {
        private FlightReservationUpdateHandler _handler;
        private Mock<IFlightReservationRepository> _fakeRepository;
        private Mock<IMapper> _mapper;

        public FlightReservationUpdateHandlerTest()
        {
            _fakeRepository = new Mock<IFlightReservationRepository>();
            _mapper = new Mock<IMapper>();
            _handler = new FlightReservationUpdateHandler(_fakeRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task Deveria_atualizar_reserva_de_voo_com_sucesso()
        {
            int expected = 1;
            List<FlightReservation> reservations = new List<FlightReservation>()
            {
                FlightReservationBuilder.Start().WithId(1).Build(),
                FlightReservationBuilder.Start().WithId(2).Build()
            };

            _fakeRepository.Setup(x => x.GetAllIncludeCustomers()).ReturnsAsync(reservations);

            var cmd = FlightReservationUpdateCommandBuilder.Start().Build();

            var result = await _handler.Handle(cmd, It.IsAny<CancellationToken>());

            result.Should().BeTrue();
            _fakeRepository.Verify(x => x.GetAllIncludeCustomers(), Times.Once);
            _fakeRepository.Verify(x => x.Update(It.IsAny<FlightReservation>()), Times.Once);
        }
    }
}
