/*
 * Copyright (c) 2025 Vamsi Krishna
 * All rights reserved.
 *
 * This source code is licensed under the terms specified by the owner.
 */
using NUnit.Framework; // NUnit framework for defining and running test cases
using WebAdapterClass; // Implementation of IFlightDeal interface
using InterfaceClass; // Interface segregation: IFlightDeal contains only flight deal related methods
using Utilities; // Helper utilities like AssertionsHelper for cleaner assertions

namespace ScenerioClass
{
    [TestFixture] // Marks this class as an NUnit test fixture
    public class FlightDealTests
    {
        private IFlightDeal flightdeal; // DIP: Depend on interface, not concrete implementation

        [SetUp] // Runs before each test
        public void SetUp()
        {
            flightdeal = new FlightDeal(); // LSP: Any class implementing IFlightDeal can be used
        }

        [TearDown] // Runs after each test to clean up resources
        public void TearDown()
        {
            flightdeal.Close(); // SRP: Encapsulates cleanup of flight deal session/browser
        }

        [Test] // Test: Validate the page title for the flight deals page
        public void GetTitle()
        {
            flightdeal.PerformLogin("admin", "admin"); // SRP: Login encapsulated in the interface

            string expectedSubtitle = "Flight deals"; // Expected title for validation
            string actualSubtitle = flightdeal.Title(); // Actual title fetched from the page

            // Assert using centralized helper for consistency
            AssertionsHelper.AssertEqual(expectedSubtitle, actualSubtitle);
        }

        [Test] // Test: Validate each flight box's source and destination
        public void TestBoxSourceToDestination()
        {
            flightdeal.PerformLogin("admin", "admin"); // Perform login before checking deals

            string expectedSource = "Seattle (SEA)";
            var expectedDestinations = new[]
            {
                "to Barcelona (BCN)",
                "to Singapore (SIN)",
                "to Puerto Nare (NAR)",
                "to Hounslow (LHR)"
            };

            // Loop through each flight deal box
            for (int i = 0; i < expectedDestinations.Length; i++)
            {
                // Get actual source and destination for the i-th box
                var (actualSource, actualDest) = flightdeal.BoxSourceToDestination(i + 1);

                // Validate source and destination
                AssertionsHelper.AssertEqual(expectedSource, actualSource);
                AssertionsHelper.AssertEqual(expectedDestinations[i], actualDest);
            }
        }

        [Test] // Test: Validate the end/purchase date for each flight deal box
        public void TestBoxEndDates()
        {
            flightdeal.PerformLogin("admin", "admin"); // Login first

            var expectedEndDates = new[]
            {
                "Purchase by Feb 13th 2018",
                "Purchase by Feb 13th 2017",
                "Purchase by Feb 13th 2017",
                "Purchase by Feb 13th 2017"
            };

            // Loop through each box to validate the end date
            for (int i = 0; i < expectedEndDates.Length; i++)
            {
                string actualEndDate = flightdeal.BoxEndDate(i + 1);
                AssertionsHelper.AssertEqual(expectedEndDates[i], actualEndDate);
            }
        }

        [Test] // Test: Validate description text (including price) for each flight deal box
        public void TestBoxDescriptions()
        {
            flightdeal.PerformLogin("admin", "admin"); // Login before validation

            var prices = new[] { 479, 528, 535, 626 }; // Expected prices for each deal box

            // Loop through each box to validate the description
            for (int i = 0; i < prices.Length; i++)
            {
                string expectedDescription = $"From $ {prices[i]} ONE WAY";

                // Normalize actual description from the page
                string actualDescription = flightdeal.BoxDescription(i + 1)
                    .Replace("\r\n", " ") // Remove line breaks
                    .Trim()
                    .ToLower();

                string normalizedExpectedDescription = expectedDescription.ToLower().Trim();

                // Assertion using centralized helper
                AssertionsHelper.AssertEqual(normalizedExpectedDescription, actualDescription);
            }
        }
    }
}
