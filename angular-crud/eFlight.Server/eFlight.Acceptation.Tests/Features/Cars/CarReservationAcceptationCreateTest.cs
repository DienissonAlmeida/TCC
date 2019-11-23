using eFlight.Acceptation.Tests.Base;
using eFlight.Acceptation.Tests.Features.Cars.Pages;
using eFlight.Acceptation.Tests.Pages;
using eFlight.Tests.Common.Features.Cars;
using FluentAssertions;
using System.Threading;
using Xunit;

namespace eFlight.Acceptation.Tests.Features.Cars
{
    [Collection("acceptation collection")]
    public class CarReservationAcceptationCreateTest : BaseTests
    {
        private CarPage _carPage;
        private CarReservationPage _carReservationPage;
        private CarReservationFormPage _carReservationFormPage;

        public CarReservationAcceptationCreateTest()
        {
            string urlToGo = SetupTest._acceptanceTestSettings.BaseClientUrl + "home";

            var homePage = new HomePage(NgDriver);
            //var subMenusPage = new CustomerSubMenuComponent(NgDriver);

            _carPage = new CarPage(NgDriver);
            //_flightReservationPage = new FlightReservationPage(NgDriver);
            _carReservationFormPage = new CarReservationFormPage(NgDriver);

            //NgDriver.Navigate().GoToUrl(urlToGo);

            //homePage.MainMenu.WaitUntilBeVisibleAndClickOnIt(NgDriver);

            homePage.CarItem.Click();
            //subMenusPage.CustomersSubMenu.Click();

        }

        [Fact]
        public void Deveria_Salvar_Reserva_Carro_com_sucesso()
        {
            //Arrange
            _carPage.CarReservationCreateButton.Click();

            var command = CarReservationRegisterCommandBuilder.Start().Build();
            _carReservationFormPage.FillData(command);

            //act
            _carReservationFormPage.DefaultButtonsComponent.SaveButton.Click();
            Thread.Sleep(1000);
            NgDriver.SwitchTo().Alert().Accept();

            //assert
            NgDriver.Url.Should().Contain("/cars");
            //_flightReservationPage.GenericGridComponent.HasAnyRow(2, command.Description).Should().BeTrue();
        }

        [Fact]
        public void Deveria_editar_Reserva_Carro_com_sucesso()
        {
            _carPage.CarReservationViewButton.Click();
            _carReservationPage = new CarReservationPage(NgDriver);

            //action
            _carReservationPage.CarReservationOpenButton.Click();
            _carReservationFormPage.ClearData();
            var command = CarReservationRegisterCommandBuilder.Start().WithName("Atualizacao de reserva de voo").Build();
            _carReservationFormPage.FillData(command);
            _carReservationFormPage.DefaultButtonsComponent.SaveButton.Click();
            Thread.Sleep(1000);
            NgDriver.SwitchTo().Alert().Accept();

            //assert
            NgDriver.Url.Should().Contain("/cars");
        }

        [Fact]
        public void Deveria_deletar_Reserva_Carro_com_sucesso()
        {
            _carPage.CarReservationViewButton.Click();
            _carReservationPage = new CarReservationPage(NgDriver);

            //action
            _carReservationPage.CarDeleteButton.Click();
            Thread.Sleep(1000);
            NgDriver.SwitchTo().Alert().Accept();

            //assert
            NgDriver.Url.Should().Contain("/carReservation");
        }
    }
}
