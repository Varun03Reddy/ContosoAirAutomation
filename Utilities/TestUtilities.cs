using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Utilities
{
    /// <summary>
    /// Provides helper methods for Selenium actions and waits.
    /// </summary>
    public static class TestUtilities
    {
        private static readonly int defaultTimeout = 10;

        /// <summary>
        /// Waits until an element is visible.
        /// </summary>
        public static IWebElement WaitForElementVisible(IWebDriver driver, By locator, int timeout = 0)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout > 0 ? timeout : defaultTimeout));
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        /// <summary>
        /// Waits until an element is clickable.
        /// </summary>
        public static IWebElement WaitForElementClickable(IWebDriver driver, By locator, int timeout = 0)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout > 0 ? timeout : defaultTimeout));
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        /// <summary>
        /// Clicks an element safely with wait.
        /// </summary>
        public static void SafeClick(IWebDriver driver, By locator)
        {
            WaitForElementClickable(driver, locator).Click();
        }

        /// <summary>
        /// Enters text safely with wait.
        /// </summary>
        public static void SafeEnterText(IWebDriver driver, By locator, string text)
        {
            var element = WaitForElementVisible(driver, locator);
            element.Clear();
            element.SendKeys(text);
        }
    }
}