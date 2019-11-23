using eFlight.Acceptation.Tests.Base;
using eFlight.Acceptation.Tests.Features.Hotels.Pages;
using eFlight.Acceptation.Tests.Pages;
using eFlight.Tests.Common.Features.Hotels;
using FluentAssertions;
using System.Threading;
using Xunit;

namespace eFlight.Acceptation.Tests.Features.Hotels
{
    [Collection("acceptation collection")]
    public class HotelReservationAcceptationCreateTest : BaseTests
    {
        private HotelPage _hotelPage;
        private HotelReservationPage _hotelReservationPage;
        private HotelReservationFormPage _hotelReservationFormPage;

        public HotelReservationAcceptationCreateTest()
        {
            string urlToGo = SetupTest._acceptanceTestSettings.BaseClientUrl + "home";

            var homePage = new HomePage(NgDriver);
            //var subMenusPage = new CustomerSubMenuComponent(NgDriver);

            _hotelPage = new HotelPage(NgDriver);
            //_flightReservationPage = new FlightReservationPage(NgDriver);
            _hotelReservationFormPage = new HotelReservationFormPage(NgDriver);

            //NgDriver.Navigate().GoToUrl(urlToGo);

            //homePage.MainMenu.WaitUntilBeVisibleAndClickOnIt(NgDriver);

            homePage.HotelItem.Click();
            //subMenusPage.CustomersSubMenu.Click();

        }

        [Fact]
        public void Deveria_Salvar_Reserva_Hotel_com_sucesso()
        {
            //Arrange
            _hotelPage.HotelReservationCreateButton.Click();

            var command = HotelReservationRegisterCommandBuilder.Start().Build();
            _hotelReservationFormPage.FillData(command);

            //act
            _hotelReservationFormPage.DefaultButtonsComponent.SaveButton.Click();
            Thread.Sleep(1000);
            NgDriver.SwitchTo().Alert().Accept();

            //assert
            NgDriver.Url.Should().Contain("/hotels");
            //_flightReservationPage.GenericGridComponent.HasAnyRow(2, command.Description).Should().BeTrue();
        }

        [Fact]
        public void Deveria_editar_Reserva_Hotel_com_sucesso()
        {
            _hotelPage.HotelReservationViewButton.Click();
            _hotelReservationPage = new HotelReservationPage(NgDriver);

            //action
            _hotelReservationPage.HotelReservationOpenButton.Click();
            _hotelReservationFormPage.ClearData();
            var command = HotelReservationRegisterCommandBuilder.Start().WithDescription("Atualizacao de reserva de voo").Build();
            _hotelReservationFormPage.FillData(command);
            _hotelReservationFormPage.DefaultButtonsComponent.SaveButton.Click();
            Thread.Sleep(1000);
            NgDriver.SwitchTo().Alert().Accept();

            //assert
            NgDriver.Url.Should().Contain("/hotels");
        }

        [Fact]
        public void Deveria_deletar_Reserva_Hotel_com_sucesso()
        {
            _hotelPage.HotelReservationViewButton.Click();
            _hotelReservationPage = new HotelReservationPage(NgDriver);

            //action
            _hotelReservationPage.HotelDeleteButton.Click();
            Thread.Sleep(1000);
            NgDriver.SwitchTo().Alert().Accept();

            //assert
            NgDriver.Url.Should().Contain("/hotelReservation");
        }
    }
}
