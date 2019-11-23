using eFlight.Domain.Features.Flights;
using eFlight.Infra.Data.Features.Flights;
using eFlight.Infra.Data.Tests.Base;
using eFlight.Tests.Common.Features.Flights;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace eFlight.Infra.Data.Tests.Flights
{
    [Collection("Database collection")]
    public class FlightReservationRepositoryTest : DatabaseFixture
    {

        private FlightReservationRepository _repository;

        public FlightReservationRepositoryTest()
        {
            _repository = new FlightReservationRepository(Context);
        }

        [Fact]
        public void Deveria_adicioanar_um_voo_no_contexto()
        {
            //Arrange
            FlightReservation flightReservation = FlightReservationBuilder.Start().Build();

            flightReservation.SetId();

            foreach (var customer in flightReservation.FlightReservationCustomers)
            {
                customer.SetId();
            }

            //Action
            var flightReservationAdd = _repository.Add(flightReservation);

            //Assert
            var expectedFlight = Context.FlightReservation.Find(flightReservationAdd.Result.Id);
            expectedFlight.Should().NotBeNull();
        }

        #region GET

        [Fact]
        public void Deveria_retornar_todos_as_reservas_de_voos_do_contexto()
        {
            //Action
            var flightsReservation = _repository.GetAll().Result;

            //Assert
            flightsReservation.Should().HaveCount(2);
        }

        //TODO: Analisar uma forma de retornar somente a entidade e não as dependencias
        [Fact]
        public void Deveria_retornar_o_voo_pelo_id()
        {
            //Action
            var flightReservationDb = _repository.GetById(Seeder.FlightReservationSeedOne.Id);

            //Assert
            flightReservationDb.Id.Should().Equals(Seeder.FlightReservationSeedOne.Id);

        }

        [Fact]
        public void Deveria_retornar_os_voos_e_as_dependencias()
        {
            //Action
            var flights = _repository.GetAllIncludeCustomers();

            //Assert            flights.Result.Should().HaveCount(2);
            flights.Result.ForEach(c =>
            {
                c.FlightReservationCustomers.Should().HaveCount(1);
            });
        }

        [Fact]
        public void Deveria_retornar_voo_por_id_e_suas_dependencias()
        {
            //Action
            var flightDb = _repository.GetById(Seeder.FlightReservationSeedOne.Id);

            //Assert
            flightDb.Id.Should().Equals(Seeder.FlightReservationSeedOne.Id);
            flightDb.Result.FlightReservationCustomers.Should().NotBeNull();
        }
        #endregion GET

        [Fact]
        public void Deveria_excluir_reserva_de_voo_do_contexto()
        {
            //Action
            _repository.DeleteById(Seeder.FlightReservationSeedOne.Id);

            var flights = _repository.GetAll();

            //Assert

            flights.Result.Should().HaveCount(1);
        }

        [Fact]
        public void Deveria_atualizar_reserva_de_voo_no_contexto()
        {
            //Arrange

            foreach (var customer in Seeder.FlightReservationSeedOne.FlightReservationCustomers)
            {
                customer.Name = "Teste Update";
            }

            //Action
            _repository.Update(Seeder.FlightReservationSeedOne);

            //Assert
            var expectedFlight = Context.FlightReservation.Find(Seeder.FlightReservationSeedOne.Id);
            expectedFlight.FlightReservationCustomers.Should().HaveCount(1);
        }
    }
}
