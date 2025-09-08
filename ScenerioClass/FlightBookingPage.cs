/*
 * Copyright (c) 2025 Vamsi Krishna
 * All rights reserved.
 *
 * This source code is licensed under the terms specified by the owner.
 */
using InterfaceClass; // Interface segregation: IFlightBooking contains only flight booking-related methods
using NUnit.Framework; // NUnit framework for defining and running test cases
using OpenQA.Selenium; // Selenium WebDriver for browser automation
using Utilities; // Helpers like SeleniumHelpers, AssertionsHelper, DriverFactory
using WebAdapterClass; // Implementation of IFlightBooking interface
using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using System.Collections.Generic;

namespace ScenerioClass
{
    [TestFixture] // Marks this class as an NUnit test fixture
    public class FlightBookingTests
    {
        private IWebDriver driver; // DIP: Depends on IWebDriver abstraction
        private IFlightBooking flightBookingPage; // DIP: Interface-based page object, allows any implementation of IFlightBooking

        [SetUp] // Runs before each test to initialize resources
        public void SetUp()
        {
            driver = DriverFactory.CreateDriver("chrome"); // Factory pattern: centralized creation of WebDriver instances
            flightBookingPage = new FlightBookingPage(driver); // LSP: Any IFlightBooking implementation can replace FlightBookingPage
        }

        [Test] // Test: Booking a flight with valid login credentials
        public void FlightBooking_ValidLogin()
        {
            flightBookingPage.Login("vamsi", "Vamsi@143123#"); // SRP: Login logic encapsulated in page object
            flightBookingPage.SelectFlightDetails(
                "Seisia ABM", "Egg Harbor City ACY",
                new DateTime(2025, 12, 20), 1,
                new DateTime(2025, 12, 25)); // SRP: Selecting flight details encapsulated
            flightBookingPage.BookFlight(); // SRP: Flight booking action encapsulated
            flightBookingPage.Close(); // SRP: Cleanup specific to this page
        }

        [Test] // Test: Booking a flight with a single passenger
        public void FlightBooking_SinglePassenger()
        {
            flightBookingPage.Login("Arpita", "arpita@1234@#$%^");
            flightBookingPage.SelectFlightDetails(
                "Seisia ABM", "Egg Harbor City ACY",
                new DateTime(2024, 12, 20), 1,
                new DateTime(2024, 12, 25));
            flightBookingPage.BookFlight();

            // Validate that the booking was successful using SeleniumHelpers and assertion helper
            var actual = SeleniumHelpers.WaitForElement(driver, By.CssSelector(".block-booking-title")).Text;
            AssertionsHelper.AssertEqual("Flight booked!", actual,
                "The booking title does not match the expected description.");

            flightBookingPage.Close();
        }

        [Test] // Test: Booking a flight with multiple passengers
        public void FlightBooking_MultiplePassengers()
        {
            flightBookingPage.Login("keyur", "keyur@456#");
            flightBookingPage.SelectFlightDetails(
                "Seisia ABM", "Egg Harbor City ACY",
                new DateTime(2025, 12, 20), 3,
                new DateTime(2025, 12, 25));
            flightBookingPage.BookFlight();

            // Validate that the booking was successful
            var actual = SeleniumHelpers.WaitForElement(driver, By.CssSelector(".block-booking-title")).Text;
            AssertionsHelper.AssertEqual("Flight booked!", actual,
                "The booking title does not match the expected description.");

            flightBookingPage.Close();
        }

        [Test] // Test: Booking a flight for a specific user with multiple passengers
        public void FlightBooking_Passengers()
        {
            flightBookingPage.Login("Varun Reddy", "vgg@544");
            flightBookingPage.SelectFlightDetails(
                "Seisia ABM", "Egg Harbor City ACY",
                new DateTime(2025, 12, 20), 3,
                new DateTime(2025, 12, 25));
            flightBookingPage.BookFlight();

            var actual = SeleniumHelpers.WaitForElement(driver, By.CssSelector(".block-booking-title")).Text;
            AssertionsHelper.AssertEqual("Flight booked!", actual,
                "The booking title does not match the expected description.");

            flightBookingPage.Close();
        }

        [Test] // Test: Booking flights between different destinations
        public void FlightBooking_DifferentDestinations()
        {
            flightBookingPage.Login("Varun Reddy", "vgg@544");
            flightBookingPage.SelectFlightDetails(
                "New York JFK", "Los Angeles LAX",
                new DateTime(2025, 12, 20), 2,
                new DateTime(2025, 12, 25));
            flightBookingPage.BookFlight();

            var actual = SeleniumHelpers.WaitForElement(driver, By.CssSelector(".block-booking-title")).Text;
            AssertionsHelper.AssertEqual("Flight booked!", actual,
                "The booking title does not match the expected description.");

            flightBookingPage.Close();
        }

        [Test] // Test: Return date must be later than departure date
        public void FlightBooking_ReturnDateLaterThanDepartureDate()
        {
            flightBookingPage.Login("vamsi", "ava23@h");
            flightBookingPage.SelectFlightDetails(
                "Seisia ABM", "Egg Harbor City ACY",
                new DateTime(2025, 12, 20), 2,
                new DateTime(2025, 12, 25));
            flightBookingPage.BookFlight();

            var actual = SeleniumHelpers.WaitForElement(driver, By.CssSelector(".block-booking-title")).Text;
            AssertionsHelper.AssertEqual("Flight booked!", actual,
                "The booking title does not match the expected description.");

            flightBookingPage.Close();
        }

        [Test] // Test: Passenger dropdown contains valid values
        public void FlightBooking_PassengerDropdown_ShouldContainValidValues()
        {
            flightBookingPage.Login("Varun", "varun@1432435#");
            SeleniumHelpers.ClickElement(driver, By.LinkText("Book")); // Navigate to booking section

            // Access passenger dropdown and verify available options
            var passengerDropdown = new SelectElement(SeleniumHelpers.WaitForElement(driver, By.Id("passengers")));
            var options = passengerDropdown.Options;

            var expectedValues = new List<string> { "1", "2", "3", "4", "5" };
            var actualValues = options.Select(o => o.Text).ToList();

            AssertionsHelper.AssertCollectionEqual(expectedValues, actualValues,
                "Passenger dropdown values do not match.");
        }

        [TearDown] // Runs after each test
        public void TearDown()
        {
            // SRP: Clean up WebDriver resources
            driver?.Quit();
            driver?.Dispose();
            driver = null;
        }
    }
}
