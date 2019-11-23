//using eFlight.Domain.Features.TravelPackages;
//using eFlight.Infra.Data.Features.TravelPackages;
//using eFlight.Infra.Data.Tests.Base;
//using eFlight.Tests.Common.Features.TravelPackages;
//using FluentAssertions;
//using System.Linq;
//using Xunit;

//namespace eFlight.Infra.Data.Tests.TravelPackages
//{
//    [Collection("Database collection")]
//    public class TravelPackageReservationRepositoryTest : DatabaseFixture
//    {
//        //DatabaseFixture databaseFixture;

//        private TravelPackageReservationRepository _repository;

//        public TravelPackageReservationRepositoryTest()
//        {
//            _repository = new TravelPackageReservationRepository(Context);
//            //databaseFixture = fixture;
//        }

//        [Fact]
//        public void Deveria_adicioanar_uma_reserva_de_hotel_no_contexto()
//        {
//            //Arrange
//            TravelPackageReservation travelPackageReservation = TravelPackageReservationBuilder.Start().Build();

//            travelPackageReservation.SetId();

//            foreach (var customer in travelPackageReservation.TravelPackageCustomers)
//            {
//                customer.SetId();
//            }

//            //Action
//            var travelPackageAdd = _repository.Add(travelPackageReservation);

//            //Assert
//            var expectedTravelPackageReservation = Context.TravelPackageReservation.Find(travelPackageAdd.Result.Id);
//            expectedTravelPackageReservation.Should().NotBeNull();
//        }

//        //#region GET

//        [Fact]
//        public void Deveria_retornar_todos_as_reservas_de_hoteis_do_contexto()
//        {
//            //Action
//            var travelPackageReservations = _repository.GetAll().Result.ToList();

//            //Assert
//            travelPackageReservations.Should().HaveCount(1);
//        }

//        //TODO: Analisar uma forma de retornar somente a entidade e não as dependencias
//        [Fact]
//        public void Deveria_retornar_a_reseeva_de_hotel_pelo_id()
//        {
//            //Action
//            var travelPackageReservationDb = _repository.GetById(Seeder.TravelPackageReservationSeed.Id);

//            //Assert
//            travelPackageReservationDb.Id.Should().Equals(Seeder.TravelPackageReservationSeed.Id);
//        }


//        [Fact]
//        public void Deveria_retornar_reserva_de_hotel_por_id_e_suas_dependencias()
//        {
//            //Action
//            var travelPackageReservationDb = _repository.GetById(Seeder.TravelPackageReservationSeed.Id);

//            //Assert
//            travelPackageReservationDb.Id.Should().Equals(Seeder.TravelPackageReservationSeed.Id);
//            travelPackageReservationDb.Result.TravelPackageCustomers.Should().NotBeNull();
//        }

//        //#endregion GET

//        [Fact]
//        public void Deveria_excluir_reserva_de_voo_do_contexto()
//        {
//            //Action
//            var callbackRemove = _repository.DeleteById(Seeder.TravelPackageReservationSeed.Id);

//            //Assert

//            var travelPackageReservations = _repository.GetAll();

//            travelPackageReservations.Result.Should().HaveCount(0);
//        }

//        [Fact]
//        public void Deveria_atualizar_reserva_de_hotel_no_contexto()
//        {
//            //Arrange

//            foreach (var customer in Seeder.TravelPackageReservationSeed.TravelPackageCustomers)
//            {
//                customer.Name = "Teste Update";
//            }

//            //Action
//             _repository.Update(Seeder.TravelPackageReservationSeed);

//            //Assert
//            var expectedTravelPackageReservation = Context.TravelPackageReservation.Find(Seeder.TravelPackageReservationSeed.Id);
//            expectedTravelPackageReservation.TravelPackageCustomers.Should().HaveCount(1);
//        }
//    }
//}
