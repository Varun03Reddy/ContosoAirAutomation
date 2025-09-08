/*
 * Copyright (c) 2025 Arpita
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
    /// Implements the <see cref="IViewDatesPage"/> interface.
    /// ✅ SRP: This class is only responsible for interacting with the "View Dates" buttons on the flight deals page.
    /// ✅ DIP: Depends on abstractions like IWebDriver and SeleniumHelpers, not concrete implementations.
    /// </summary>
    public class ViewDatesPage : IViewDatesPage
    {
        /// <summary>
        /// The WebDriver instance for interacting with the browser.
        /// </summary>
        private readonly IWebDriver driver;

        /// <summary>
        /// Constructor initializes the WebDriver and navigates to the base URL.
        /// ✅ SRP: Only responsible for initialization.
        /// </summary>
        public ViewDatesPage()
        {
            // ✅ Use factory to create driver (supports OCP for browser changes)
            driver = DriverFactory.CreateDriver("chrome");

            // ✅ Navigate to the base application URL (ConfigManager handles configuration)
            driver.Navigate().GoToUrl(ConfigManager.BaseUrl);
        }

        /// <summary>
        /// Clicks the "View Dates" button for a specified flight deal index.
        /// </summary>
        /// <param name="dealIndex">1-based index of the flight deal.</param>
        public void ClickViewDates(int dealIndex)
        {
            // ✅ SRP: Single responsibility – just clicks the button
            // Using a CSS selector for stability and maintainability
            string viewDatesButtonCss = $"ul > li:nth-child({dealIndex}) .btn";
            SeleniumHelpers.ClickElement(driver, By.CssSelector(viewDatesButtonCss));
        }

        /// <summary>
        /// Returns the title of the page after clicking "View Dates".
        /// Currently hardcoded to simulate a failure scenario for testing.
        /// </summary>
        /// <returns>Incorrect page title (for demonstration).</returns>
        public string GetPageTitle()
        {
            // ✅ OCP: This method can be extended to return the actual title later
            // Currently simulates a failed navigation scenario
            return "This Is The Wrong Title!";
        }

        /// <summary>
        /// Closes the WebDriver and quits the browser.
        /// ✅ SRP: Only responsible for cleanup.
        /// </summary>
        public void Close()
        {
            driver.Quit();
        }
    }
}
