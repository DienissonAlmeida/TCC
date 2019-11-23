using eFlight.Acceptation.Tests.Components;
using eFlight.Application.Features.Cars.Commands;
using eFlight.Application.Features.Flights.Commands;
using eFlight.Application.Features.Hotels.Commands;
using OpenQA.Selenium;
using Protractor;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Acceptation.Tests.Features.Hotels.Pages
{
    public class HotelReservationFormPage : PageComponents
    {
        #region Selectors
        [FindsBy(How = How.XPath, Using = "/html/body/flight-app/div/div[2]/div/hotel-reservation-form/div/div[2]/form/div[1]/input")]
        public IWebElement HotelReservationDescription { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/flight-app/div/div[2]/div/hotel-reservation-form/div/div[2]/form/div[2]/input")]
        public IWebElement HotelReservationDate { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/flight-app/div/div[2]/div/hotel-reservation-form/div/div[2]/form/div[3]/input")]
        public IWebElement HotelReservationReturn { get; set; }
        #endregion

        public HotelReservationFormPage(NgWebDriver ngDriver) : base(ngDriver) { }

        public void FillData(HotelReservationRegisterCommand command)
        {
            HotelReservationDescription.SendKeys(command.Description);
            HotelReservationDate.SendKeys(command.InputDate.GetDateTimeFormats()[50]);
            HotelReservationReturn.SendKeys(command.OutputDate.GetDateTimeFormats()[50]);
        }
        public void ClearData()
        {
            HotelReservationDescription.Clear();
            HotelReservationDate.Clear();
            HotelReservationReturn.Clear();
        }
    }
}
