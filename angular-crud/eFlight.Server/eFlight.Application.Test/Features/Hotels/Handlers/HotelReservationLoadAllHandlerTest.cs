using eFlight.Application.Features.Hotels.Handlers;
using eFlight.Application.Features.Hotels.Queries;
using eFlight.Domain.Features.Hotels;
using eFlight.Tests.Common.Features.Hotels;
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
    public class HotelReservationLoadAllHandlerTest : IClassFixture<BaseTest>
    {
        private HotelReservationLoadAllHandler _handler;
        private Mock<IHotelReservationRepository> _fakeRepository;

        public HotelReservationLoadAllHandlerTest()
        {
            _fakeRepository = new Mock<IHotelReservationRepository>();
            _handler = new HotelReservationLoadAllHandler(_fakeRepository.Object);
        }

        [Fact]
        public async Task Deveria_recuperar_reserva_de_hotel_com_sucesso()
        {
            int expected = 1;
            List<HotelReservation> reservations = new List<HotelReservation>()
            {
                HotelReservationBuilder.Start().Build(),
                HotelReservationBuilder.Start().Build()
            };

            _fakeRepository.Setup(x => x.GetAll()).ReturnsAsync(reservations);

            var cmd = new HotelReservationLoadAllQuery();

            var result = await _handler.Handle(cmd, It.IsAny<CancellationToken>());

            result.Should().BeOfType<List<HotelReservation>>();
            result.Should().HaveCount(2);
            _fakeRepository.Verify(x => x.GetAll(), Times.Once);

            //TODO: Verificar registro atualizado.

        }
    }
}
