using AutoMapper;
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
    public class CarReservationUpdateHandlerTest : IClassFixture<BaseTest>
    {
        private CarReservationUpdateHandler _handler;
        private Mock<ICarReservationRepository> _fakeRepository;
        private Mock<IMapper> _mapper;

        public CarReservationUpdateHandlerTest()
        {
            _fakeRepository = new Mock<ICarReservationRepository>();
            _mapper = new Mock<IMapper>();
            _handler = new CarReservationUpdateHandler(_fakeRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task Deveria_atualizar_reserva_de_carro_com_sucesso()
        {
            int expected = 1;
            List<CarReservation> reservations = new List<CarReservation>()
            {
                CarReservationBuilder.Start().Build(),
                CarReservationBuilder.Start().Build()
            };
            _fakeRepository.Setup(x => x.GetAll()).ReturnsAsync(reservations);

            var cmd = CarReservationUpdateCommandBuilder.Start().Build();

            var result = await _handler.Handle(cmd, It.IsAny<CancellationToken>());

            result.Should().BeTrue();
            _fakeRepository.Verify(x => x.Update(It.IsAny<CarReservation>()), Times.Once);
        }
    }
}
