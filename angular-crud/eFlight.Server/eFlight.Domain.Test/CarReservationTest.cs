using eFlight.Tests.Common.Features;
using eFlight.Tests.Common.Features.Cars;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace eFlight.Domain.Test
{
    public class CarReservationTest
    {
        public CarReservationTest()
        {

        }
        [Fact]
        public void Deveria_validar_reserva_com_um_clientes()
        {
            var car = CarBuilder.Start().Build();
            var customer = CustomerBuilder.Start().Build();

            var flightReservation = CarReservationBuilder.Start().WithCar(car).WithCustomer(customer).Build();

            var result = flightReservation.CanRegister();

            result.Should().Be("Cadastro validado");
        }
        [Theory]
        [InlineData(1, 2)]
        public void Nao_deveria_validar_reserva_quando_carro_ja_alugado_pro_periodo(int value1, int value2)
        {
            var customerRegistered = CustomerBuilder.Start().WithName("Dienisson").Build();
            var carReservationRegistered = CarReservationBuilder.Start().WithCustomer(customerRegistered)
                .WithInputDate(DateTime.Now.AddDays(-2))
                .WithOutputDate(DateTime.Now.AddDays(10))
                .Build();
            
            
            var car = CarBuilder.Start().WithCarReservation(carReservationRegistered).Build();
            var customer = CustomerBuilder.Start().WithId(value1).WithName("Dienisson").Build();

            var carReservationTwho = CarReservationBuilder.Start()
                .WithCustomer(customer)
                .WithInputDate(DateTime.Now)
                .WithOutputDate(DateTime.Now.AddDays(2))
                .WithCar(car)
                .Build();

            var result = carReservationTwho.CanRegister();
            result.Should().Be("Carro já reservado para o periodo");
        }

        [Fact]
        public void Nao_deveria_excluir_reserva_de_voo_com_menos_de_10_dias()
        {
            var carReservation = CarReservationBuilder.Start().WithInputDate(DateTime.Now.AddDays(9)).Build();

            carReservation.CanDelete().Should().BeFalse();
        }
        [Fact]
        public void Deveria_excluir_reserva_de_voo_com_mais_de_10_dias()
        {
            var flightReservation = CarReservationBuilder.Start().WithInputDate(DateTime.Now.AddDays(12)).Build();

            flightReservation.CanDelete().Should().BeTrue();
        }
    }
}
