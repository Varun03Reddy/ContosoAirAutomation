using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using InterfaceClass;
using Utilities;  // ✅ Added utilities

namespace WebAdapterClass
{
    /// <summary>
    /// Implementation of the IBookedFlightHistory interface for interacting with the booked flights.
    /// Uses Selenium WebDriver to automate the interaction with the web application.
    /// </summary>
    public class BookedFlightHistory : IBookedFlightHistory
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly WebDriverHelper _helper; // ✅ Utilities helper

        /// <summary>
        /// Initializes a new instance of the BookedFlightHistory class.
        /// Initializes WebDriver and WebDriverWait for Selenium automation.
        /// </summary>
        public BookedFlightHistory()
        {
            _driver = DriverFactory.CreateDriver("chrome"); // ✅ Using DriverFactory
            _driver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _helper = new WebDriverHelper(_driver); // ✅ initialize helper
        }

        /// <summary>
        /// Gets the current WebDriver instance.
        /// </summary>
        public IWebDriver Driver => _driver;

        public void NavigateToLoginPage()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/");
            var loginButton = _wait.Until(driver => driver.FindElement(By.XPath("/html/body/navbar/nav/div/div[2]/div[2]/ul/li[2]/a")));
            loginButton.Click();
        }

        public void Login(string username, string password)
        {
            _helper.EnterText(By.Id("username"), username);
            _helper.EnterText(By.Id("password"), password);
            _helper.ClickElement(By.XPath("/html/body/main/section/div/div/div[3]/div/form/fieldset/button"));

            _wait.Until(driver => driver.FindElement(By.XPath("/html/body/navbar/nav/div/div[1]/span/a")));
        }

        public void NavigateToMyBookedFlightsPage()
        {
            _helper.ClickElement(By.XPath("/html/body/navbar/nav/div/div[2]/div[2]/ul/li[2]/a"));
        }

        public IList<string> GetBookedFlights()
        {
            var flightListings = _wait.Until(driver => driver.FindElements(By.XPath("/html/body/main/div/div/section/form/div[1]/div/ul")));
            var flightDetails = new List<string>();

            foreach (var listing in flightListings)
            {
                flightDetails.Add(listing.Text);
            }

            return flightDetails;
        }

        public void ViewFlightDetails(int flightIndex)
        {
            var flightListings = _driver.FindElements(By.XPath("/html/body/main/div/div/section/form/div[1]/div/ul"));

            if (flightIndex < 0 || flightIndex >= flightListings.Count)
                throw new ArgumentOutOfRangeException(nameof(flightIndex), "Invalid flight index.");

            // keep placeholder if view details button is required later
        }

        public void ShopForAnotherFlight()
        {
            _helper.ClickElement(By.XPath("/html/body/main/div/div/section/a"));
        }

        public void GetAnotherFlight()
        {
            var getAnotherFlightButton = _wait.Until(driver => driver.FindElement(By.XPath("/html/body/main/div/div/section/form/div[2]/a")));
            getAnotherFlightButton.Click();
        }

        public void Logout()
        {
            _helper.ClickElement(By.XPath("//a[contains(text(), 'Logout')]"));
        }

        public void Cleanup()
        {
            _driver.Quit();
        }
    }
}