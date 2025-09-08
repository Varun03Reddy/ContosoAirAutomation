/*
 * Copyright (c) 2025 Arpita
 * All rights reserved.
 *
 * This source code is licensed under the terms specified by the owner.
 */
using NUnit.Framework;
using WebAdapterClass;
using InterfaceClass;
using Utilities;
using System;

namespace ScenerioClass
{
    /// <summary>
    /// Test fixture for verifying the "View Dates" feature on flight deals.
    /// ✅ SRP: This class is only responsible for testing view dates functionality.
    /// ✅ DIP: Depends on IViewDatesPage abstraction instead of a concrete implementation.
    /// </summary>
    [TestFixture]
    public class ViewDatesTests
    {
        /// <summary>
        /// Abstraction for the view dates page.
        /// ✅ DIP: Can swap different implementations of IViewDatesPage without modifying tests.
        /// </summary>
        private IViewDatesPage viewDatesPage;

        /// <summary>
        /// Setup method executed before each test.
        /// ✅ SRP: Only responsible for initializing dependencies.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            // Initialize the page object for "View Dates"
            viewDatesPage = new ViewDatesPage();
        }

        /// <summary>
        /// Tear down method executed after each test.
        /// ✅ SRP: Only responsible for cleanup and closing the driver.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            viewDatesPage.Close();
        }

        /// <summary>
        /// Verifies that clicking the "View Dates" button navigates to the correct page.
        /// ✅ SRP: Single responsibility – validate navigation from button click.
        /// ✅ OCP: Test logic can be extended for multiple deals without modifying existing code.
        /// </summary>
        [Test]
        public void VerifyViewDatesButtonNavigatesToCorrectPage()
        {
            // Action: Click the "View Dates" button for the first deal
            viewDatesPage.ClickViewDates(1);

            // Assert: We expect the page title to be "Contoso Air"
            string expectedPageTitle = "Contoso Air";

            // Actual title returned by the page object
            string actualPageTitle = viewDatesPage.GetPageTitle();

            // Assertion using helper for better reporting and reusability
            AssertionsHelper.AssertEqual(expectedPageTitle, actualPageTitle,
                "The 'View Dates' button does not navigate to the correct page. The page title is incorrect.");
        }
    }
}
