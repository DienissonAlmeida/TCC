using AutoMapper;
using eFlight.Application.Features.Flights.Handlers;
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
    public class HotelReservationUpdateHandlerTest : IClassFixture<BaseTest>
    {
        private HotelReservationUpdateHandler _handler;
        private Mock<IHotelReservationRepository> _fakeRepository;
        private Mock<IMapper> _mapper;

        public HotelReservationUpdateHandlerTest()
        {
            _fakeRepository = new Mock<IHotelReservationRepository>();
            _mapper = new Mock<IMapper>();
            _handler = new HotelReservationUpdateHandler(_fakeRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task Deveria_atualizar_reserva_de_hotel_com_sucesso()
        {
            int expected = 1;
            List<HotelReservation> reservations = new List<HotelReservation>()
            {
                HotelReservationBuilder.Start().Build(),
                HotelReservationBuilder.Start().Build()
            };

            _fakeRepository.Setup(x => x.GetAll()).ReturnsAsync(reservations);

            var cmd = HotelReservationUpdateCommandBuilder.Start().Build();

            var result = await _handler.Handle(cmd, It.IsAny<CancellationToken>());

            result.Should().BeTrue();
            _fakeRepository.Verify(x => x.GetAll(), Times.Once);
            _fakeRepository.Verify(x => x.Update(It.IsAny<HotelReservation>()), Times.Once);
        }
    }
}
