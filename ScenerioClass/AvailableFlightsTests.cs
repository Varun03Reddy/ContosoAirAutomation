/*
 * Copyright (c) 2025 Vamsi Krishna
 * All rights reserved.
 *
 * This source code is licensed under the terms specified by the owner.
 */
using InterfaceClass;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using Utilities;
using WebAdapterClass;

namespace ScenerioClass
{
    [TestFixture]
    public class AvailableFlightsTests
    {
        private IWebDriver driver;
        private IAvailableFlights availableFlightsPage;

        [SetUp]
        public void SetUp()
        {
            driver = DriverFactory.CreateDriver(ConfigManager.Browser);

            // SRP (Single Responsibility Principle):
            // FlightBookingPage is responsible only for login & flight selection,
            // keeping responsibilities separate from the AvailableFlightsPage.

            // OCP (Open/Closed Principle):
            // The system is open for extension (new booking flows) without modifying existing code.

            // DIP (Dependency Inversion Principle):
            // Code depends on abstractions (interfaces) instead of concrete implementations.

            // Navigate through login & booking flow to reach Available Flights page
            var flightBooking = new FlightBookingPage(driver);
            flightBooking.Login(ConfigManager.Username, ConfigManager.Password);
            flightBooking.SelectFlightDetails("Seisia ABM", "Egg Harbor City ACY",
                                              new DateTime(2025, 12, 20), 1,
                                              new DateTime(2025, 12, 25));

            // ISP (Interface Segregation Principle):
            // AvailableFlightsPage implements only the contract relevant to "Available Flights" 
            // via IAvailableFlights interface, avoiding unnecessary methods.

            availableFlightsPage = new AvailableFlightsPage(driver);
        }

        [Test]
        public void Test_DepartingFlightButton_ShouldHighlightOnClick()
        {
            string dateToSelect = "Tuesday Sep 23";

            // SRP: This test verifies only the highlighting functionality,
            // adhering to single responsibility.

            // Action: Try clicking the departing flight button
            availableFlightsPage.SelectDepartingFlightByDate(dateToSelect);

            // Expectation: It should be highlighted (with 'selected' class)
            var selectedDateElements = driver.FindElements(
                By.XPath($"//div[contains(@class,'available-flights')]//div[contains(text(),'{dateToSelect}') and contains(@class,'selected')]")
            );

            // LSP (Liskov Substitution Principle):
            // IWebDriver (ChromeDriver/FirefoxDriver) can be substituted here without breaking behavior.

            // Fail if not highlighted → bug (NUnit assert)
            Assert.IsTrue(selectedDateElements.Count > 0,
                $"BUG: The date '{dateToSelect}' was clicked but not highlighted as expected.");
        }

        [Test]
        public void Test_FlightPrices_ShouldBeDisplayed()
        {
            // SRP: This test checks only for flight prices being displayed.

            // Action: Try to fetch all departing flight prices
            List<string> prices = availableFlightsPage.GetAllDepartingFlightPrices();

            // OCP: If new types of price displays are added, 
            // AvailableFlightsPage can be extended without changing this test.

            // Expectation: At least 1 price should be shown
            Assert.IsTrue(prices.Count > 0, "BUG: No departing flight prices were displayed after selecting flights.");
        }

        [TearDown]
        public void TearDown()
        {
            // SRP: TearDown is solely responsible for cleanup.
            // DIP: Depends on the abstract driver interface, not the concrete implementation.

            driver?.Quit();
            driver?.Dispose();
            driver = null;
        }
    }
}
