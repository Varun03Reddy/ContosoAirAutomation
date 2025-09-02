using OpenQA.Selenium;
using InterfaceClass;
using WebAdapterClass;
using NUnit.Framework;
using System.Collections.Generic;

namespace ScenerioClass
{
    [TestFixture]
    public class BookedFlightHistoryTests
    {
        private IBookedFlightHistory _flightHistory;

        [SetUp]
        public void Setup()
        {
            _flightHistory = new BookedFlightHistory();
        }

        [Test]
        public void TestViewBookedFlights()
        {
            _flightHistory.NavigateToLoginPage();
            _flightHistory.Login("test_user", "test_password");

            _flightHistory.NavigateToMyBookedFlightsPage();

            IList<string> bookedFlights = _flightHistory.GetBookedFlights();
            Assert.IsTrue(bookedFlights.Count > 0, "No booked flights found.");
        }

        [Test]
        public void TestViewFlightDetails()
        {
            _flightHistory.NavigateToLoginPage();
            _flightHistory.Login("test_user", "test_password");

            _flightHistory.NavigateToMyBookedFlightsPage();

            IList<string> bookedFlights = _flightHistory.GetBookedFlights();
            Assert.IsTrue(bookedFlights.Count > 0, "No booked flights found.");

            _flightHistory.ViewFlightDetails(0);

            var flightDetailsTitle = ((BookedFlightHistory)_flightHistory).Driver.FindElement(By.XPath("/html/body/navbar/nav/div/div[2]/div[2]/ul/li[2]/a"));
            Assert.IsNotNull(flightDetailsTitle, "Flight details page not displayed.");
        }

        [Test]
        public void TestShopForAnotherFlight()
        {
            _flightHistory.NavigateToLoginPage();
            _flightHistory.Login("test_user", "test_password");

            _flightHistory.NavigateToMyBookedFlightsPage();

            _flightHistory.ShopForAnotherFlight();

            var pageTitle = ((BookedFlightHistory)_flightHistory).Driver.Title;
            Assert.IsFalse(pageTitle.Contains("Booking Page"), "Failed to navigate to booking page.");
        }

        [Test]
        public void TestGetAnotherFlight()
        {
            _flightHistory.NavigateToLoginPage();
            _flightHistory.Login("Vijay", "Vijay");

            _flightHistory.NavigateToMyBookedFlightsPage();

            _flightHistory.GetAnotherFlight();

            var pageTitle = ((BookedFlightHistory)_flightHistory).Driver.Title;
            Assert.IsFalse(pageTitle.Contains("Booking Page"), "Failed to navigate to booking page.");
        }

        [TearDown]
        public void Cleanup()
        {
            _flightHistory.Cleanup();
        }
    }
}