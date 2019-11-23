using eFlight.Domain.Features.Cars;
using eFlight.Domain.Features.TravelPackages;
using eFlight.Infra.Data.Features.Cars;
using eFlight.Infra.Data.Features.TravelPackages;
using eFlight.Infra.Data.Tests.Base;
using eFlight.Tests.Common.Features.Cars;
using eFlight.Tests.Common.Features.TravelPackages;
using FluentAssertions;
using System.Linq;
using Xunit;

namespace eFlight.Infra.Data.Tests.Cars
{
    [Collection("Database collection")]
    public class CarReservationRepositoryTest : DatabaseFixture
    {
        //DatabaseFixture databaseFixture;

        private CarReservationRepository _repository;

        public CarReservationRepositoryTest()
        {
            _repository = new CarReservationRepository(Context);
            //databaseFixture = fixture;
        }

        [Fact]
        public void Deveria_adicioanar_uma_reserva_de_carro_no_contexto()
        {
            //Arrange
            CarReservation carReservation = CarReservationBuilder.Start().Build();

            carReservation.SetId();

            foreach (var customer in carReservation.CarReservationCustomers)
            {
                customer.SetId();
            }

            //Action
            var carReservationAdd = _repository.Add(carReservation);

            //Assert
            var expectedCarReservation = Context.CarReservation.Find(carReservationAdd.Result.Id);
            expectedCarReservation.Should().NotBeNull();
        }

        //#region GET

        [Fact]
        public void Deveria_retornar_todos_as_reservas_de_hoteis_do_contexto()
        {
            //Action
            var carReservations = _repository.GetAll().Result.ToList();

            //Assert
            carReservations.Should().HaveCount(1);
        }

        //TODO: Analisar uma forma de retornar somente a entidade e não as dependencias
        [Fact]
        public void Deveria_retornar_a_reseeva_de_carro_pelo_id()
        {
            //Action
            var carReservationDb = _repository.GetById(Seeder.CarReservationSeed.Id);

            //Assert
            carReservationDb.Id.Should().Equals(Seeder.CarReservationSeed.Id);
        }


        [Fact]
        public void Deveria_retornar_reserva_de_hotel_por_id_e_suas_dependencias()
        {
            //Action
            var carReservationDb = _repository.GetById(Seeder.CarReservationSeed.Id);

            //Assert
            carReservationDb.Id.Should().Equals(Seeder.TravelPackageReservationSeed.Id);
            carReservationDb.Result.CarReservationCustomers.Should().NotBeNull();
        }

        //#endregion GET

        [Fact]
        public void Deveria_excluir_reserva_de_carro_do_contexto()
        {
            //Action
            var callbackRemove = _repository.DeleteById(Seeder.CarReservationSeed.Id);

            //Assert

            var carReservationsDb = _repository.GetAll();

            carReservationsDb.Result.Should().HaveCount(0);
        }

        [Fact]
        public void Deveria_atualizar_reserva_de_carro_no_contexto()
        {
            //Arrange

            foreach (var customer in Seeder.CarReservationSeed.CarReservationCustomers)
            {
                customer.Name = "Teste Update";
            }

            //Action
            _repository.Update(Seeder.CarReservationSeed);

            //Assert
            var expectedCarReservation = Context.CarReservation.Find(Seeder.CarReservationSeed.Id);
            expectedCarReservation.CarReservationCustomers.Should().HaveCount(1);
        }
    }
}
