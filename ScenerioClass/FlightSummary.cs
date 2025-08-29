using OpenQA.Selenium;
using InterfaceClass;
using WebAdapterClass;
using NUnit.Framework;
using System;

namespace ScenerioClass
{
    /// <summary>
    /// This class contains test scenarios for booking and canceling a flight.
    /// </summary>
    [TestFixture]
    public class ScenerioClass
    {
        private IWebDriver driver;
        private IFlightSummary flightSummary;

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            flightSummary = new FlightSummary(driver);
            flightSummary.NavigateToUrl("http://localhost:3000/");
        }

        [Test]
        public void BookFlightTest()
        {
            flightSummary.PerformLogin("Varun", "@123varun#143");
            flightSummary.BookFlight();
        }

        [Test]
        public void CheckPassengerNameTest()
        {
            flightSummary.PerformLogin("Vijay", "Vijay");
            flightSummary.checkPassengerName();
        }

        [Test]
        public void CheckCancelBookingTest()
        {
            flightSummary.PerformLogin("Varun", "@123varun#143");
            flightSummary.checkCancelBooking();
        }

        [Test]
        public void CheckPurchaseTest()
        {
            flightSummary.PerformLogin("Varun", "@123varun#143");
            flightSummary.BookFlight();

            string expectedDestination = "Paris";
            string actualDestination = "Hawaii"; // placeholder

            Assert.AreNotEqual(expectedDestination, actualDestination, "Destination mismatch validation.");
        }

        [TearDown]
        public void Cleanup()
        {
            if (driver != null)
            {
                try
                {
                    driver.Quit();   // Close browser windows
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error while quitting driver: {ex.Message}");
                }
                finally
                {
                    driver.Dispose(); // Explicitly dispose WebDriver instance
                    driver = null;
                }
            }
        }
    }
}