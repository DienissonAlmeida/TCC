using eFlight.Application.Features.Hotels.Commands;
using eFlight.Application.Features.Hotels.Handlers;
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
    public class HotelReservationDeleteHandlerTest : IClassFixture<BaseTest>
    {
        private HotelReservationDeleteHandler _handler;
        private Mock<IHotelReservationRepository> _fakeRepository;

        public HotelReservationDeleteHandlerTest()
        {
            _fakeRepository = new Mock<IHotelReservationRepository>();
            _handler = new HotelReservationDeleteHandler(_fakeRepository.Object);
        }

        [Fact]
        public async Task Deveria_excluir_reserva_de_hotel_com_sucesso()
        {
            int expected = 1;

            HotelReservation reservation = HotelReservationBuilder.Start()
                .WithInputDate(DateTime.Now.AddDays(11))
                .Build();

            _fakeRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(reservation);

            var cmd = new HotelReservationDeleteCommand() { HotelReservationId = 1 };

            var result = await _handler.Handle(cmd, It.IsAny<CancellationToken>());

            result.Should().BeTrue();
            _fakeRepository.Verify(x => x.GetById(cmd.HotelReservationId), Times.Once);
            _fakeRepository.Verify(x => x.DeleteById(cmd.HotelReservationId), Times.Once);

        }
    }
}
