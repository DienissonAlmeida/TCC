using eFlight.Acceptation.Tests.Components;
using OpenQA.Selenium;
using Protractor;
using SeleniumExtras.PageObjects;

namespace eFlight.Acceptation.Tests.Features.Flights.Pages
{
    public class FlightReservationPage : PageComponents
    {
        #region Selectors
        [FindsBy(How = How.XPath, Using = "/html/body/flight-app/div/div[2]/div/flight/div[2]/table/tbody/tr[1]/td[5]/a[3]")]
        public IWebElement FlightReservationCreateButton { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/flight-app/div/div[2]/div/app-flight-reservation/div[2]/table/tbody/tr/td[5]/a[3]")]
        public IWebElement FlightDeleteButton { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/flight-app/div/div[2]/div/app-flight-reservation/div[2]/table/tbody/tr/td[5]/a[1]")]
        public IWebElement FlightReservationOpenButton { get; set; }
        #endregion

        public FlightReservationPage(NgWebDriver ngDriver) : base(ngDriver) { }
    }
}
