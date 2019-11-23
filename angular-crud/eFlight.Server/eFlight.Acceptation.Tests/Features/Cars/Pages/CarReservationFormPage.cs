using eFlight.Acceptation.Tests.Components;
using eFlight.Application.Features.Cars.Commands;
using eFlight.Application.Features.Flights.Commands;
using OpenQA.Selenium;
using Protractor;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Acceptation.Tests.Features.Cars.Pages
{
    public class CarReservationFormPage : PageComponents
    {
        #region Selectors
        [FindsBy(How = How.XPath, Using = "/html/body/flight-app/div/div[2]/div/car-reservation-form/div/div[2]/form/div[1]/input")]
        public IWebElement CarReservationDescription { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/flight-app/div/div[2]/div/car-reservation-form/div/div[2]/form/div[2]/input")]
        public IWebElement CarReservationDate { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/flight-app/div/div[2]/div/car-reservation-form/div/div[2]/form/div[3]/input")]
        public IWebElement CarReservationReturn { get; set; }
        #endregion

        public CarReservationFormPage(NgWebDriver ngDriver) : base(ngDriver) { }

        public void FillData(CarReservationRegisterCommand command)
        {
            CarReservationDescription.SendKeys(command.Description);

            CarReservationDate.SendKeys(command.InputDate.GetDateTimeFormats()[50]);
            CarReservationReturn.SendKeys(command.OutputDate.GetDateTimeFormats()[50]);
        }
        public void ClearData()
        {
            CarReservationDescription.Clear();
            CarReservationDate.Clear();
            CarReservationReturn.Clear();
        }
    }
}
