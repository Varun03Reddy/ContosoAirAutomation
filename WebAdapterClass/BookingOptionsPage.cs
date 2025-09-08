/*
 * Copyright (c) 2025 Keyur
 * All rights reserved.
 *
 * This source code is licensed under the terms specified by the owner.
 */
using InterfaceClass; // Interface segregation principle: IBookingOptions contains only booking-related methods
using OpenQA.Selenium; // Selenium WebDriver for browser automation
using Utilities; // Helper classes like SeleniumHelpers and ConfigManager
using System;

namespace WebAdapterClass
{
    /// <summary>
    /// Implementation of IBookingOptions interface for interacting with booking options.
    /// Handles actions like login, navigating to booking page, and selecting booking options.
    /// </summary>
    public class BookingOptionsPage : IBookingOptions
    {
        private IWebDriver driver; // DIP: Depends on abstraction (IWebDriver) instead of concrete browser

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingOptionsPage"/> class.
        /// </summary>
        /// <param name="driver">The WebDriver instance.</param>
        public BookingOptionsPage(IWebDriver driver)
        {
            this.driver = driver; // LSP: Any IWebDriver implementation can be passed
        }

        /// <summary>
        /// Performs login action with the provided username and password.
        /// </summary>
        public void Login(string username, string password)
        {
            // Navigate to the base application URL from configuration
            driver.Navigate().GoToUrl(ConfigManager.GetAppUrl());

            // Set browser window size to a fixed dimension for consistent UI interaction
            driver.Manage().Window.Size = new System.Drawing.Size(1296, 688);

            // SRP: Use SeleniumHelpers for reusable, single-responsibility methods
            SeleniumHelpers.ClickElement(driver, By.LinkText("Login")); // Click login link
            SeleniumHelpers.EnterText(driver, By.Id("username"), username); // Enter username
            SeleniumHelpers.EnterText(driver, By.Id("password"), password); // Enter password
            SeleniumHelpers.ClickElement(driver, By.CssSelector(".btn")); // Click submit button
        }

        /// <summary>
        /// Navigates to the booking page from the main page.
        /// </summary>
        public void NavigateToBookingPage()
        {
            // Click the "Book" link to navigate to the booking page
            SeleniumHelpers.ClickElement(driver, By.LinkText("Book"));
        }

        /// <summary>
        /// Clicks the "One way" booking option button.
        /// </summary>
        public void ClickOneWay()
        {
            // XPath targets the "One way" button specifically
            SeleniumHelpers.ClickElement(driver, By.XPath("//*[@id=\"app\"]/main/div/main/div/div[1]/booking/div[1]/div[2]"));
        }

        /// <summary>
        /// Clicks the "Multi-city" booking option button.
        /// </summary>
        public void ClickMultiCity()
        {
            // XPath targets the "Multi-city" button specifically
            SeleniumHelpers.ClickElement(driver, By.XPath("//*[@id=\"app\"]/main/div/main/div/div[1]/booking/div[1]/div[3]"));
        }

        /// <summary>
        /// Checks if the "Return Date" input field is visible on the page.
        /// </summary>
        /// <returns>True if the element is visible, otherwise false.</returns>
        public bool IsReturnDateVisible()
        {
            try
            {
                // Attempt to find the element with ID "dpb"
                var returnDateElement = driver.FindElement(By.Id("dpb"));
                return returnDateElement.Displayed; // Returns true if visible
            }
            catch (NoSuchElementException)
            {
                // If element is not found, it is not visible
                return false;
            }
        }

        /// <summary>
        /// Closes the WebDriver and terminates the browser session.
        /// </summary>
        public void Close()
        {
            driver.Quit(); // SRP: This method only handles browser closure
        }
    }
}
