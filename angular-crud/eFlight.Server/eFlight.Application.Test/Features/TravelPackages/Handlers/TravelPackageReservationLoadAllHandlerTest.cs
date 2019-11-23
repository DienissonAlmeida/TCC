using eFlight.Application.Features.TravelPackages.Handlers;
using eFlight.Application.Features.TravelPackages.Queries;
using eFlight.Domain.Features.TravelPackages;
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
    public class TravelPackageReservationLoadAllHandlerTest : IClassFixture<BaseTest>
    {
        private TravelPackageReservationLoadAllHandler _handler;
        private Mock<ITravelPackageReservationRepository> _fakeRepository;

        public TravelPackageReservationLoadAllHandlerTest()
        {
            _fakeRepository = new Mock<ITravelPackageReservationRepository>();
            _handler = new TravelPackageReservationLoadAllHandler(_fakeRepository.Object);
        }

        [Fact]
        public async Task Deveria_recuperar_reserva_de_pacote_com_sucesso()
        {
            int expected = 1;
            List<TravelPackageReservation> reservations = new List<TravelPackageReservation>()
            {
                TravelPackageReservationBuilder.Start().Build(),
                TravelPackageReservationBuilder.Start().Build()
            };

            _fakeRepository.Setup(x => x.GetAll()).ReturnsAsync(reservations);

            var cmd = new TravelPackageReservationLoadAllQuery();

            var result = await _handler.Handle(cmd, It.IsAny<CancellationToken>());

            result.Should().BeOfType<List<TravelPackageReservation>>();
            result.Should().HaveCount(2);
            _fakeRepository.Verify(x => x.GetAll(), Times.Once);

            //TODO: Verificar registro atualizado.

        }
    }
}
