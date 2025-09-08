/*
 * Copyright (c) 2025 Keyur
 * All rights reserved.
 *
 * This source code is licensed under the terms specified by the owner.
 */
using OpenQA.Selenium; // Selenium WebDriver for browser automation
using InterfaceClass; // Custom interfaces for page operations (Interface segregation, Dependency inversion)
using WebAdapterClass; // Implementation of the interfaces
using NUnit.Framework; // NUnit framework for unit testing
using System.Collections.Generic; // To use IList<T>

namespace ScenerioClass
{
    [TestFixture] // Marks this class as a test fixture for NUnit
    public class BookedFlightHistoryTests
    {
        // Dependency inversion principle (DIP):
        // Using the interface IBookedFlightHistory instead of concrete class allows flexibility and testability.
        private IBookedFlightHistory _flightHistory;

        [SetUp] // Runs before each test method
        public void Setup()
        {
            // Single Responsibility Principle (SRP):
            // This setup method is only responsible for initializing the page object.
            _flightHistory = new BookedFlightHistory(); // Liskov Substitution Principle (LSP) in action:
                                                        // IBookedFlightHistory can be replaced by any implementation without changing client code.
        }

        [Test] // Test case to verify viewing booked flights
        public void TestViewBookedFlights()
        {
            // Navigate to login page
            _flightHistory.NavigateToLoginPage();

            // Login with test credentials
            _flightHistory.Login("test_user", "@varun#");

            // Navigate to "My Booked Flights" page
            _flightHistory.NavigateToMyBookedFlightsPage();

            // Retrieve booked flights
            IList<string> bookedFlights = _flightHistory.GetBookedFlights();

            // Assert that booked flights exist
            Assert.IsTrue(bookedFlights.Count > 0, "No booked flights found.");
        }

        [Test] // Test case to verify viewing details of a booked flight
        public void TestViewFlightDetails()
        {
            // Navigate to login page
            _flightHistory.NavigateToLoginPage();

            // Login with user credentials
            _flightHistory.Login("Varun Reddy", "vgg@544");

            // Navigate to booked flights page
            _flightHistory.NavigateToMyBookedFlightsPage();

            // Retrieve booked flights
            IList<string> bookedFlights = _flightHistory.GetBookedFlights();
            Assert.IsTrue(bookedFlights.Count > 0, "No booked flights found.");

            // View details of the first flight
            _flightHistory.ViewFlightDetails(0);

            // Verify flight details page is displayed
            var flightDetailsTitle = ((BookedFlightHistory)_flightHistory).Driver.FindElement(
                By.XPath("/html/body/navbar/nav/div/div[2]/div[2]/ul/li[2]/a")
            );
            Assert.IsNotNull(flightDetailsTitle, "Flight details page not displayed.");
        }

        [Test] // Test case to verify shopping for another flight
        public void TestShopForAnotherFlight()
        {
            // Navigate to login page
            _flightHistory.NavigateToLoginPage();

            // Login with test credentials
            _flightHistory.Login("test_user", "@varun#");

            // Navigate to booked flights page
            _flightHistory.NavigateToMyBookedFlightsPage();

            // Click "Shop for another flight"
            _flightHistory.ShopForAnotherFlight();

            // Verify navigation to booking page
            var pageTitle = ((BookedFlightHistory)_flightHistory).Driver.Title;
            Assert.IsFalse(pageTitle.Contains("Booking Page"), "Failed to navigate to booking page.");
        }

        [Test] // Test case to get another flight
        public void TestGetAnotherFlight()
        {
            // Navigate to login page
            _flightHistory.NavigateToLoginPage();

            // Login with user credentials
            _flightHistory.Login("Varun Reddy", "vgg@544");

            // Navigate to booked flights page
            _flightHistory.NavigateToMyBookedFlightsPage();

            // Perform action to get another flight
            _flightHistory.GetAnotherFlight();

            // Verify navigation to booking page
            var pageTitle = ((BookedFlightHistory)_flightHistory).Driver.Title;
            Assert.IsFalse(pageTitle.Contains("Booking Page"), "Failed to navigate to booking page.");
        }

        [TearDown] // Runs after each test method
        public void Cleanup()
        {
            // Single Responsibility Principle (SRP):
            // This method is only responsible for cleaning up browser/session resources.
            _flightHistory.Cleanup();
        }
    }
}
