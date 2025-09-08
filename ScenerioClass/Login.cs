/*
 * Copyright (c) 2025 Keyur
 * All rights reserved.
 *
 * This source code is licensed under the terms specified by the owner.
 */
using InterfaceClass;
using OpenQA.Selenium;
using Utilities;
using WebAdapterClass;
using NUnit.Framework;
using System.Threading;

namespace ScenerioClass
{
    // Scenario class for executing the login test
    [TestFixture]
    public class LoginScenario
    {
        private IWebDriver driver;
        private ILoginTest loginTest;

        /// <summary>
        /// Initializes the WebDriver and login test setup before each test.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            // Initialize WebDriver using DriverFactory (utility)
            driver = DriverFactory.CreateDriver("chrome");
            loginTest = new LoginTest(driver);
        }

        /// <summary>
        /// Test to perform login with valid credentials.
        /// </summary>
        [Test]
        public void PerformLoginWithCredentials()
        {
            string url = "http://localhost:3000/";
            string username = "Vijay";
            string password = "Vijay";

            loginTest.NavigateToUrl(url);
            loginTest.PerformLoginWithCredentials(username, password);

            Thread.Sleep(2000);
        }

        /// <summary>
        /// Test to perform login without providing any credentials.
        /// </summary>
        [Test]
        public void PerformLoginWithOutCredentials()
        {
            string url = "http://localhost:3000/";

            loginTest.NavigateToUrl(url);
            loginTest.PerformLoginWithOutCredentials();

            Thread.Sleep(2000);
        }

        /// <summary>
        /// Cleans up the WebDriver after each test execution.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            driver?.Dispose();
        }
    }
}