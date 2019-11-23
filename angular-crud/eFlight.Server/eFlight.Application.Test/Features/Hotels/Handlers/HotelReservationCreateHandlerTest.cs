using AutoMapper;
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

namespace eFlight.Application.Test.Features.Hotels.Handlers
{
    public class HotelReservationCreateHandlerTest : IClassFixture<BaseTest>
    {
        private HotelReservationCreateHandler _handler;
        private Mock<IHotelReservationRepository> _fakeRepository;
        private Mock<IMapper> _fakeMapper;

        public HotelReservationCreateHandlerTest()
        {
            _fakeRepository = new Mock<IHotelReservationRepository>();
            _fakeMapper = new Mock<IMapper>();
            _handler = new HotelReservationCreateHandler(_fakeRepository.Object, _fakeMapper.Object);
        }

        [Fact]
        public async Task Deveria_criar_reserva_de_hotel_com_sucesso()
        {
            int expected = 1;

            HotelReservation reservation = HotelReservationBuilder.Start().Build();

            var cmd = HotelReservationRegisterCommandBuilder.Start().Build();
            _fakeMapper.Setup(x => x.Map<HotelReservation>(cmd)).Returns(reservation);

            var result = await _handler.Handle(cmd, It.IsAny<CancellationToken>());

            result.Should().BeTrue();
            _fakeRepository.Verify(x => x.Add(It.IsAny<HotelReservation>()), Times.Once);
        }
    }
}
