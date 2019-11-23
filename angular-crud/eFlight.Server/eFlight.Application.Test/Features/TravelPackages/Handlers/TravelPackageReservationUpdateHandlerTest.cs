using AutoMapper;
using eFlight.Application.Features.Cars.Handlers;
using eFlight.Domain.Features.TravelPackages;
using eFlight.Tests.Common.Features.Hotels;
using eFlight.Tests.Common.Features.TravelPackages;
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
    public class TravelPackageReservationUpdateHandlerTest : IClassFixture<BaseTest>
    {
        private TravelPackageReservationUpdateHandler _handler;
        private Mock<ITravelPackageReservationRepository> _fakeRepository;
        private Mock<IMapper> _mapper;

        public TravelPackageReservationUpdateHandlerTest()
        {
            _fakeRepository = new Mock<ITravelPackageReservationRepository>();
            _mapper = new Mock<IMapper>();
            _handler = new TravelPackageReservationUpdateHandler(_fakeRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task Deveria_atualizar_reserva_de_pacote_com_sucesso()
        {
            int expected = 1;
            List<TravelPackageReservation> reservations = new List<TravelPackageReservation>()
            {
                TravelPackageReservationBuilder.Start().Build(),
                TravelPackageReservationBuilder.Start().Build(),
            };
            _fakeRepository.Setup(x => x.GetAll()).ReturnsAsync(reservations);

            var cmd = TravelPackageReservationUpdateCommandBuilder.Start().Build();

            var result = await _handler.Handle(cmd, It.IsAny<CancellationToken>());

            result.Should().BeTrue();
            _fakeRepository.Verify(x => x.GetAll(), Times.Once);
            _fakeRepository.Verify(x => x.Update(It.IsAny<TravelPackageReservation>()), Times.Once);
        }
    }
}
