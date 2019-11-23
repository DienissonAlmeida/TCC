using eFlight.Tests.Common.Features;
using eFlight.Tests.Common.Features.Hotels;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace eFlight.Domain.Test
{
    public class HotelReservationTest
    {
        public HotelReservationTest()
        {

        }
        [Fact]
        public void Deveria_cadastrar_reserva_com_um_clientes()
        {
            var hotel = HotelBuilder.Start().Build();
            var customer = CustomerBuilder.Start().Build();

            var hotelReservation = HotelReservationBuilder.Start().WithHotel(hotel).WithCustomer(customer).Build();

            var result = hotelReservation.CanRegister();

            result.Should().Be("Cadastro validado");
        }
        [Theory]
        [InlineData(1, 2)]
        public void Nao_deveria_cadastrar_reserva_com_cliente_ja_cadastrado(int value1, int value2)
        {
            var customerRegistered = CustomerBuilder.Start().WithName("Dienisson").Build();
            var hotelReservationRegistered = HotelReservationBuilder.Start().WithCustomer(customerRegistered).Build();
            var hotel = HotelBuilder.Start().WithHotelReservation(hotelReservationRegistered).Build();
            var customer = CustomerBuilder.Start().WithId(value1).WithName("Dienisson").Build();
            var customeTwo = CustomerBuilder.Start().WithId(value2).Build();

            var hotelReservationTwho = HotelReservationBuilder.Start()
                .WithCustomer(customer)
                .WithCustomer(customeTwo)
                .WithHotel(hotel)
                .Build();

            var result = hotelReservationTwho.CanRegister();
            result.Should().Be("Vaga já cadastrado: Dienisson");
        }

        [Fact]
        public void Nao_deveria_excluir_reserva_de_voo_com_menos_de_10_dias()
        {
            var hotelReservation = HotelReservationBuilder.Start().WithInputDate(DateTime.Now.AddDays(9)).Build();

            hotelReservation.CanDelete().Should().BeFalse();
        }
        [Fact]
        public void Deveria_excluir_reserva_de_voo_com_mais_de_10_dias()
        {
            var hotelReservation = HotelReservationBuilder.Start().WithInputDate(DateTime.Now.AddDays(12)).Build();

            hotelReservation.CanDelete().Should().BeTrue();
        }
    }
}
