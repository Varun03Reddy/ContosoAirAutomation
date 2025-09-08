/*
 * Copyright (c) 2025 Keyur
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
    /// Class implementing the ILoginTest interface to perform login automation.
    /// ✅ SRP: This class only handles login-related operations
    /// ✅ DIP: Depends on abstractions (IWebDriver, ILoginTest) not concrete implementations
    /// </summary>
    public class LoginTest : ILoginTest
    {
        /// <summary>
        /// The WebDriver instance used to control the browser.
        /// ✅ DIP: Depends on IWebDriver abstraction
        /// </summary>
        private readonly IWebDriver driver;

        /// <summary>
        /// Helper class for Selenium interactions
        /// ✅ SRP: Encapsulates element interactions, not login logic
        /// </summary>
        private readonly WebDriverHelper helper;

        /// <summary>
        /// Constructor to initialize the WebDriver.
        /// ✅ SRP: Only responsibility is to set up dependencies
        /// ✅ DIP: Accepts IWebDriver abstraction
        /// </summary>
        /// <param name="driver">The WebDriver instance to control the browser.</param>
        public LoginTest(IWebDriver driver)
        {
            this.driver = driver;
            this.helper = new WebDriverHelper(driver); // ✅ SRP: Delegates element interaction logic
        }

        /// <summary>
        /// Navigates to the specified URL and sets the browser window size.
        /// ✅ SRP: Only handles navigation
        /// ✅ LSP: Can replace with any IWebDriver implementation without breaking code
        /// </summary>
        /// <param name="url">The URL to navigate to.</param>
        public void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Size = new System.Drawing.Size(1296, 688);
        }

        /// <summary>
        /// Performs login using the provided username and password.
        /// ✅ SRP: Only responsible for performing a valid login
        /// ✅ OCP: Adding more login variations won't change existing method
        /// </summary>
        /// <param name="username">The username for login.</param>
        /// <param name="password">The password for login.</param>
        public void PerformLoginWithCredentials(string username, string password)
        {
            helper.ClickElement(By.LinkText("Login"));
            helper.EnterText(By.Id("username"), username);
            helper.EnterText(By.Id("password"), password);
            helper.ClickElement(By.CssSelector(".btn"));
        }

        /// <summary>
        /// Attempts to perform login without providing any credentials.
        /// ✅ SRP: Only handles invalid login scenario
        /// ✅ OCP: Can extend to handle other invalid cases without modifying this method
        /// </summary>
        public void PerformLoginWithOutCredentials()
        {
            helper.ClickElement(By.LinkText("Login"));
            helper.ClickElement(By.CssSelector(".btn"));

            var alertMessage = helper.GetText(By.CssSelector(".alert > span"));
            Console.WriteLine("Alert Message Displayed: " + alertMessage); // ✅ SRP: Only logs message
        }
    }
}
