/*
 * Copyright (c) 2025 Vamsi Krishna, Varun Reddy, Arpita, Keyur
 * All rights reserved.
 *
 * This source code is licensed under the terms specified by the owner.
 */

using InterfaceClass;
using OpenQA.Selenium;
using Utilities;
using System;
using System.Drawing;

namespace WebAdapterClass
{
    /// <summary>
    /// Implements login actions using the ILogin interface.
    /// - Reads BaseUrl internally from ConfigManager.
    /// - Encapsulates Selenium WebDriver operations for login.
    /// - Demonstrates SOLID principles.
    /// </summary>
    public class Login : ILogin
    {
        private readonly IWebDriver driver;

        /// <summary>
        /// Constructor injects the WebDriver dependency.
        /// - DIP (Dependency Inversion Principle): depends on abstraction IWebDriver, not concrete ChromeDriver.
        /// - SRP (Single Responsibility Principle): Responsible only for login-related actions.
        /// </summary>
        /// <param name="driver">Injected WebDriver instance from DriverFactory.</param>
        public Login(IWebDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// Navigate to the BaseUrl configured in ConfigManager.
        /// - SRP: Only responsible for navigation.
        /// - OCP: Can extend navigation logic (maximize, resize) without modifying method core.
        /// </summary>
        public void NavigateToUrl()
        {
            driver.Navigate().GoToUrl(ConfigManager.BaseUrl);
            driver.Manage().Window.Size = new Size(1296, 688); // Resize for consistency
        }

        /// <summary>
        /// Perform login with credentials.
        /// - LSP (Liskov Substitution Principle): Any ILogin implementation can be swapped (e.g., mobile login).
        /// - OCP: Easy to extend by fetching username/password from ConfigManager instead of hardcoding.
        /// </summary>
        public void PerformLogin()
        {
            // Arrange: Locate login elements
            driver.FindElement(By.LinkText("Login")).Click();

            // Act: Enter credentials (currently hardcoded for demo)
            driver.FindElement(By.Id("username")).SendKeys("Varun");   // Can use ConfigManager.Username
            driver.FindElement(By.Id("password")).SendKeys("Varun");   // Can use ConfigManager.Password
            driver.FindElement(By.CssSelector(".btn")).Click();

            // Assert: Should validate login success (left for test layer, not here)
        }

        /// <summary>
        /// Attempt login without credentials to validate error handling.
        /// - ISP (Interface Segregation Principle): Only methods relevant to login are exposed in ILogin.
        /// - SRP: Focused on negative login flow.
        /// </summary>
        public void PerformLoginWithoutCredentials()
        {
            // Arrange: Open login form
            driver.FindElement(By.LinkText("Login")).Click();

            // Act: Click login button without entering data
            driver.FindElement(By.CssSelector(".btn")).Click();

            // Assert: Capture and log alert message (assertion should be in test class)
            string alertMessage = driver.FindElement(By.CssSelector(".alert > span")).Text;
            Console.WriteLine("Alert Message Displayed: " + alertMessage);
        }
    }
}