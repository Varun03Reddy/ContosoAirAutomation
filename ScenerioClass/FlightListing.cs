/*
 * Copyright (c) 2025 Arpita
 * All rights reserved.
 *
 * This source code is licensed under the terms specified by the owner.
 */
using InterfaceClass; // ISP: Interface segregation principle, using only flight listing-related methods
using NUnit.Framework; // NUnit framework for writing tests
using System; // For DateTime usage
using Utilities; // Helper classes: AssertionsHelper, etc.
using WebAdapterClass; // Concrete implementation of flight listing functionality

namespace ScenerioClass
{
    [TestFixture] // Marks this class as a NUnit test fixture
    public class FlightListingPageTest
    {
        private FlightListingPage flightListingPage; // SRP: Each test class manages only one page object

        [SetUp] // Runs before each test
        public void SetUp()
        {
            // Initialize the FlightListingPage object for testing
            flightListingPage = new FlightListingPage(); // DIP: Depend on abstraction via interface (if implemented)
        }

        [TearDown] // Runs after each test
        public void TearDown()
        {
            // Clean up resources (close browser session)
            flightListingPage.Close(); // SRP: Responsible for cleaning up this page only
        }

        [Test] // Test: Verify that flight search works correctly after login
        public void Test_Flight_Search_With_Login()
        {
            // Test data
            string username = "testuser";
            string password = "varun@2341";
            string from = "Anchorage ANC";
            string to = "Abakan ABA";
            DateTime departureDate = new DateTime(2025, 12, 20);
            int passengers = 1;
            DateTime returnDate = new DateTime(2025, 12, 25);

            // Perform login
            flightListingPage.Login(username, password); // SRP: Login responsibility encapsulated
            // Search for flights with given criteria
            flightListingPage.SearchFlights(from, to, departureDate, passengers, returnDate); // SRP: Search responsibility encapsulated

            // Assert that listing available flights does not throw an exception
            AssertionsHelper.AssertDoesNotThrow(() => flightListingPage.ListAvailableFlights());
        }

        [Test] // Test: Verify that flight listings are returned and not empty
        public void Test_Flight_Listings_Are_Not_Empty()
        {
            // Test data
            string username = "reddy";
            string password = "varun@5!@!";
            string from = "Anchorage ANC";
            string to = "Abakan ABA";
            DateTime departureDate = new DateTime(2025, 12, 20);
            int passengers = 1;
            DateTime returnDate = new DateTime(2025, 12, 25);

            // Perform login
            flightListingPage.Login(username, password);
            // Search for flights
            flightListingPage.SearchFlights(from, to, departureDate, passengers, returnDate);

            // Get flight listings
            var flightListings = flightListingPage.ListAvailableFlights();
            // Assert that flight listings are not empty
            AssertionsHelper.AssertIsNotEmpty(flightListings, "No flight listings were found!"); // Validation responsibility
        }
    }
}
