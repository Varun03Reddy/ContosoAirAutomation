/*
 * Copyright (c) 2025 Keyur
 * All rights reserved.
 *
 * This source code is licensed under the terms specified by the owner.
 */
using OpenQA.Selenium; // Selenium WebDriver for browser automation
using OpenQA.Selenium.Support.UI; // For WebDriverWait functionality
using System;
using System.Collections.Generic;
using InterfaceClass; // Interface segregation principle: IBookedFlightHistory defines only necessary methods
using Utilities;  // Utility helper class for reusable WebDriver actions

namespace WebAdapterClass
{
    /// <summary>
    /// Implementation of the IBookedFlightHistory interface for interacting with booked flights.
    /// Uses Selenium WebDriver to automate interactions with the web application.
    /// </summary>
    public class BookedFlightHistory : IBookedFlightHistory
    {
        private readonly IWebDriver _driver; // Dependency Inversion Principle (DIP): class depends on abstraction (IWebDriver)
        private readonly WebDriverWait _wait; // Used for explicit waits in Selenium
        private readonly WebDriverHelper _helper; // SRP: helper class encapsulates reusable WebDriver actions

        /// <summary>
        /// Initializes a new instance of the BookedFlightHistory class.
        /// Initializes WebDriver and WebDriverWait for Selenium automation.
        /// </summary>
        public BookedFlightHistory()
        {
            _driver = DriverFactory.CreateDriver("chrome"); // ✅ Factory pattern: centralized driver creation
            _driver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // Explicit wait for element interactions
            _helper = new WebDriverHelper(_driver); // SRP: Helper class handles common Selenium operations
        }

        /// <summary>
        /// Gets the current WebDriver instance.
        /// LSP: Exposing the driver allows tests to work with any IWebDriver implementation.
        /// </summary>
        public IWebDriver Driver => _driver;

        /// <summary>
        /// Navigate to the login page.
        /// </summary>
        public void NavigateToLoginPage()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/"); // Open homepage
            var loginButton = _wait.Until(driver => driver.FindElement(
                By.XPath("/html/body/navbar/nav/div/div[2]/div[2]/ul/li[2]/a")));
            loginButton.Click(); // Click login button
        }

        /// <summary>
        /// Perform login with provided credentials.
        /// </summary>
        public void Login(string username, string password)
        {
            _helper.EnterText(By.Id("username"), username); // Enter username
            _helper.EnterText(By.Id("password"), password); // Enter password
            _helper.ClickElement(By.XPath("/html/body/main/section/div/div/div[3]/div/form/fieldset/button")); // Click login

            // Wait until login is successful and user is redirected
            _wait.Until(driver => driver.FindElement(By.XPath("/html/body/navbar/nav/div/div[1]/span/a")));
        }

        /// <summary>
        /// Navigate to "My Booked Flights" page.
        /// </summary>
        public void NavigateToMyBookedFlightsPage()
        {
            _helper.ClickElement(By.XPath("/html/body/navbar/nav/div/div[2]/div[2]/ul/li[2]/a")); // Click My Booked Flights
        }

        /// <summary>
        /// Get a list of booked flights.
        /// </summary>
        public IList<string> GetBookedFlights()
        {
            var flightListings = _wait.Until(driver => driver.FindElements(
                By.XPath("/html/body/main/div/div/section/form/div[1]/div/ul")));
            var flightDetails = new List<string>();

            foreach (var listing in flightListings)
            {
                flightDetails.Add(listing.Text); // Extract flight details text
            }

            return flightDetails; // Return all booked flights
        }

        /// <summary>
        /// View flight details for a specific flight index.
        /// </summary>
        public void ViewFlightDetails(int flightIndex)
        {
            var flightListings = _driver.FindElements(By.XPath("/html/body/main/div/div/section/form/div[1]/div/ul"));

            if (flightIndex < 0 || flightIndex >= flightListings.Count)
                throw new ArgumentOutOfRangeException(nameof(flightIndex), "Invalid flight index.");

            // Placeholder: In future, could click "View Details" button for the flight
            // SRP: This method focuses only on selecting flight by index
        }

        /// <summary>
        /// Shop for another flight from the booked flights page.
        /// </summary>
        public void ShopForAnotherFlight()
        {
            _helper.ClickElement(By.XPath("/html/body/main/div/div/section/a")); // Click link to shop for another flight
        }

        /// <summary>
        /// Get another flight from the booked flights page.
        /// </summary>
        public void GetAnotherFlight()
        {
            var getAnotherFlightButton = _wait.Until(driver => driver.FindElement(
                By.XPath("/html/body/main/div/div/section/form/div[2]/a")));
            getAnotherFlightButton.Click(); // Click "Get Another Flight"
        }

        /// <summary>
        /// Logout from the application.
        /// </summary>
        public void Logout()
        {
            _helper.ClickElement(By.XPath("//a[contains(text(), 'Logout')]")); // Click logout link
        }

        /// <summary>
        /// Cleanup WebDriver and browser session.
        /// </summary>
        public void Cleanup()
        {
            _driver.Quit(); // Close browser and release resources
        }
    }
}
