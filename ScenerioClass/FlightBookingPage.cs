using InterfaceClass;
using NUnit.Framework;
using OpenQA.Selenium;
using Utilities;
using WebAdapterClass;
using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using System.Collections.Generic;

namespace ScenerioClass
{
    [TestFixture]
    public class FlightBookingTests
    {
        private IWebDriver driver;
        private IFlightBooking flightBookingPage;

        [SetUp]
        public void SetUp()
        {
            driver = DriverFactory.CreateDriver("chrome"); // Using DriverFactory
            flightBookingPage = new FlightBookingPage(driver);
        }

        [Test]
        public void FlightBooking_ValidLogin()
        {
            flightBookingPage.Login("athesh", "athesh");
            flightBookingPage.SelectFlightDetails("Seisia ABM", "Egg Harbor City ACY", new DateTime(2025, 12, 20), 1, new DateTime(2025, 12, 25));
            flightBookingPage.BookFlight();
            flightBookingPage.Close();
        }

        [Test]
        public void FlightBooking_SinglePassenger()
        {
            flightBookingPage.Login("athesh", "athesh");
            flightBookingPage.SelectFlightDetails("Seisia ABM", "Egg Harbor City ACY", new DateTime(2024, 12, 20), 1, new DateTime(2024, 12, 25));
            flightBookingPage.BookFlight();

            var actual = SeleniumHelpers.WaitForElement(driver, By.CssSelector(".block-booking-title")).Text;
            AssertionsHelper.AssertEqual("Flight booked!", actual, "The booking title does not match the expected description.");

            flightBookingPage.Close();
        }

        [Test]
        public void FlightBooking_MultiplePassengers()
        {
            flightBookingPage.Login("athesh", "athesh");
            flightBookingPage.SelectFlightDetails("Seisia ABM", "Egg Harbor City ACY", new DateTime(2024, 12, 20), 3, new DateTime(2024, 12, 25));
            flightBookingPage.BookFlight();

            var actual = SeleniumHelpers.WaitForElement(driver, By.CssSelector(".block-booking-title")).Text;
            AssertionsHelper.AssertEqual("Flight booked!", actual, "The booking title does not match the expected description.");

            flightBookingPage.Close();
        }

        [Test]
        public void FlightBooking_Passengers()
        {
            flightBookingPage.Login("athesh", "athesh");
            flightBookingPage.SelectFlightDetails("Seisia ABM", "Egg Harbor City ACY", new DateTime(2024, 12, 20), 3, new DateTime(2024, 12, 25));
            flightBookingPage.BookFlight();

            var actual = SeleniumHelpers.WaitForElement(driver, By.CssSelector(".block-booking-title")).Text;
            AssertionsHelper.AssertEqual("Flight booked!", actual, "The booking title does not match the expected description.");

            flightBookingPage.Close();
        }

        [Test]
        public void FlightBooking_DifferentDestinations()
        {
            flightBookingPage.Login("athesh", "athesh");
            flightBookingPage.SelectFlightDetails("New York JFK", "Los Angeles LAX", new DateTime(2025, 12, 20), 2, new DateTime(2025, 12, 25));
            flightBookingPage.BookFlight();

            var actual = SeleniumHelpers.WaitForElement(driver, By.CssSelector(".block-booking-title")).Text;
            AssertionsHelper.AssertEqual("Flight booked!", actual, "The booking title does not match the expected description.");

            flightBookingPage.Close();
        }

        [Test]
        public void FlightBooking_ReturnDateLaterThanDepartureDate()
        {
            flightBookingPage.Login("athesh", "athesh");
            flightBookingPage.SelectFlightDetails("Seisia ABM", "Egg Harbor City ACY", new DateTime(2025, 12, 20), 2, new DateTime(2025, 12, 25));
            flightBookingPage.BookFlight();

            var actual = SeleniumHelpers.WaitForElement(driver, By.CssSelector(".block-booking-title")).Text;
            AssertionsHelper.AssertEqual("Flight booked!", actual, "The booking title does not match the expected description.");

            flightBookingPage.Close();
        }

        [Test]
        public void FlightBooking_PassengerDropdown_ShouldContainValidValues()
        {
            flightBookingPage.Login("athesh", "athesh");
            SeleniumHelpers.ClickElement(driver, By.LinkText("Book"));

            var passengerDropdown = new SelectElement(SeleniumHelpers.WaitForElement(driver, By.Id("passengers")));
            var options = passengerDropdown.Options;

            var expectedValues = new List<string> { "1", "2", "3", "4", "5" };
            var actualValues = options.Select(o => o.Text).ToList();

            AssertionsHelper.AssertCollectionEqual(expectedValues, actualValues, "Passenger dropdown values do not match.");
        }
        [TearDown]
        public void TearDown()
        {
            driver?.Quit();
            driver?.Dispose();
            driver = null;
        }
    }
}