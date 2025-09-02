using System;
using InterfaceClass;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebAdapterClass
{
    /// <summary>
    /// Implements IFlightSummary and provides functionality 
    /// for interacting with the flight booking application.
    /// </summary>
    public class FlightSummary : IFlightSummary
    {
        private readonly IWebDriver driver;

        public FlightSummary(IWebDriver webDriver)
        {
            driver = webDriver ?? throw new ArgumentNullException(nameof(webDriver));
        }

        /// <summary>
        /// Navigate to the application URL
        /// </summary>
        public void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Login to the application
        /// </summary>
        public void PerformLogin(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Username and password cannot be null or empty");

            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("username")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.CssSelector(".btn")).Click();
        }

        /// <summary>
        /// Book a flight
        /// </summary>
        public void BookFlight()
        {
            driver.FindElement(By.LinkText("Book")).Click();

            // Destination
            var toDropdown = driver.FindElement(By.Id("toCode"));
            toDropdown.FindElement(By.XPath("//option[. = 'Kabri Dar ABK']")).Click();

            // Origin
            var fromDropdown = driver.FindElement(By.Id("fromCode"));
            fromDropdown.FindElement(By.XPath("//option[. = 'Novorossiysk AAQ']")).Click();

            // Dates
            driver.FindElement(By.Id("dpb")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement dateElement = wait.Until(drv => drv.FindElement(By.CssSelector("tr:nth-child(5) > .day:nth-child(6)")));
            dateElement.Click();
            driver.FindElement(By.Id("dpa")).Click();
            driver.FindElement(By.CssSelector("tr:nth-child(4) > .day:nth-child(5)")).Click();

            // Search + select flight
            driver.FindElement(By.CssSelector(".btn-md")).Click();
            driver.FindElement(By.CssSelector(".row:nth-child(3) .block-flights-results-list-item:nth-child(3) .big-blue-radio")).Click();
            driver.FindElement(By.CssSelector(".btn")).Click();

            // Passenger details
            driver.FindElement(By.CssSelector(".block-booking-passenger")).Click();
            driver.FindElement(By.CssSelector(".btn:nth-child(5)")).Click();
        }

        /// <summary>
        /// Check passenger name (matches interface exactly)
        /// </summary>
        public void checkPassengerName()
        {
            BookFlight(); // Reuse booking logic
            // TODO: Extract actual passenger name element for validation
        }

        /// <summary>
        /// Check cancel booking (matches interface exactly)
        /// </summary>
        public void checkCancelBooking()
        {
            driver.FindElement(By.LinkText("Book")).Click();

            // Destination
            var toDropdown = driver.FindElement(By.Id("toCode"));
            toDropdown.FindElement(By.XPath("//option[. = 'Winisk YMO']")).Click();

            // Origin
            var fromDropdown = driver.FindElement(By.Id("fromCode"));
            fromDropdown.FindElement(By.XPath("//option[. = 'Teniente R. Marsh TNM']")).Click();

            // Dates
            driver.FindElement(By.Id("dpb")).Click();
            driver.FindElement(By.CssSelector("tr:nth-child(6) > .day:nth-child(2)")).Click();
            driver.FindElement(By.Id("dpa")).Click();
            driver.FindElement(By.CssSelector("tr:nth-child(4) > .day:nth-child(6)")).Click();

            // Passengers
            driver.FindElement(By.Id("passengers")).Click();
            driver.FindElement(By.XPath("//option[. = '2']")).Click();

            // Select flights
            driver.FindElement(By.CssSelector(".btn-md")).Click();
            driver.FindElement(By.CssSelector(".row:nth-child(3) .block-flights-results-list-item:nth-child(6) .big-blue-radio")).Click();
            driver.FindElement(By.CssSelector(".row:nth-child(6) .block-flights-results-list-item:nth-child(6) .big-blue-radio")).Click();

            driver.FindElement(By.CssSelector(".btn")).Click();

            // Cancel booking
            driver.FindElement(By.LinkText("Cancel")).Click();

            driver.FindElement(By.Id("passengers")).Click();
            driver.FindElement(By.XPath("//option[. = '3']")).Click();
        }
    }
}