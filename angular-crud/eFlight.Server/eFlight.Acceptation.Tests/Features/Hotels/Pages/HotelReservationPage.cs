using eFlight.Acceptation.Tests.Components;
using OpenQA.Selenium;
using Protractor;
using SeleniumExtras.PageObjects;

namespace eFlight.Acceptation.Tests.Features.Hotels.Pages
{
    public class HotelReservationPage : PageComponents
    {
        #region Selectors
        [FindsBy(How = How.XPath, Using = "/html/body/flight-app/div/div[2]/div/flight/div[2]/table/tbody/tr[1]/td[5]/a[3]")]
        public IWebElement HotelReservationCreateButton { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/flight-app/div/div[2]/div/app-hotel-reservation/div[2]/table/tbody/tr/td[5]/a[3]")]
        public IWebElement HotelDeleteButton { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/flight-app/div/div[2]/div/app-hotel-reservation/div[2]/table/tbody/tr/td[5]/a[1]")]
        public IWebElement HotelReservationOpenButton { get; set; }
        #endregion

        public HotelReservationPage(NgWebDriver ngDriver) : base(ngDriver) { }
    }
}
