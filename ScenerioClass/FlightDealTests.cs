
using NUnit.Framework;
using System.Threading;
using WebAdapterClass;
using InterfaceClass;

namespace ScenerioClass
{
    /// <summary>
    /// Test class for verifying functionalities of the FlightDeal class.
    /// This class contains various tests for login, retrieving flight details,
    /// and interacting with flight deal UI elements.
    /// </summary>
    public class FlightDealTests
    {
        private IFlightDeal flightdeal;

        /// <summary>
        /// Setup method to initialize the WebDriver and FlightDeal instance before each test.
        /// This method is executed before each test method to set up the test environment.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            // Initialize the FlightDeal instance (which interacts with the flight deal page).
            flightdeal = new FlightDeal();
        }

        /// <summary>
        /// TearDown method to close the browser after each test.
        /// This method is executed after each test method to clean up the environment.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            // Close the browser to ensure resources are freed after each test
            flightdeal.Close();
        }

        /// <summary>
        /// Test for retrieving the title of the flight deals page after performing login.
        /// Verifies that the title of the flight deals page is correct after a successful login.
        /// </summary>
        [Test]
        public void GetTitle()
        {
            string username = "admin";  // Test username
            string password = "admin";  // Test password

            // Perform login to the flight deal page
            flightdeal.PerformLogin(username, password);

            // Expected subtitle on the flight deals page
            string expectedSubtitle = "Flight deals";
            // Get the actual subtitle from the page
            string actualSubtitle = flightdeal.Title();

            // Assert that the actual subtitle matches the expected subtitle
            Assert.That(actualSubtitle, Is.EqualTo(expectedSubtitle));
        }

        /// <summary>
        /// Test for verifying the source and destination of the flight deals.
        /// Iterates over the flight deal boxes and checks the source and destination values.
        /// </summary>
        [Test]
        public void TestBoxSourceToDestination()
        {
            string username = "admin";  // Test username
            string password = "admin";  // Test password

            // Perform login to the flight deal page
            flightdeal.PerformLogin(username, password);

            // Expected source and destinations for the flight deal boxes
            string expectedSource = "Seattle (SEA)";
            var expectedDestinations = new[]
            {
                "to Barcelona (BCN)",
                "to Singapore (SIN)",
                "to Puerto Nare (NAR)",
                "to Hounslow (LHR)"
            };

            // Iterate over the expected destinations and verify the source and destination
            for (int i = 0; i < expectedDestinations.Length; i++)
            {
                var (actualSource, actualDest) = flightdeal.BoxSourceToDestination(i + 1);
                Assert.That(actualSource, Is.EqualTo(expectedSource));
                Assert.That(actualDest, Is.EqualTo(expectedDestinations[i]));
            }
        }

        /// <summary>
        /// Test for verifying the end dates of the flight deals.
        /// Iterates over the flight deal boxes and checks the end dates for each.
        /// </summary>
        [Test]
        public void TestBoxEndDates()
        {
            string username = "admin";  // Test username
            string password = "admin";  // Test password

            // Perform login to the flight deal page
            flightdeal.PerformLogin(username, password);

            // Expected end dates for the flight deal boxes
            var expectedEndDates = new[]
            {
                "Purchase by Feb 13th 2018",  // For box 1
                "Purchase by Feb 13th 2017",  // For box 2
                "Purchase by Feb 13th 2017",  // For box 3
                "Purchase by Feb 13th 2017"   // For box 4
            };

            // Iterate through the boxes and validate the end date for each
            for (int i = 0; i < expectedEndDates.Length; i++)
            {
                string actualEndDate = flightdeal.BoxEndDate(i + 1);  // i + 1 because BoxEndDate is 1-based
                Assert.That(actualEndDate, Is.EqualTo(expectedEndDates[i]));
            }
        }

        /// <summary>
        /// Test for verifying the descriptions of the flight deals.
        /// Iterates over the flight deal boxes and checks the descriptions.
        /// </summary>
        [Test]
        public void TestBoxDescriptions()
        {
            string username = "admin";  // Test username
            string password = "admin";  // Test password

            // Perform login to the flight deal page
            flightdeal.PerformLogin(username, password);

            // Prices for the four flight deal boxes
            var prices = new[] { 479, 528, 535, 626 };

            // Iterate through the boxes and validate the description for each
            for (int i = 0; i < prices.Length; i++)
            {
                // Expected description format for each box
                string expectedDescription = string.Format("From $ {0} ONE WAY", prices[i]);

                // Get the actual description and normalize it for comparison
                string actualDescription = flightdeal.BoxDescription(i + 1)
                    .Replace("\r\n", " ")  // Remove any newline characters
                    .Trim()                // Remove any leading or trailing spaces
                    .ToLower();            // Normalize to lowercase for case-insensitive comparison

                // Normalize expected description similarly
                string normalizedExpectedDescription = expectedDescription.ToLower().Trim();

                // Assert that the actual description matches the expected description
                Assert.That(actualDescription, Is.EqualTo(normalizedExpectedDescription));
            }
        }
    }
}