
using InterfaceClass;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAdapterClass;

namespace ScenerioClass
{
    /// <summary>
    /// Test cases for the FlightListingPage class that ensures login, flight search, and listing functionalities work correctly.
    /// </summary>
    [TestFixture]
    public class FlightListingPageTest
    {
        private FlightListingPage flightListingPage;

        /// <summary>
        /// Setup method to initialize the WebDriver and FlightListingPage instance.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            // Initialize the page object for flight listing (WebDriver is initialized within the class)
            flightListingPage = new FlightListingPage();
        }

        /// <summary>
        /// TearDown method to close the browser after each test.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            flightListingPage.Close();  // Ensures that the browser is closed after each test
        }

        /// <summary>
        /// Test case for logging in and searching for flights.
        /// </summary>
        [Test]
        public void Test_Flight_Search_With_Login()
        {
            // Arrange: Define login credentials and flight search parameters
            string username = "testuser";
            string password = "testpassword";
            string from = "Anchorage ANC";
            string to = "Abakan ABA";
            DateTime departureDate = new DateTime(2024, 12, 20);
            int passengers = 1;
            DateTime returnDate = new DateTime(2024, 12, 25);

            // Act: Login to the system
            flightListingPage.Login(username, password);

            // Act: Perform the flight search after login
            flightListingPage.SearchFlights(from, to, departureDate, passengers, returnDate);

            // Assert: Ensure that the flight listings are displayed
            Assert.DoesNotThrow(() => flightListingPage.ListAvailableFlights(), "Flight listing failed or no flights are available");
        }

        /// <summary>
        /// Test case to ensure flight listings are not empty.
        /// </summary>
        [Test]
        public void Test_Flight_Listings_Are_Not_Empty()
        {
            // Arrange: Define login credentials and flight search parameters
            string username = "testuser";
            string password = "testpassword";
            string from = "Anchorage ANC";
            string to = "Abakan ABA";
            DateTime departureDate = new DateTime(2024, 12, 20);
            int passengers = 1;
            DateTime returnDate = new DateTime(2024, 12, 25);

            // Act: Login to the system
            flightListingPage.Login(username, password);

            // Act: Perform the flight search
            flightListingPage.SearchFlights(from, to, departureDate, passengers, returnDate);

            // Assert: Ensure that flight listings are not empty
            var flightListings = flightListingPage.ListAvailableFlights();
            Assert.IsNotEmpty(flightListings, "No flight listings were found!");
        }
    }
}