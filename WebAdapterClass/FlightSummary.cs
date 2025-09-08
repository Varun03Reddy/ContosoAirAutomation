/*
 * Copyright (c) 2025 Varun Reddy
 * All rights reserved.
 *
 * This source code is licensed under the terms specified by the owner.
 */
using System;
using InterfaceClass; // Interface segregation: IFlightSummary contains only flight summary-related methods
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
        private readonly IWebDriver driver; // DIP: Use abstraction for WebDriver

        /// <summary>
        /// Initializes FlightSummary with a WebDriver instance.
        /// </summary>
        /// <param name="webDriver">Injected WebDriver instance (LSP, DIP)</param>
        public FlightSummary(IWebDriver webDriver)
        {
            driver = webDriver ?? throw new ArgumentNullException(nameof(webDriver));
        }

        /// <summary>
        /// Navigate to the application URL
        /// </summary>
        /// <param name="url">Application base URL</param>
        public void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Perform login with provided username and password
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        public void PerformLogin(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Username and password cannot be null or empty");

            // Click login button
            driver.FindElement(By.LinkText("Login")).Click();

            // Enter credentials
            driver.FindElement(By.Id("username")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);

            // Submit login form
            driver.FindElement(By.CssSelector(".btn")).Click();
        }

        /// <summary>
        /// Book a flight with predefined details (SRP: Flight booking logic encapsulated)
        /// </summary>
        public void BookFlight()
        {
            driver.FindElement(By.LinkText("Book")).Click();

            // Select Destination
            var toDropdown = driver.FindElement(By.Id("toCode"));
            toDropdown.FindElement(By.XPath("//option[. = 'Kabri Dar ABK']")).Click();

            // Select Origin
            var fromDropdown = driver.FindElement(By.Id("fromCode"));
            fromDropdown.FindElement(By.XPath("//option[. = 'Novorossiysk AAQ']")).Click();

            // Select Return Date
            driver.FindElement(By.Id("dpb")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement dateElement = wait.Until(drv => drv.FindElement(By.CssSelector("tr:nth-child(5) > .day:nth-child(6)")));
            dateElement.Click();

            // Select Departure Date
            driver.FindElement(By.Id("dpa")).Click();
            driver.FindElement(By.CssSelector("tr:nth-child(4) > .day:nth-child(5)")).Click();

            // Search + Select Flight
            driver.FindElement(By.CssSelector(".btn-md")).Click();
            driver.FindElement(By.CssSelector(".row:nth-child(3) .block-flights-results-list-item:nth-child(3) .big-blue-radio")).Click();
            driver.FindElement(By.CssSelector(".btn")).Click();

            // Passenger Details
            driver.FindElement(By.CssSelector(".block-booking-passenger")).Click();
            driver.FindElement(By.CssSelector(".btn:nth-child(5)")).Click();
        }

        /// <summary>
        /// Validate the passenger name (SRP: single responsibility for passenger verification)
        /// </summary>
        public void checkPassengerName()
        {
            BookFlight(); // Reuse booking logic (DRY)
            // TODO: Extract actual passenger name element for validation
        }

        /// <summary>
        /// Cancel a booking (SRP: separate responsibility for booking cancellation)
        /// </summary>
        public void checkCancelBooking()
        {
            driver.FindElement(By.LinkText("Book")).Click();

            // Select Destination
            var toDropdown = driver.FindElement(By.Id("toCode"));
            toDropdown.FindElement(By.XPath("//option[. = 'Winisk YMO']")).Click();

            // Select Origin
            var fromDropdown = driver.FindElement(By.Id("fromCode"));
            fromDropdown.FindElement(By.XPath("//option[. = 'Teniente R. Marsh TNM']")).Click();

            // Select Return Date
            driver.FindElement(By.Id("dpb")).Click();
            driver.FindElement(By.CssSelector("tr:nth-child(6) > .day:nth-child(2)")).Click();

            // Select Departure Date
            driver.FindElement(By.Id("dpa")).Click();
            driver.FindElement(By.CssSelector("tr:nth-child(4) > .day:nth-child(6)")).Click();

            // Select number of Passengers
            driver.FindElement(By.Id("passengers")).Click();
            driver.FindElement(By.XPath("//option[. = '2']")).Click();

            // Select Flights
            driver.FindElement(By.CssSelector(".btn-md")).Click();
            driver.FindElement(By.CssSelector(".row:nth-child(3) .block-flights-results-list-item:nth-child(6) .big-blue-radio")).Click();
            driver.FindElement(By.CssSelector(".row:nth-child(6) .block-flights-results-list-item:nth-child(6) .big-blue-radio")).Click();

            driver.FindElement(By.CssSelector(".btn")).Click();

            // Cancel Booking
            driver.FindElement(By.LinkText("Cancel")).Click();

            // Update passengers after cancellation
            driver.FindElement(By.Id("passengers")).Click();
            driver.FindElement(By.XPath("//option[. = '3']")).Click();
        }
    }
}
