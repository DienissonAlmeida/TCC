using System;
using Xunit;
using eFlight.Domain.Features.Flights;
using System.Collections.Generic;
using FluentAssertions;
using eFlight.Tests.Common.Features.Flights;
using eFlight.Tests.Common.Features;

namespace eFlight.Domain.Test
{
    public class FlightReservationTest
    {
        public FlightReservationTest()
        {
        }

        [Fact]
        public void Deveria_cadastrar_reserva_com_um_cliente()
        {
            var flight = FlightBuilder.Start().WithVacancies(40).Build();
            var customer = CustomerBuilder.Start().Build();
            var flightReservation = FlightReservationBuilder.Start().WithFlight(flight).WithCustomer(customer).Build();

            var result = flightReservation.CanRegister();

            result.Should().Be("Cadastro validado");
        }
        [Theory]
        [InlineData(1, 2)]
        public void Nao_deveria_cadastrar_reserva_com_cliente_ja_cadastrado(int value1, int value2)
        {
            var customerRegistered = CustomerBuilder.Start().WithName("Dienisson").Build();
            var flightReservationRegistered = FlightReservationBuilder.Start().WithCustomer(customerRegistered).Build();
            var flight = FlightBuilder.Start().WithFlighReservation(flightReservationRegistered).WithVacancies(40).Build();
            var customer = CustomerBuilder.Start().WithId(value1).WithName("Dienisson").Build();
            var customeTwo = CustomerBuilder.Start().WithId(value2).Build();

            var flightReservationTwo = FlightReservationBuilder.Start()
                .WithCustomer(customer)
                .WithCustomer(customeTwo)
                .WithFlight(flight)
                .Build();

            var result = flightReservationTwo.CanRegister();
            result.Should().Be("Vaga já cadastrado: Dienisson");
        }

        [Fact]
        public void Nao_deveria_cadastrar_reserva_quando_lotado()
        {
            var flight = FlightBuilder.Start().Build();

            var customer = CustomerBuilder.Start().Build();
            var flightReservation = FlightReservationBuilder.Start().WithFlight(flight).WithCustomer(customer).Build();

            var result = flightReservation.CanRegister();

            result.Should().Be("Voo lotado");
        }

        [Fact]
        public void Nao_deveria_excluir_reserva_de_voo_com_menos_de_10_dias()
        {
            var flightReservation = FlightReservationBuilder.Start().WithInputDate(DateTime.Now.AddDays(9)).Build();

            flightReservation.CanDelete().Should().BeFalse();
        }
        [Fact]
        public void Deveria_excluir_reserva_de_voo_com_mais_de_10_dias()
        {
            var flightReservation = FlightReservationBuilder.Start().WithInputDate(DateTime.Now.AddDays(12)).Build();

            flightReservation.CanDelete().Should().BeTrue();
        }
    }
}
