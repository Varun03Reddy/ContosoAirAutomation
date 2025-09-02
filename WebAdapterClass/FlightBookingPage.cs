using InterfaceClass;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using Utilities;

namespace WebAdapterClass
{
    /// <summary>
    /// This class provides an implementation of the flight booking functionality 
    /// on the ContosoAir website. It interacts with web elements for login, 
    /// selecting flight details, booking flights, and closing the browser session.
    /// </summary>
    public class FlightBookingPage : IFlightBooking
    {
        private IWebDriver driver;

        /// <summary>
        /// Initializes the FlightBookingPage with a WebDriver instance.
        /// </summary>
        /// <param name="driver">The WebDriver instance for interacting with the web application.</param>
        public FlightBookingPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// Logs in to the ContosoAir website using the provided username and password.
        /// </summary>
        public void Login(string username, string password)
        {
            driver.Navigate().GoToUrl(ConfigManager.GetAppUrl());
            driver.Manage().Window.Size = new System.Drawing.Size(1296, 688);

            SeleniumHelpers.ClickElement(driver, By.LinkText("Login"));
            SeleniumHelpers.EnterText(driver, By.Id("username"), username);
            SeleniumHelpers.EnterText(driver, By.Id("password"), password);
            SeleniumHelpers.ClickElement(driver, By.CssSelector(".btn"));
        }

        /// <summary>
        /// Selects flight details including departure and arrival airports, 
        /// departure and return dates, and the number of passengers.
        /// </summary>
        public void SelectFlightDetails(string from, string to, DateTime departureDate, int passengers, DateTime returnDate)
        {
            SeleniumHelpers.ClickElement(driver, By.LinkText("Book"));

            SeleniumHelpers.SelectDropdownByText(driver, By.Id("fromCode"), from);
            Thread.Sleep(1000);
            SeleniumHelpers.SelectDropdownByText(driver, By.Id("toCode"), to);
            Thread.Sleep(1000);

            // Departure Date
            SeleniumHelpers.ClickElement(driver, By.Id("dpa"));
            var departureCell = WaitHelper.WaitForElement(driver, By.XPath($"//td[contains(text(), '{departureDate.Day}')]"));
            departureCell.Click();

            // Passengers
            SeleniumHelpers.SelectDropdownByText(driver, By.Id("passengers"), passengers.ToString());

            // Return Date
            SeleniumHelpers.ClickElement(driver, By.Id("dpb"));
            var returnCell = WaitHelper.WaitForElement(driver, By.XPath($"//td[contains(text(), '{returnDate.Day}')]"));
            returnCell.Click();
        }

        /// <summary>
        /// Books a flight by selecting available options and completing the booking process.
        /// </summary>
        public void BookFlight()
        {
            SeleniumHelpers.ClickElement(driver, By.CssSelector(".btn-md"));
            SeleniumHelpers.ClickElement(driver, By.CssSelector(".row:nth-child(3) .block-flights-results-list-item:nth-child(2) .big-blue-radio"));
            SeleniumHelpers.ClickElement(driver, By.CssSelector(".btn"));
            SeleniumHelpers.ClickElement(driver, By.CssSelector(".btn:nth-child(5)"));
            SeleniumHelpers.ClickElement(driver, By.CssSelector(".block-booking-title"));
            SeleniumHelpers.ClickElement(driver, By.CssSelector(".block-booking-passenger"));
        }

        /// <summary>
        /// Closes the browser session.
        /// </summary>
        public void Close()
        {
            driver.Quit();
        }
    }
}