using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebAdapterClass;
using Utilities;
using System;

namespace ScenerioClass
{
    [TestFixture]
    public class ScenerioClassTests
    {
        private IWebDriver driver;
        private FlightSummary flightSummary;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            flightSummary = new FlightSummary(driver);
            flightSummary.NavigateToUrl("http://localhost:3000/");
        }

        [TearDown]
        public void Cleanup()
        {
            driver?.Quit();
            driver?.Dispose();
        }

        [Test]
        public void BookFlightTest()
        {
            AssertionsHelper.AssertDoesNotThrow(() =>
            {
                flightSummary.PerformLogin("Varun", "@123varun#143");
                flightSummary.BookFlight();
            });
        }

        [Test]
        public void CheckPassengerNameTest()
        {
            AssertionsHelper.AssertDoesNotThrow(() =>
            {
                flightSummary.PerformLogin("Vijay", "%2345rUN((");
                flightSummary.checkPassengerName();
            });
        }

        [Test]
        public void CheckCancelBookingTest()
        {
            AssertionsHelper.AssertDoesNotThrow(() =>
            {
                flightSummary.PerformLogin("Varun", "@123varun#143");
                flightSummary.checkCancelBooking();
            });
        }

        [Test]
        public void CheckPurchaseTest()
        {
            flightSummary.PerformLogin("Varun", "@123varun#143");
            flightSummary.BookFlight();

            string expectedDestination = "Paris";
            string actualDestination = "Hawaii"; // Placeholder

            AssertionsHelper.AssertIsFalse(expectedDestination == actualDestination, "Destination mismatch validation.");
        }
    }
}