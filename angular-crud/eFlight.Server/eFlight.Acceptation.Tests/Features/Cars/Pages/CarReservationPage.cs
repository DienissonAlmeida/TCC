using eFlight.Acceptation.Tests.Base;
using eFlight.Acceptation.Tests.Components;
using eFlight.Acceptation.Tests.Extensions;
using eFlight.Acceptation.Tests.Pages;
using OpenQA.Selenium;
using Protractor;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Acceptation.Tests.Features.Cars.Pages
{
    public class CarReservationPage : PageComponents
    {
        #region Selectors
        [FindsBy(How = How.XPath, Using = "/html/body/flight-app/div/div[2]/div/flight/div[2]/table/tbody/tr[1]/td[5]/a[3]")]
        public IWebElement CarReservationCreateButton { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/flight-app/div/div[2]/div/app-car-reservation/div[2]/table/tbody/tr/td[5]/a[3]")]
        public IWebElement CarDeleteButton { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/flight-app/div/div[2]/div/app-car-reservation/div[2]/table/tbody/tr/td[5]/a[1]")]
        public IWebElement CarReservationOpenButton { get; set; }
        #endregion

        public CarReservationPage(NgWebDriver ngDriver) : base(ngDriver) { }
    }
}
