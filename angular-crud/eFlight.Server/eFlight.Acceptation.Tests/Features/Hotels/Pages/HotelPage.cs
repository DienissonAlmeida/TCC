using eFlight.Acceptation.Tests.Components;
using OpenQA.Selenium;
using Protractor;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Acceptation.Tests.Features.Hotels.Pages
{
    public class HotelPage : PageComponents
    {
        #region Selectors
        [FindsBy(How = How.XPath, Using = "/html/body/flight-app/div/div[2]/div/hotel/div[2]/table/tbody/tr[1]/td[6]/a[3]")]
        public IWebElement HotelReservationCreateButton { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/flight-app/div/div[2]/div/hotel/div[2]/table/tbody/tr[1]/td[6]/a[1]")]
        public IWebElement HotelReservationViewButton { get; set; }

        [FindsBy(How = How.Id, Using = "customer-list-actions-open")]
        public IWebElement HotelOpenButton { get; set; }
        #endregion

        public HotelPage(NgWebDriver ngDriver) : base(ngDriver) { }
    }
}
