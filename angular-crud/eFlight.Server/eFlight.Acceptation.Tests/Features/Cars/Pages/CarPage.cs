using eFlight.Acceptation.Tests.Components;
using OpenQA.Selenium;
using Protractor;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Acceptation.Tests.Features.Cars.Pages
{
    public class CarPage : PageComponents
    {
        #region Selectors
        [FindsBy(How = How.XPath, Using = "/html/body/flight-app/div/div[2]/div/car/div[2]/table/tbody/tr[1]/td[5]/a[3]")]
        public IWebElement CarReservationCreateButton { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/flight-app/div/div[2]/div/car/div[2]/table/tbody/tr[1]/td[5]/a[1]")]
        public IWebElement CarReservationViewButton { get; set; }

        #endregion

        public CarPage(NgWebDriver ngDriver) : base(ngDriver) { }
    }
}
