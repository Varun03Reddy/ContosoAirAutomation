using InterfaceClass;
using NUnit.Framework;
using System;
using Utilities; // ✅ Added Utilities
using WebAdapterClass;

namespace ScenerioClass
{
    [TestFixture]
    public class FlightListingPageTest
    {
        private FlightListingPage flightListingPage;

        [SetUp]
        public void SetUp()
        {
            flightListingPage = new FlightListingPage();
        }

        [TearDown]
        public void TearDown()
        {
            flightListingPage.Close();
        }

        [Test]
        public void Test_Flight_Search_With_Login()
        {
            string username = "testuser";
            string password = "testpassword";
            string from = "Anchorage ANC";
            string to = "Abakan ABA";
            DateTime departureDate = new DateTime(2024, 12, 20);
            int passengers = 1;
            DateTime returnDate = new DateTime(2024, 12, 25);

            flightListingPage.Login(username, password);
            flightListingPage.SearchFlights(from, to, departureDate, passengers, returnDate);

            AssertionsHelper.AssertDoesNotThrow(() => flightListingPage.ListAvailableFlights());
        }

        [Test]
        public void Test_Flight_Listings_Are_Not_Empty()
        {
            string username = "testuser";
            string password = "testpassword";
            string from = "Anchorage ANC";
            string to = "Abakan ABA";
            DateTime departureDate = new DateTime(2024, 12, 20);
            int passengers = 1;
            DateTime returnDate = new DateTime(2024, 12, 25);

            flightListingPage.Login(username, password);
            flightListingPage.SearchFlights(from, to, departureDate, passengers, returnDate);

            var flightListings = flightListingPage.ListAvailableFlights();
            AssertionsHelper.AssertIsNotEmpty(flightListings, "No flight listings were found!");
        }
    }
}