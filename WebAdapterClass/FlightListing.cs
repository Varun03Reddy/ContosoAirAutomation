/*
 * Copyright (c) 2025 Arpita
 * All rights reserved.
 *
 * This source code is licensed under the terms specified by the owner.
 */
using InterfaceClass; // ISP: Only flight listing-related methods are used from the interface
using OpenQA.Selenium; // Selenium WebDriver for browser automation
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities; // ✅ Utilities for SeleniumHelpers, WaitHelper, DriverFactory, ConfigManager

namespace WebAdapterClass
{
    /// <summary>
    /// Class for performing flight listing functionalities, including login and searching for available flights.
    /// Implements IFlightListing interface.
    /// </summary>
    public class FlightListingPage : IFlightListing
    {
        private IWebDriver driver; // DIP: Depend on abstraction (IWebDriver)

        /// <summary>
        /// Constructor initializes WebDriver using a factory method.
        /// </summary>
        public FlightListingPage()
        {
            driver = DriverFactory.CreateDriver("chrome"); // ✅ Factory pattern: centralized driver creation
        }

        /// <summary>
        /// Logs in to the ContosoAir website using the provided username and password.
        /// </summary>
        public void Login(string username, string password)
        {
            driver.Navigate().GoToUrl(ConfigManager.GetAppUrl()); // ✅ ConfigManager provides app URL
            driver.Manage().Window.Size = new System.Drawing.Size(1296, 688);

            // Click Login link and fill credentials
            SeleniumHelpers.ClickElement(driver, By.LinkText("Login")); // ✅ Reusable helper method
            SeleniumHelpers.EnterText(driver, By.Id("username"), username);
            SeleniumHelpers.EnterText(driver, By.Id("password"), password);
            SeleniumHelpers.ClickElement(driver, By.CssSelector(".btn")); // Submit login form
        }

        /// <summary>
        /// Searches flights by selecting departure/arrival, dates, and passengers.
        /// </summary>
        public void SearchFlights(string from, string to, DateTime departureDate, int passengers, DateTime returnDate)
        {
            SeleniumHelpers.ClickElement(driver, By.LinkText("Book")); // Navigate to booking page

            // Select departure and destination
            SeleniumHelpers.SelectDropdownByText(driver, By.Id("fromCode"), from);
            SeleniumHelpers.SelectDropdownByText(driver, By.Id("toCode"), to);

            // Departure date selection
            SeleniumHelpers.ClickElement(driver, By.Id("dpa"));
            var departureDateCell = WaitHelper.WaitForElement(driver, By.XPath($"//td[contains(text(), '{departureDate.Day}')]"));
            departureDateCell.Click();

            // Select number of passengers
            SeleniumHelpers.SelectDropdownByText(driver, By.Id("passengers"), passengers.ToString());

            // Return date selection
            SeleniumHelpers.ClickElement(driver, By.Id("dpb"));
            var returnDateCell = WaitHelper.WaitForElement(driver, By.XPath($"//td[contains(text(), '{returnDate.Day}')]"));
            returnDateCell.Click();

            // Click Find Flights button
            SeleniumHelpers.ClickElement(driver, By.XPath("/html/body/main/section/div/div/div[3]/div/form/fieldset/button"));
        }

        /// <summary>
        /// Returns a list of available flight elements on the page.
        /// </summary>
        public List<IWebElement> ListAvailableFlights()
        {
            var flightListings = driver.FindElements(By.CssSelector(".block-flights-results-list-item")).ToList();
            if (flightListings.Count == 0)
                Console.WriteLine("No flights available."); // Logging if no flights found
            return flightListings;
        }

        /// <summary>
        /// Closes the WebDriver and browser session.
        /// </summary>
        public void Close()
        {
            driver.Quit(); // SRP: Responsible only for cleanup of this page object
        }
    }
}
