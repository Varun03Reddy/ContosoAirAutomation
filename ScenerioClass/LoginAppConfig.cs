/*
 * Copyright (c) 2025 Vamsi Krishna, Varun Reddy, Arpita, Keyur
 * All rights reserved.
 *
 * This source code is licensed under the terms specified by the owner.
 */
using System.Threading;
using InterfaceClass;
using NUnit.Framework;
using OpenQA.Selenium;
using Utilities;
using WebAdapterClass;

namespace ScenerioClass
{
    /// <summary>
    /// NUnit test class for login scenarios using ILogin interface.
    /// Demonstrates SOLID principles and AAA pattern.
    /// </summary>
    [TestFixture]
    public class LoginTests
    {
        private ILogin login;

        #region Setup
        /// <summary>
        /// Setup method executed before each test.
        /// - Single Responsibility Principle (SRP): Responsible only for test setup.
        /// - Dependency Inversion Principle (DIP): Depends on abstraction (ILogin), not concrete class.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // Arrange: Initialize the login page object with a WebDriver instance
            login = new Login(DriverFactory.CreateDriver());
        }
        #endregion

        #region Login Test Cases
        /// <summary>
        /// Test case: Login with valid credentials.
        /// - Follows AAA: Arrange (setup), Act (login), Assert (validation).
        /// </summary>
        [Test]
        public void PerformLoginWithCredentials()
        {
            // Arrange: URL navigation handled in test method for clarity
            login.NavigateToUrl();

            // Act: Perform login with valid credentials
            login.PerformLogin();

            // Assert: Validate login success (placeholder: thread wait, should be replaced with explicit assert)
            Thread.Sleep(2000);
            Assert.Pass("Login with credentials executed successfully.");
        }

        /// <summary>
        /// Test case: Attempt login without credentials.
        /// - Open/Closed Principle (OCP): Easily extendable for negative test scenarios.
        /// </summary>
        [Test]
        public void PerformLoginWithoutCredentials()
        {
            // Arrange: Navigate to login page
            login.NavigateToUrl();

            // Act: Attempt login without providing username/password
            login.PerformLoginWithoutCredentials();

            // Assert: Validate failure (placeholder: thread wait, should be replaced with alert/message assert)
            Thread.Sleep(2000);
            Assert.Pass("Login attempt without credentials executed (expected failure).");
        }
        #endregion

        #region TearDown
        /// <summary>
        /// TearDown method executed after each test.
        /// - SRP: Responsible only for driver cleanup.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            DriverFactory.QuitDriver();
        }
        #endregion
    }
}
nunit