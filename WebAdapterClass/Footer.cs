/*
 * Copyright (c) 2025 Varun Reddy
 * All rights reserved.
 *
 * This source code is licensed under the terms specified by the owner.
 */
using InterfaceClass;
using OpenQA.Selenium;
using Utilities;
using System;

namespace WebAdapterClass
{
    /// <summary>
    /// Selenium implementation of the IFooter interface.
    /// Provides methods to interact with the footer links on the ContosoAir website.
    /// Each method clicks a specific footer link and verifies that the page navigation occurred.
    /// </summary>
    public class Footer : IFooter
    {
        private readonly IWebDriver driver;       // WebDriver abstraction (DIP)
        private readonly WaitHelper waitHelper;   // Wait helper for stable element interactions

        /// <summary>
        /// Constructor initializes WebDriver and WaitHelper.
        /// </summary>
        /// <param name="webDriver">Selenium WebDriver instance</param>
        public Footer(IWebDriver webDriver)
        {
            driver = webDriver ?? throw new ArgumentNullException(nameof(webDriver));
            waitHelper = new WaitHelper(driver, 10); // 10-second explicit wait for stability
        }

        #region ABOUT CONTOSO
        public void ClickWhoWeAre() => ClickFooterLink("Who we are");
        public void ClickContactUs() => ClickFooterLink("Contact us");
        public void ClickTravelAdvisories() => ClickFooterLink("Travel advisories");
        public void ClickCustomerCommitment() => ClickFooterLink("Customer commitment");
        public void ClickFeedback() => ClickFooterLink("Feedback");
        public void ClickPrivacyNotice() => ClickFooterLink("Privacy notice");
        #endregion

        #region CUSTOMER SERVICE
        public void ClickCareers() => ClickFooterLink("Careers");
        public void ClickLegal() => ClickFooterLink("Legal");
        public void ClickNewsroom() => ClickFooterLink("Newsroom");
        public void ClickInvestorRelations() => ClickFooterLink("Investor relations");
        public void ClickContractOfCarriage() => ClickFooterLink("Contract of carriage");
        public void ClickTarmacDelayPlan() => ClickFooterLink("Tarmac delay plan");
        public void ClickSiteMap() => ClickFooterLink("Site map");
        #endregion

        #region PRODUCTS AND SERVICES
        public void ClickOptionalServicesAndFees() => ClickFooterLink("Optional services and fees");
        public void ClickCorporateTravel() => ClickFooterLink("Corporate travel");
        public void ClickTravelAgents() => ClickFooterLink("Travel agents");
        public void ClickCargo() => ClickFooterLink("Cargo");
        public void ClickGiftCertificates() => ClickFooterLink("Gift certificates");
        public void ClickFollowUs() => ClickFooterLink("Follow us");
        #endregion

        /// <summary>
        /// Generic method to click a footer link and verify navigation.
        /// Throws exception if the URL does not change after clicking.
        /// </summary>
        /// <param name="linkText">Exact link text of the footer element</param>
        private void ClickFooterLink(string linkText)
        {
            // Capture the current URL for comparison
            string currentUrl = driver.Url;

            // Wait until the link is visible on the page and click it
            IWebElement linkElement = waitHelper.WaitForElementVisible(By.LinkText(linkText));
            linkElement.Click();

            // Optional wait to allow page navigation (adjustable if needed)
            System.Threading.Thread.Sleep(2000);

            // Validate navigation: if URL is unchanged, throw exception
            if (driver.Url == currentUrl)
            {
                throw new Exception($"Navigation failed. Clicking '{linkText}' did not change the page.");
            }
        }
    }
}
