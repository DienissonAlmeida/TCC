using eFlight.Acceptation.Tests.Components;
using eFlight.Application.Features.Flights.Commands;
using OpenQA.Selenium;
using Protractor;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Acceptation.Tests.Features.Flights.Pages
{
    public class FlightReservationFormPage : PageComponents
    {
        #region Selectors
        [FindsBy(How = How.XPath, Using = "/html/body/flight-app/div/div[2]/div/flight-reservation-form/div/div[2]/form/div[1]/input")]
        public IWebElement FlightReservationDescription { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/flight-app/div/div[2]/div/flight-reservation-form/div/div[2]/form/div[2]/input")]
        public IWebElement FlightReservationDate { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/flight-app/div/div[2]/div/flight-reservation-form/div/div[2]/form/div[3]/input")]
        public IWebElement FlightReservationReturn { get; set; }
        #endregion

        public FlightReservationFormPage(NgWebDriver ngDriver) : base(ngDriver) { }

        public void FillData(FlightReservationRegisterCommand command)
        {
            FlightReservationDescription.SendKeys(command.Description);

            FlightReservationDate.SendKeys(command.Date.GetDateTimeFormats()[50]);
            FlightReservationReturn.SendKeys(command.Date.GetDateTimeFormats()[50]);
        }
        public void ClearData()
        {
            FlightReservationDescription.Clear();
            FlightReservationDate.Clear();
            FlightReservationReturn.Clear();
        }
    }
}
