/*
 * Copyright (c) 2025 Varun Reddy
 * All rights reserved.
 *
 * This source code is licensed under the terms specified by the owner.
 */
using Utilities;   // 🔹 Added Utilities reference for helpers like SeleniumHelpers, AssertionsHelper, WaitHelper

using NUnit.Framework;
using OpenQA.Selenium;
using WebAdapterClass;

namespace ScenerioClass
{
    [TestFixture] // ✅ Marks this class as a test fixture for NUnit
    public class HomepageTests
    {
        private Homepage homepage; // ✅ SRP: This class only manages homepage actions
        private IWebDriver driver; // ✅ DIP: Depends on abstraction IWebDriver, not concrete ChromeDriver

        [SetUp] // ✅ Runs before each test
        public void Setup()
        {
            // ✅ SRP: Setup is separated from actual test logic
            string browser = ConfigManager.Browser; // ✅ DIP: Configuration abstraction
            driver = DriverFactory.CreateDriver(browser); // ✅ Factory pattern: centralized driver creation

            homepage = new Homepage(driver); // ✅ LSP: Homepage implements methods expected by tests

            string appUrl = ConfigManager.GetAppUrl(); // ✅ DIP: Uses ConfigManager abstraction for URL
            homepage.NavigateToUrl(appUrl); // ✅ SRP: Navigation responsibility separated in Page Object

            driver.Manage().Window.Maximize(); // Optional: maximize window

            // ✅ Use WaitHelper to ensure page is fully loaded
            var waitHelper = new WaitHelper(driver, 10);
            waitHelper.WaitForElementVisible(By.TagName("body")); // ✅ SRP: WaitHelper encapsulates waiting logic
        }

        #region Logo & Titles

        [Test]
        public void getLogo()
        {
            // ✅ SRP: Only validates logo
            // ✅ DIP: Depends on Homepage abstraction
            // ✅ LSP: Can swap with any Homepage implementation
            homepage.PerformLogin("Vamsi", "Vamsi@134");
            Assert.DoesNotThrow(() => homepage.getLogo(), "Logo image is not displayed using Relative XPath.");
        }

        [Test]
        public void getTitle()
        {
            // ✅ SRP: Only validates title
            homepage.PerformLogin("Vamsi", "Vamsi@134");
            string actual = homepage.getTitle();
            Assert.That(actual, Is.EqualTo("Where do you\r\nwant to go?"));
        }

        [Test]
        public void GetSubtitle()
        {
            // ✅ SRP: Only validates subtitle
            homepage.PerformLogin("Varun Reddy", "Varun@13456");
            string actualSubtitle = homepage.subTitle();
            Assert.That(actualSubtitle, Is.EqualTo("Flight deals"));
        }

        [Test]
        public void GetSuggestedTitle()
        {
            // ✅ SRP: Only validates suggested title
            homepage.PerformLogin("Vamsi", "Vamsi@134");
            string actualSuggestedTitle = homepage.getSuggestTitle();
            Assert.That(actualSuggestedTitle, Is.EqualTo("Recommended for you"));
        }

        #endregion

        #region Hawaii Image & Caption

        [Test]
        public void checkHawaiiImage()
        {
            // ✅ SRP: Only checks Hawaii image
            homepage.PerformLogin("Vamsi", "Vamsi@134");
            Assert.DoesNotThrow(() => homepage.checkHawaiiImage(), "Hawaii image is not displayed using Relative XPath.");
        }

        [Test]
        public void checkHawaiiCaption()
        {
            // ✅ SRP: Only checks Hawaii caption
            homepage.PerformLogin("Vamsi", "Vamsi@134");
            string actualName = homepage.checkHawaiiCaption();
            Assert.That(actualName, Is.EqualTo("Hawaii"));
        }

        #endregion

        #region Paris Image & Caption

        [Test]
        public void checkParisImageTest()
        {
            // ✅ SRP: Only checks Paris image
            homepage.PerformLogin("Vijay", "Vijay");
            Assert.DoesNotThrow(() => homepage.checkParisImage(), "Paris image is not displayed using Relative XPath.");
        }

        [Test]
        public void checkParisCaption()
        {
            // ✅ SRP: Only checks Paris caption
            homepage.PerformLogin("Vamsi", "Vamsi@134");
            string actualName = homepage.checkParisCaption();
            Assert.That(actualName, Is.EqualTo("Paris"));
        }

        #endregion

        #region Barcelona Image & Caption

        [Test]
        public void checkBarcelonaImage()
        {
            // ✅ SRP: Only checks Barcelona image
            homepage.PerformLogin("Vamsi", "Vamsi@134");
            Assert.DoesNotThrow(() => homepage.checkBarcelonaImage(), "Barcelona image is not displayed using Relative XPath.");
        }

        [Test]
        public void checkBarcelonaCaption()
        {
            // ✅ SRP: Only checks Barcelona caption
            homepage.PerformLogin("Vamsi", "Vamsi@134");
            string actualName = homepage.checkBarcelonaCaption();
            Assert.That(actualName, Is.EqualTo("Barcelona"));
        }

        #endregion

        #region Login Test

        [Test]
        public void PerformLoginTest()
        {
            // ✅ SRP: Only tests login functionality
            // ✅ DIP: Depends on Homepage abstraction
            // ✅ OCP: Adding new login tests doesn't change existing methods
            Assert.DoesNotThrow(() => homepage.PerformLogin("Vamsi", "Vamsi@3099$4"));
        }

        #endregion

        [TearDown] // ✅ Runs after each test
        public void TearDown()
        {
            driver?.Quit();   // ✅ SRP: TearDown only handles cleanup
            driver?.Dispose();
            driver = null; // ✅ Prevent memory leaks
        }
    }
}
