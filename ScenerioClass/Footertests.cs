/*
 * Copyright (c) 2025 Varun Reddy
 * All rights reserved.
 *
 * This source code is licensed under the terms specified by the owner.
 */
using NUnit.Framework;
using OpenQA.Selenium;
using WebAdapterClass;
using Utilities;

namespace ScenarioClass
{
    /// <summary>
    /// Test suite for ContosoAir website footer links.
    /// Each test verifies that a specific footer link is clickable or throws an exception when not found.
    /// Uses NUnit as the test framework and Selenium WebDriver for browser automation.
    /// </summary>
    [TestFixture]
    public class FooterTests
    {
        private IWebDriver driver; // DIP: Using IWebDriver abstraction
        private Footer footer;     // Footer page object implementing footer interactions

        /// <summary>
        /// Setup before each test.
        /// Initializes WebDriver, Footer page, navigates to the app URL, and ensures the page is loaded.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // ✅ Get browser type from ConfigManager (default = chrome)
            string browser = ConfigManager.Browser;
            driver = DriverFactory.CreateDriver(browser); // Factory pattern

            // ✅ Initialize Footer page object with driver (LSP)
            footer = new Footer(driver);

            // ✅ Navigate to app URL from configuration
            string appUrl = ConfigManager.GetAppUrl();
            driver.Navigate().GoToUrl(appUrl);

            // ✅ Optional: maximize browser window
            driver.Manage().Window.Maximize();

            // ✅ Use WaitHelper to ensure page is fully loaded before running tests
            var waitHelper = new WaitHelper(driver, 10);
            waitHelper.WaitForElementVisible(By.TagName("body")); // simple body check
        }

        #region ABOUT CONTOSO
        [Test] public void WhoWeAreTest() => Assert.Throws<Exception>(() => footer.ClickWhoWeAre());
        [Test] public void ContactUsTest() => Assert.Throws<Exception>(() => footer.ClickContactUs());
        [Test] public void TravelAdvisoriesTest() => Assert.Throws<Exception>(() => footer.ClickTravelAdvisories());
        [Test] public void CustomerCommitmentTest() => Assert.Throws<Exception>(() => footer.ClickCustomerCommitment());
        [Test] public void FeedbackTest() => Assert.Throws<Exception>(() => footer.ClickFeedback());
        [Test] public void PrivacyNoticeTest() => Assert.Throws<Exception>(() => footer.ClickPrivacyNotice());
        #endregion

        #region CUSTOMER SERVICE
        [Test] public void CareersTest() => Assert.Throws<Exception>(() => footer.ClickCareers());
        [Test] public void LegalTest() => Assert.Throws<Exception>(() => footer.ClickLegal());
        [Test] public void NewsroomTest() => Assert.Throws<Exception>(() => footer.ClickNewsroom());
        [Test] public void InvestorRelationsTest() => Assert.Throws<Exception>(() => footer.ClickInvestorRelations());
        [Test] public void ContractOfCarriageTest() => Assert.Throws<Exception>(() => footer.ClickContractOfCarriage());
        [Test] public void TarmacDelayPlanTest() => Assert.Throws<Exception>(() => footer.ClickTarmacDelayPlan());
        [Test] public void SiteMapTest() => Assert.Throws<Exception>(() => footer.ClickSiteMap());
        #endregion

        #region PRODUCTS AND SERVICES
        [Test] public void OptionalServicesAndFeesTest() => Assert.Throws<Exception>(() => footer.ClickOptionalServicesAndFees());
        [Test] public void CorporateTravelTest() => Assert.Throws<Exception>(() => footer.ClickCorporateTravel());
        [Test] public void TravelAgentsTest() => Assert.Throws<Exception>(() => footer.ClickTravelAgents());
        [Test] public void CargoTest() => Assert.Throws<Exception>(() => footer.ClickCargo());
        [Test] public void GiftCertificatesTest() => Assert.Throws<Exception>(() => footer.ClickGiftCertificates());
        [Test] public void FollowUsTest() => Assert.Throws<Exception>(() => footer.ClickFollowUs());
        #endregion

        /// <summary>
        /// Cleanup after each test.
        /// Quits and disposes the WebDriver instance to free resources.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            driver?.Quit();
            driver?.Dispose();
            driver = null;
        }
    }
}
