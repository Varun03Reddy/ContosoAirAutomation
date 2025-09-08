/*
 * Copyright (c) 2025 Arpita
 * All rights reserved.
 *
 * This source code is licensed under the terms specified by the owner.
 */
using NUnit.Framework;
using OpenQA.Selenium;
using InterfaceClass;
using WebAdapterClass;
using Utilities;

namespace ScenerioClass
{
    /// <summary>
    /// Test cases for validating the "View by" and "Filter results"
    /// checkboxes on the booking page.
    /// Shows failing cases where selections do not highlight properly.
    /// </summary>
    [TestFixture]
    public class BookingFiltersTests
    {
        private IWebDriver driver;
        private IBookingFilters bookingFiltersPage;

        [SetUp]
        public void SetUp()
        {
            // Initialize WebDriver from Utilities
            driver = DriverFactory.CreateDriver("chrome");

            // Navigate to the main app URL
            driver.Navigate().GoToUrl(ConfigManager.GetAppUrl());

            // Initialize page object
            bookingFiltersPage = new BookingFiltersPage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            bookingFiltersPage.Close();
            driver?.Dispose();
        }

        /// <summary>
        /// BUG: Calendar should highlight after click, but it does not.
        /// </summary>
        [Test]
        public void TestCalendarSelectionFailsToHighlight()
        {
            bookingFiltersPage.ClickCalendar();
            bool isCalendarSelected = bookingFiltersPage.IsCalendarSelected();

            // Compare as strings since AssertionsHelper expects string
            AssertionsHelper.AssertEqual("True", isCalendarSelected.ToString(),
                "BUG: Calendar filter was clicked but did not get highlighted (not selected).");
        }

        /// <summary>
        /// BUG: Schedule should highlight after click, but it does not.
        /// </summary>
        [Test]
        public void TestScheduleSelectionFailsToHighlight()
        {
            bookingFiltersPage.ClickSchedule();
            bool isScheduleSelected = bookingFiltersPage.IsScheduleSelected();

            AssertionsHelper.AssertEqual("True", isScheduleSelected.ToString(),
                "BUG: Schedule filter was clicked but did not get highlighted (not selected).");
        }

        /// <summary>
        /// BUG: Nonstop should highlight after click, but it does not.
        /// </summary>
        [Test]
        public void TestNonstopSelectionFailsToHighlight()
        {
            bookingFiltersPage.ClickNonstop();
            bool isNonstopSelected = bookingFiltersPage.IsNonstopSelected();

            AssertionsHelper.AssertEqual("True", isNonstopSelected.ToString(),
                "BUG: Nonstop filter was clicked but did not get highlighted (not selected).");
        }

        /// <summary>
        /// BUG: 2+ stops should highlight after click, but it does not.
        /// </summary>
        [Test]
        public void TestTwoPlusStopsSelectionFailsToHighlight()
        {
            bookingFiltersPage.ClickTwoPlusStops();
            bool isTwoPlusStopsSelected = bookingFiltersPage.IsTwoPlusStopsSelected();

            AssertionsHelper.AssertEqual("True", isTwoPlusStopsSelected.ToString(),
                "BUG: 2+ stops filter was clicked but did not get highlighted (not selected).");
        }
    }
}
