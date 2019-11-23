using eFlight.Acceptation.Tests.Components;
using OpenQA.Selenium;
using Protractor;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Acceptation.Tests.Features.Flights.Pages
{
    public class FlightPage : PageComponents
    {
        #region Selectors
        [FindsBy(How = How.XPath, Using = "/html/body/flight-app/div/div[2]/div/flight/div[2]/table/tbody/tr[1]/td[5]/a[3]")]
        public IWebElement FlightReservationCreateButton { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/flight-app/div/div[2]/div/flight/div[2]/table/tbody/tr[1]/td[5]/a[1]")]
        public IWebElement FlightReservationViewButton { get; set; }

        [FindsBy(How = How.Id, Using = "customer-list-actions-open")]
        public IWebElement CustomerOpenButton { get; set; }
        #endregion

        public FlightPage(NgWebDriver ngDriver) : base(ngDriver) { }
    }
}
