using eFlight.Acceptation.Tests.Base;
using eFlight.Acceptation.Tests.Features.Flights.Pages;
using eFlight.Acceptation.Tests.Pages;
using eFlight.Tests.Common.Features.Flights;
using FluentAssertions;
using System.Threading;
using Xunit;

namespace eFlight.Acceptation.Tests.Features.Flights
{
    [Collection("acceptation collection")]
    public class FlightReservationAcceptationCreateTest : BaseTests
    {
        private FlightPage _flightPage;
        private FlightReservationPage _flightReservationPage;
        private FlightReservationFormPage _flightReservationFormPage;

        public FlightReservationAcceptationCreateTest()
        {
            string urlToGo = SetupTest._acceptanceTestSettings.BaseClientUrl + "home";
            var homePage = new HomePage(NgDriver);

            _flightPage = new FlightPage(NgDriver);
            _flightReservationFormPage = new FlightReservationFormPage(NgDriver);

            homePage.FlightItem.Click();
        }

        [Fact]
        public void Deveria_Salvar_Reserva_Voo_com_sucesso()
        {
            //Arrange
            _flightPage.FlightReservationCreateButton.Click();

            var command = FlightReservationRegisterCommandBuilder.Start().Build();
            _flightReservationFormPage.FillData(command);

            //act
            _flightReservationFormPage.DefaultButtonsComponent.SaveButton.Click();
            Thread.Sleep(1000);
            NgDriver.SwitchTo().Alert().Accept();

            //assert
            NgDriver.Url.Should().Contain("/flights");
        }

        [Fact]
        public void Deveria_editar_Reserva_Voo_com_sucesso()
        {
            _flightPage.FlightReservationViewButton.Click();
            _flightReservationPage = new FlightReservationPage(NgDriver);

            //action
            _flightReservationPage.FlightReservationOpenButton.Click();
            _flightReservationFormPage.ClearData();
            var command = FlightReservationRegisterCommandBuilder.Start().WithDescription("Atualizacao de reserva de voo").Build();
            _flightReservationFormPage.FillData(command);
            _flightReservationFormPage.DefaultButtonsComponent.SaveButton.Click();
            Thread.Sleep(1000);
            NgDriver.SwitchTo().Alert().Accept();

            //assert
            NgDriver.Url.Should().Contain("/flights");
        }

        [Fact]
        public void Deveria_deletar_Reserva_Voo_com_sucesso()
        {
            _flightPage.FlightReservationViewButton.Click();
            _flightReservationPage = new FlightReservationPage(NgDriver);

            //action
            _flightReservationPage.FlightDeleteButton.Click();
            Thread.Sleep(1000);
            NgDriver.SwitchTo().Alert().Accept();

            //assert
            NgDriver.Url.Should().Contain("/flightReservation");
        }

    }
}
