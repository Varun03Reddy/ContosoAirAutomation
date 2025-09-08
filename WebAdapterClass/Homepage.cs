/*
 * Copyright (c) 2025 Varun Reddy
 * All rights reserved.
 *
 * This source code is licensed under the terms specified by the owner.
 */
using InterfaceClass;
using OpenQA.Selenium;
using Utilities;   // 🔹 Added Utilities reference
using System;

namespace WebAdapterClass
{
    /// <summary>
    /// Provides the implementation of the IHomepage interface for interacting with the homepage using Selenium WebDriver.
    /// ✅ SRP: This class only handles homepage-related actions (logo, titles, images, captions, login)
    /// ✅ DIP: Depends on abstractions (IWebDriver, IHomepage), not concrete implementations
    /// </summary>
    public class Homepage : IHomepage
    {
        /// <summary>
        /// The Selenium WebDriver instance for browser interactions.
        /// ✅ DIP: Uses IWebDriver abstraction
        /// </summary>
        private readonly IWebDriver driver;

        /// <summary>
        /// WaitHelper instance for stable element interactions.
        /// ✅ SRP: Encapsulates waiting logic
        /// </summary>
        private readonly WaitHelper waitHelper;

        /// <summary>
        /// Constructor to initialize driver and wait helper.
        /// ✅ SRP: Only responsible for dependency initialization
        /// </summary>
        public Homepage(IWebDriver webDriver)
        {
            driver = webDriver ?? throw new ArgumentNullException(nameof(webDriver));
            waitHelper = new WaitHelper(driver, 10); // 🔹 init WaitHelper with 10 sec timeout
        }

        /// <summary>
        /// Navigates to the given URL.
        /// ✅ SRP: Only responsible for navigation
        /// ✅ LSP: Any IWebDriver implementation works
        /// </summary>
        public void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Validates that the homepage logo is displayed.
        /// ✅ SRP: Only responsible for logo verification
        /// </summary>
        public void getLogo()
        {
            IWebElement logoImage = waitHelper.WaitForElementVisible(By.XPath("//img[@class='block-navbar-left-logo']"));
            if (!logoImage.Displayed)
            {
                throw new Exception("Logo image is not displayed on the homepage.");
            }
        }

        /// <summary>
        /// Returns the main title text of the homepage.
        /// ✅ SRP: Only responsible for fetching the title
        /// </summary>
        public string getTitle()
        {
            IWebElement headingElement = waitHelper.WaitForElementVisible(
                By.XPath("//span[normalize-space()='Where do youwant to go?']")
            );
            return headingElement.Text;
        }

        /// <summary>
        /// Returns the subtitle "Flight deals".
        /// ✅ SRP: Only responsible for fetching the subtitle
        /// </summary>
        public string subTitle()
        {
            IWebElement subtitleElement = waitHelper.WaitForElementVisible(
                By.XPath("//h2[normalize-space()='Flight deals']")
            );
            return subtitleElement.Text;
        }

        /// <summary>
        /// Returns the suggested title "Recommended for you".
        /// ✅ SRP: Only responsible for fetching the suggestion title
        /// </summary>
        public string getSuggestTitle()
        {
            IWebElement suggestTitleElement = waitHelper.WaitForElementVisible(
                By.XPath("//h2[normalize-space()='Recommended for you']")
            );
            return suggestTitleElement.Text;
        }

        /// <summary>
        /// Checks if Hawaii image is displayed.
        /// ✅ SRP: Only handles Hawaii image verification
        /// </summary>
        public void checkHawaiiImage()
        {
            IWebElement hawaiiImage = waitHelper.WaitForElementVisible(
                By.XPath("/html/body/main/main/div/div/div[1]/ul/li[1]/figure/img[1]")
            );
            if (!hawaiiImage.Displayed)
            {
                throw new Exception("Hawaii image is not displayed on the homepage.");
            }
        }

        /// <summary>
        /// Returns Hawaii caption text.
        /// ✅ SRP: Only responsible for fetching Hawaii caption
        /// </summary>
        public string checkHawaiiCaption()
        {
            IWebElement hawaiiCaption = waitHelper.WaitForElementVisible(
                By.XPath("//figcaption[normalize-space()='Hawaii']")
            );
            if (!hawaiiCaption.Displayed)
            {
                throw new Exception("Hawaii caption is not displayed on the homepage.");
            }
            return hawaiiCaption.Text;
        }

        /// <summary>
        /// Checks if Paris image is displayed.
        /// ✅ SRP: Only handles Paris image verification
        /// </summary>
        public void checkParisImage()
        {
            IWebElement parisImage = waitHelper.WaitForElementVisible(
                By.XPath("/html/body/main/main/div/div/div[1]/ul/li[2]/figure/img[1]")
            );
            if (!parisImage.Displayed)
            {
                throw new Exception("Paris image is not displayed on the homepage.");
            }
        }

        /// <summary>
        /// Returns Paris caption text.
        /// ✅ SRP: Only responsible for fetching Paris caption
        /// </summary>
        public string checkParisCaption()
        {
            IWebElement parisCaption = waitHelper.WaitForElementVisible(
                By.XPath("//figcaption[normalize-space()='Paris']")
            );
            if (!parisCaption.Displayed)
            {
                throw new Exception("Paris caption is not displayed on the homepage.");
            }
            return parisCaption.Text;
        }

        /// <summary>
        /// Checks if Barcelona image is displayed.
        /// ✅ SRP: Only handles Barcelona image verification
        /// </summary>
        public void checkBarcelonaImage()
        {
            IWebElement barcelonaImage = waitHelper.WaitForElementVisible(
                By.XPath("/html/body/main/main/div/div/div[1]/ul/li[3]/figure/img[1]")
            );
            if (!barcelonaImage.Displayed)
            {
                throw new Exception("Barcelona image is not displayed on the homepage.");
            }
        }

        /// <summary>
        /// Returns Barcelona caption text.
        /// ✅ SRP: Only responsible for fetching Barcelona caption
        /// </summary>
        public string checkBarcelonaCaption()
        {
            IWebElement barcelonaCaption = waitHelper.WaitForElementVisible(
                By.XPath("//figcaption[normalize-space()='Barcelona']")
            );
            if (!barcelonaCaption.Displayed)
            {
                throw new Exception("Barcelona caption is not displayed on the homepage.");
            }
            return barcelonaCaption.Text;
        }

        /// <summary>
        /// Performs login with the given username and password.
        /// ✅ SRP: Only handles login functionality
        /// ✅ OCP: Can extend to different login flows without changing existing method
        /// </summary>
        public void PerformLogin(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Username and password cannot be null or empty");
            }

            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("username")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.CssSelector(".btn")).Click();
        }
    }
}
