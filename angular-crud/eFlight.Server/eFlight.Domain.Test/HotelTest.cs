//using eFlight.Domain.Features.Hotels;
//using FluentAssertions;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using Xunit;

//namespace eFlight.Domain.Test
//{
//    public class HotelTest
//    {
//        [Fact]
//        public void Deveria_cadstrar_reservas_de_quarto()
//        {

//        }

//        [Fact]
//        public void Nao_deveria_excluir_reserva_de_hotel_com_menos_de_10_dias()
//        {
//            var hotel = new Hotel
//            {
//                City = "Lages",
//                Name = "Campinas",
//                Input = DateTime.Now.AddDays(10),
//                Output = DateTime.Parse("23/04/2020"),
//                Guest = 1,
//                Daily = 2000,
//                Stars = 4

//            };

//            hotel.CanDelete().Should().BeFalse();
//        }

//        [Fact]
//        public void Deveria_excluir_reserva_de_hotel_com_mais_de_10_dias()
//        {
//            var hotel = new Hotel
//            {
//                City = "Lages",
//                Name = "Campinas",
//                Input = DateTime.Now.AddDays(12),
//                Output = DateTime.Parse("23/04/2020"),
//                Guest = 1,
//                Daily = 2000,
//                Stars = 4
//            };

//            hotel.CanDelete().Should().BeTrue();
//        }
//    }
//}
