/*
 * Copyright (c) 2025 Keyur
 * All rights reserved.
 *
 * This source code is licensed under the terms specified by the owner.
 */
using InterfaceClass; // Interface segregation principle: IBookingOptions contains only methods needed for booking options
using NUnit.Framework; // NUnit framework for writing test cases
using Utilities; // Contains helper classes like AssertionsHelper and DriverFactory
using WebAdapterClass; // Contains implementation of IBookingOptions interface
using OpenQA.Selenium; // Selenium WebDriver for browser automation

namespace ScenerioClass
{
    [TestFixture] // Marks this class as a test fixture for NUnit
    public class BookingOptionsTests
    {
        private IBookingOptions bookingOptionsPage; // DIP: Using interface instead of concrete class
        private IWebDriver driver; // WebDriver instance for browser automation

        [SetUp] // Runs before each test
        public void SetUp()
        {
            // Factory pattern: create driver based on configuration
            driver = DriverFactory.CreateDriver(ConfigManager.Browser);

            // LSP: Any implementation of IBookingOptions can replace BookingOptionsPage
            bookingOptionsPage = new BookingOptionsPage(driver);

            // SRP: Setup method focuses only on initialization and login
            bookingOptionsPage.Login(ConfigManager.Username, ConfigManager.Password);
            bookingOptionsPage.NavigateToBookingPage(); // Navigate to booking page before tests
        }

        [TearDown] // Runs after each test
        public void TearDown()
        {
            // SRP: Cleanup browser and resources after test
            bookingOptionsPage.Close(); // Close the page-specific resources
            driver?.Quit(); // Quit browser
            driver?.Dispose(); // Dispose WebDriver resources
        }

        [Test] // Test case: One-way option hides the Return Date field
        public void TestOneWayOptionHidesReturnDateField()
        {
            // Click the "One way" option
            bookingOptionsPage.ClickOneWay();

            // Assert that the Return Date field is NOT visible
            bool isReturnDateVisible = bookingOptionsPage.IsReturnDateVisible();

            // Use utility helper for assertion with clear message
            AssertionsHelper.AssertIsFalse(isReturnDateVisible,
                "The 'Return Date' field is still visible after clicking 'One way', indicating a bug.");
        }

        [Test] // Test case: Multi-city option keeps the Return Date field hidden
        public void TestMultiCityOptionKeepsReturnDateFieldHidden()
        {
            // Click the "Multi-city" option
            bookingOptionsPage.ClickMultiCity();

            // Assert that the Return Date field is NOT visible
            bool isReturnDateVisible = bookingOptionsPage.IsReturnDateVisible();

            // Use utility helper for assertion with clear message
            AssertionsHelper.AssertIsFalse(isReturnDateVisible,
                "The 'Multi-city' option incorrectly displays the 'Return Date' field, indicating a bug.");
        }
    }
}
