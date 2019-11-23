using eFlight.Domain.Features.Hotels;
using eFlight.Infra.Data.Features.Hotels;
using eFlight.Infra.Data.Tests.Base;
using eFlight.Tests.Common.Features.Hotels;
using FluentAssertions;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace eFlight.Infra.Data.Tests.Hotels
{
    [Collection("Database collection")]
    public class HotelReservationRepositoryTest : DatabaseFixture
    {
        //DatabaseFixture databaseFixture;

        private HotelReservationRepository _repository;

        public HotelReservationRepositoryTest()
        {
            _repository = new HotelReservationRepository(Context);
            //databaseFixture = fixture;
        }

        [Fact]
        public void Deveria_adicioanar_uma_reserva_de_hotel_no_contexto()
        {
            //Arrange
            HotelReservation hotelReservation = HotelReservationBuilder.Start().Build();

            hotelReservation.SetId();

            foreach (var customer in hotelReservation.HotelReservationCustomers)
            {
                customer.SetId();
            }

            //Action
            var hotelReservationAdd = _repository.Add(hotelReservation);

            //Assert
            var expectedHotelReservation = Context.HotelReservation.Find(hotelReservationAdd.Result.Id);
            expectedHotelReservation.Should().NotBeNull();
        }

        //#region GET

        [Fact]
        public void Deveria_retornar_todos_as_reservas_de_hoteis_do_contexto()
        {
            //Action
            var hotelsReservations = _repository.GetAll().Result.ToList();

            //Assert
            hotelsReservations.Should().HaveCount(1);
        }

        //TODO: Analisar uma forma de retornar somente a entidade e não as dependencias
        [Fact]
        public void Deveria_retornar_a_reseeva_de_hotel_pelo_id()
        {
            //Action
            var hotelReservationDb = _repository.GetById(Seeder.HotelReservationSeed.Id);

            //Assert
            hotelReservationDb.Id.Should().Equals(Seeder.HotelReservationSeed.Id);
        }


        [Fact]
        public void Deveria_retornar_reserva_de_hotel_por_id_e_suas_dependencias()
        {
            //Action
            var hotelReservationDb = _repository.GetById(Seeder.HotelReservationSeed.Id);

            //Assert
            hotelReservationDb.Id.Should().Equals(Seeder.HotelReservationSeed.Id);
            hotelReservationDb.Result.HotelReservationCustomers.Should().NotBeNull();
        }

        //#endregion GET

        [Fact]
        public void Deveria_excluir_reserva_de_voo_do_contexto()
        {
            //Action
            var callbackRemove = _repository.DeleteById(Seeder.FlightReservationSeedOne.Id);

            //Assert

            var hotelReservations = _repository.GetAll();

            hotelReservations.Result.Should().HaveCount(0);
        }

        [Fact]
        public void Deveria_atualizar_reserva_de_hotel_no_contexto()
        {
            //Arrange

            foreach (var customer in Seeder.HotelReservationSeed.HotelReservationCustomers)
            {
                customer.Name = "Teste Update";
            }

            //Action
            _repository.Update(Seeder.HotelReservationSeed);

            //Assert
            var expectedHotelReservation = Context.HotelReservation.Find(Seeder.HotelReservationSeed.Id);
            expectedHotelReservation.HotelReservationCustomers.Should().HaveCount(1);
        }
    }
}
