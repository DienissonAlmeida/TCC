//using AutoMapper;
//using eFlight.Application.Features.TravelPackages.Handlers;
//using eFlight.Domain.Features.TravelPackages;
//using eFlight.Tests.Common.Features.TravelPackages;
//using FluentAssertions;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using Xunit;

//namespace eFlight.Application.Test.Features.TravelPackages.Handlers
//{
//    public class TravelPackageReservationCreateHandlerTest : IClassFixture<BaseTest>
//    {
//        private TravelPackageReservationCreateHandler _handler;
//        private Mock<ITravelPackageReservationRepository> _fakeRepository;
//        private Mock<IMapper> _fakeMapper;

//        public TravelPackageReservationCreateHandlerTest()
//        {
//            _fakeRepository = new Mock<ITravelPackageReservationRepository>();
//            _fakeMapper = new Mock<IMapper>();
//            _handler = new TravelPackageReservationCreateHandler(_fakeRepository.Object, _fakeMapper.Object);
//        }

//        [Fact]
//        public async Task Deveria_criar_reserva_de_pacote_de_viagem_com_sucesso()
//        {
//            TravelPackageReservation travelPackageReservation = TravelPackageReservationBuilder.Start().Build();

//            var cmd = TravelPackageReservationRegisterCommandBuilder.Start().Build();
//            _fakeMapper.Setup(x => x.Map<TravelPackageReservation>(cmd)).Returns(travelPackageReservation);


//            var result = await _handler.Handle(cmd, It.IsAny<CancellationToken>());

//            result.Should().BeTrue();
//            _fakeRepository.Verify(x => x.Add(It.IsAny<TravelPackageReservation>()), Times.Once);

//        }
//    }
//}