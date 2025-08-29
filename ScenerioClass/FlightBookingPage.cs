

using InterfaceClass;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using WebAdapterClass;

namespace ScenerioClass
{
    /// <summary>
    /// Contains test cases for the Flight Booking functionality of the application.
    /// </summary>
    [TestFixture]
    public class FlightBookingTests
    {
        private IWebDriver driver;
        private IFlightBooking flightBookingPage;

        /// <summary>
        /// Initializes the WebDriver and FlightBookingPage before each test.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            flightBookingPage = new FlightBookingPage(driver);
        }

        /// <summary>
        /// Validates login with valid credentials and booking process.
        /// </summary>
        [Test]
        public void FlightBooking_ValidLogin()
        {
            // Login with valid credentials
            flightBookingPage.Login("athesh", "athesh");

            // Select flight details
            flightBookingPage.SelectFlightDetails("Seisia ABM", "Egg Harbor City ACY", new DateTime(2024, 12, 20), 1, new DateTime(2024, 12, 25));

            // Book the flight
            flightBookingPage.BookFlight();

            // Close the browser
            flightBookingPage.Close();
        }

        /// <summary>
        /// Validates flight booking for a single passenger.
        /// </summary>
        [Test]
        public void FlightBooking_SinglePassenger()
        {
            // Login
            flightBookingPage.Login("athesh", "athesh");

            // Select flight details for a single passenger
            flightBookingPage.SelectFlightDetails("Seisia ABM", "Egg Harbor City ACY", new DateTime(2024, 12, 20), 1, new DateTime(2024, 12, 25));

            // Book the flight
            flightBookingPage.BookFlight();

            // Validate the booking title
            var actual = driver.FindElement(By.CssSelector(".block-booking-title")).Text;
            var expected = "Flight booked!";
            Assert.AreEqual(expected, actual, "The booking title does not match the expected description.");

            // Close the browser
            flightBookingPage.Close();
        }

        /// <summary>
        /// Validates flight booking for multiple passengers.
        /// </summary>
        [Test]
        public void FlightBooking_MultiplePassengers()
        {
            // Login
            flightBookingPage.Login("athesh", "athesh");

            // Select flight details for multiple passengers
            flightBookingPage.SelectFlightDetails("Seisia ABM", "Egg Harbor City ACY", new DateTime(2024, 12, 20), 3, new DateTime(2024, 12, 25));

            // Book the flight
            flightBookingPage.BookFlight();

            // Validate the booking title
            var actual = driver.FindElement(By.CssSelector(".block-booking-title")).Text;
            var expected = "Flight booked!";
            Assert.AreEqual(expected, actual, "The booking title does not match the expected description.");

            // Close the browser
            flightBookingPage.Close();
        }
        [Test]
        public void FlightBooking_Passengers()
        {
            // Login
            flightBookingPage.Login("athesh", "athesh");

            // Select flight details for multiple passengers
            flightBookingPage.SelectFlightDetails("Seisia ABM", "Egg Harbor City ACY", new DateTime(2024, 12, 20), 3, new DateTime(2024, 12, 25));

            // Book the flight
            flightBookingPage.BookFlight();

            // Validate the booking title
            var actual = driver.FindElement(By.CssSelector(".block-booking-title")).Text;
            var expected = "Flight booked!";
            Assert.AreEqual(expected, actual, "The booking title does not match the expected description.");

            // Close the browser
            flightBookingPage.Close();
        }
        /// <summary>
        /// Validates flight booking with different destinations.
        /// </summary>
        [Test]
        public void FlightBooking_DifferentDestinations()
        {
            // Login
            flightBookingPage.Login("athesh", "athesh");

            // Select flight details with different destinations
            flightBookingPage.SelectFlightDetails("New York JFK", "Los Angeles LAX", new DateTime(2024, 12, 20), 2, new DateTime(2024, 12, 25));

            // Book the flight
            flightBookingPage.BookFlight();

            // Validate the booking title
            var actual = driver.FindElement(By.CssSelector(".block-booking-title")).Text;
            var expected = "Flight booked!";
            Assert.AreEqual(expected, actual, "The booking title does not match the expected description.");

            // Close the browser
            flightBookingPage.Close();
        }

        /// <summary>
        /// Validates flight booking with a return date later than the departure date.
        /// </summary>
        [Test]
        public void FlightBooking_ReturnDateLaterThanDepartureDate()
        {
            // Login
            flightBookingPage.Login("athesh", "athesh");

            // Select flight details with a return date later than the departure date
            flightBookingPage.SelectFlightDetails("Seisia ABM", "Egg Harbor City ACY", new DateTime(2025, 12, 20), 2, new DateTime(2025, 12, 25));

            // Book the flight
            flightBookingPage.BookFlight();

            // Validate the booking title
            var actual = driver.FindElement(By.CssSelector(".block-booking-title")).Text;
            var expected = "Flight booked!";
            Assert.AreEqual(expected, actual, "The booking title does not match the expected description.");

            // Close the browser
            flightBookingPage.Close();
        }

        /// <summary>
        /// Validates that the passenger dropdown contains valid values.
        /// </summary>
        [Test]
        public void FlightBooking_PassengerDropdown_ShouldContainValidValues()
        {
            // Arrange
            flightBookingPage.Login("athesh", "athesh");

            // Act
            driver.FindElement(By.LinkText("Book")).Click();
            var passengerDropdown = new SelectElement(driver.FindElement(By.Id("passengers")));
            var options = passengerDropdown.Options;

            // Assert
            var expectedValues = new List<string> { "1", "2", "3", "4", "5" };
            var actualValues = options.Select(o => o.Text).ToList();
            CollectionAssert.AreEqual(expectedValues, actualValues, "Passenger dropdown values do not match.");
        }

        /// <summary>
        /// Closes the WebDriver after each test.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                try
                {
                    driver.Quit();   // Cleanly closes the browser
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error quitting driver: {ex.Message}");
                }
                finally
                {
                    driver.Dispose();  // Properly disposes WebDriver
                    driver = null;     // Avoids dangling reference
                }
            }
        }
    }
}