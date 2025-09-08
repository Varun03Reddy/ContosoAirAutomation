/*
 * Copyright (c) 2025 Vamsi Krishna
 * All rights reserved.
 *
 * This source code is licensed under the terms specified by the owner.
 */
using InterfaceClass; // Interface segregation: IFlightBooking contains only flight booking-related methods
using OpenQA.Selenium; // Selenium WebDriver for browser automation
using OpenQA.Selenium.Support.UI; // For interacting with dropdowns
using System;
using System.Threading; // Used for Thread.Sleep in waiting for elements (consider replacing with explicit waits)
using Utilities; // Helpers like SeleniumHelpers and WaitHelper

namespace WebAdapterClass
{
    /// <summary>
    /// This class provides an implementation of the flight booking functionality 
    /// on the ContosoAir website. It interacts with web elements for login, 
    /// selecting flight details, booking flights, and closing the browser session.
    /// </summary>
    public class FlightBookingPage : IFlightBooking // DIP: Depends on interface, not concrete class
    {
        private IWebDriver driver; // WebDriver abstraction for interacting with the browser

        /// <summary>
        /// Initializes the FlightBookingPage with a WebDriver instance.
        /// </summary>
        /// <param name="driver">The WebDriver instance for interacting with the web application.</param>
        public FlightBookingPage(IWebDriver driver)
        {
            this.driver = driver; // LSP: Any WebDriver implementation (ChromeDriver, FirefoxDriver) can be used
        }

        /// <summary>
        /// Logs in to the ContosoAir website using the provided username and password.
        /// </summary>
        public void Login(string username, string password)
        {
            driver.Navigate().GoToUrl(ConfigManager.GetAppUrl()); // Navigate to app URL
            driver.Manage().Window.Size = new System.Drawing.Size(1296, 688); // Set consistent window size

            // SRP: Encapsulates the login actions
            SeleniumHelpers.ClickElement(driver, By.LinkText("Login")); // Click login link
            SeleniumHelpers.EnterText(driver, By.Id("username"), username); // Enter username
            SeleniumHelpers.EnterText(driver, By.Id("password"), password); // Enter password
            SeleniumHelpers.ClickElement(driver, By.CssSelector(".btn")); // Submit login form
        }

        /// <summary>
        /// Selects flight details including departure and arrival airports, 
        /// departure and return dates, and the number of passengers.
        /// </summary>
        public void SelectFlightDetails(string from, string to, DateTime departureDate, int passengers, DateTime returnDate)
        {
            SeleniumHelpers.ClickElement(driver, By.LinkText("Book")); // Navigate to booking page

            // Select departure and arrival airports from dropdowns
            SeleniumHelpers.SelectDropdownByText(driver, By.Id("fromCode"), from);
            Thread.Sleep(1000); // Temporary wait to ensure dropdown loads
            SeleniumHelpers.SelectDropdownByText(driver, By.Id("toCode"), to);
            Thread.Sleep(1000);

            // Departure Date selection
            SeleniumHelpers.ClickElement(driver, By.Id("dpa")); // Open departure date picker
            var departureCell = WaitHelper.WaitForElement(driver, By.XPath($"//td[contains(text(), '{departureDate.Day}')]"));
            departureCell.Click(); // Select the departure date

            // Select number of passengers
            SeleniumHelpers.SelectDropdownByText(driver, By.Id("passengers"), passengers.ToString());

            // Return Date selection
            SeleniumHelpers.ClickElement(driver, By.Id("dpb")); // Open return date picker
            var returnCell = WaitHelper.WaitForElement(driver, By.XPath($"//td[contains(text(), '{returnDate.Day}')]"));
            returnCell.Click(); // Select the return date
        }

        /// <summary>
        /// Books a flight by selecting available options and completing the booking process.
        /// </summary>
        public void BookFlight()
        {
            // Step-by-step clicks to simulate booking flow
            SeleniumHelpers.ClickElement(driver, By.CssSelector(".btn-md")); // Continue to flight selection
            SeleniumHelpers.ClickElement(driver, By.CssSelector(".row:nth-child(3) .block-flights-results-list-item:nth-child(2) .big-blue-radio")); // Select flight
            SeleniumHelpers.ClickElement(driver, By.CssSelector(".btn")); // Continue
            SeleniumHelpers.ClickElement(driver, By.CssSelector(".btn:nth-child(5)")); // Next step
            SeleniumHelpers.ClickElement(driver, By.CssSelector(".block-booking-title")); // Confirm booking title
            SeleniumHelpers.ClickElement(driver, By.CssSelector(".block-booking-passenger")); // Confirm passenger info

            // SRP: All actions related to flight booking are encapsulated in this method
        }

        /// <summary>
        /// Closes the browser session.
        /// </summary>
        public void Close()
        {
            driver.Quit(); // SRP: Responsible for cleanup of browser session
        }
    }
}
