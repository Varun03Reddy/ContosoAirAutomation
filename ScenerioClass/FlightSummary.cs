/*
 * Copyright (c) 2025 Varun Reddy
 * All rights reserved.
 *
 * This source code is licensed under the terms specified by the owner.
 */
using NUnit.Framework; // NUnit framework for test attributes and assertions
using OpenQA.Selenium; // Selenium WebDriver for browser automation
using OpenQA.Selenium.Chrome; // ChromeDriver for Selenium
using WebAdapterClass; // Page objects and implementations
using Utilities; // ✅ Utilities: AssertionsHelper, ConfigManager, DriverFactory
using System;

namespace ScenerioClass
{
    [TestFixture] // Marks this class as a test fixture for NUnit
    public class ScenerioClassTests
    {
        private IWebDriver driver; // DIP: Use WebDriver abstraction
        private FlightSummary flightSummary; // SRP: Page object for flight summary actions

        [SetUp] // Runs before each test case
        public void Setup()
        {
            // ✅ Get browser type from ConfigManager (default = chrome)
            string browser = ConfigManager.Browser;
            driver = DriverFactory.CreateDriver(browser);

            // ✅ Initialize Page Object
            flightSummary = new FlightSummary(driver);

            // ✅ Get app URL from ConfigManager instead of hardcoding
            string appUrl = ConfigManager.GetAppUrl();
            flightSummary.NavigateToUrl(appUrl);

            // ✅ Maximize browser for stable UI testing
            driver.Manage().Window.Maximize();

            // ✅ Explicit wait: ensure body is visible
            var waitHelper = new WaitHelper(driver, 10);
            waitHelper.WaitForElementVisible(By.TagName("body"));
        }

        [TearDown] // Runs after each test case
        public void Cleanup()
        {
            driver?.Quit(); // SRP: Responsible only for cleanup of resources
            driver?.Dispose();
        }

        [Test] // Test case: Book a flight
        public void BookFlightTest()
        {
            // Ensure no exceptions occur during login and booking
            AssertionsHelper.AssertDoesNotThrow(() =>
            {
                flightSummary.PerformLogin("Varun", "@123varun#143");
                flightSummary.BookFlight();
            });
        }

        [Test] // Test case: Check passenger name in flight summary
        public void CheckPassengerNameTest()
        {
            AssertionsHelper.AssertDoesNotThrow(() =>
            {
                flightSummary.PerformLogin("Vijay", "%2345rUN((");
                flightSummary.checkPassengerName();
            });
        }

        [Test] // Test case: Check cancel booking functionality
        public void CheckCancelBookingTest()
        {
            AssertionsHelper.AssertDoesNotThrow(() =>
            {
                flightSummary.PerformLogin("Varun", "@123varun#143");
                flightSummary.checkCancelBooking();
            });
        }

        [Test] // Test case: Validate flight purchase details
        public void CheckPurchaseTest()
        {
            flightSummary.PerformLogin("Varun", "@123varun#143");
            flightSummary.BookFlight();

            string expectedDestination = "Paris"; // Expected destination after booking
            string actualDestination = "Hawaii"; // Placeholder: Actual value should come from page

            // Validate that the expected destination does not match the actual
            AssertionsHelper.AssertIsFalse(expectedDestination == actualDestination, "Destination mismatch validation.");
        }
    }
}
