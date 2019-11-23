using eFlight.Application.Features.Cars.Handlers;
using eFlight.Application.Features.TravelPackages.Commands;
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
    public class TravelPackageReservationDeleteHandlerTest : IClassFixture<BaseTest>
    {
        private TravelPackageReservationDeleteHandler _handler;
        private Mock<ITravelPackageReservationRepository> _fakeRepository;

        public TravelPackageReservationDeleteHandlerTest()
        {
            _fakeRepository = new Mock<ITravelPackageReservationRepository>();
            _handler = new TravelPackageReservationDeleteHandler(_fakeRepository.Object);
        }

        [Fact]
        public async Task Deveria_excluir_reserva_de_pacote_com_sucesso()
        {
            int expected = 1;

            TravelPackageReservation reservation = TravelPackageReservationBuilder.Start()
                .WithInputDate(DateTime.Now.AddDays(11))
                .Build();

            _fakeRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(reservation);

            var cmd = new TravelPackageReservationDeleteCommand() { TravelPackageId = 1 };

            var result = await _handler.Handle(cmd, It.IsAny<CancellationToken>());

            result.Should().BeTrue();
            _fakeRepository.Verify(x => x.GetById(cmd.TravelPackageId), Times.Once);
            _fakeRepository.Verify(x => x.DeleteById(cmd.TravelPackageId), Times.Once);

        }
    }
}
