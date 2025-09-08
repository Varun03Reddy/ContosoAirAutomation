using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Utilities
{
    /// <summary>
    /// Provides helper methods for Selenium actions and waits.
    /// ✅ Follows Single Responsibility Principle (SRP): only deals with waits and safe interactions.
    /// ✅ Promotes code reuse and reduces duplication in page objects or test scripts.
    /// </summary>
    public static class TestUtilities
    {
        // Default timeout in seconds for waiting for elements
        private static readonly int defaultTimeout = 10;

        /// <summary>
        /// Waits until an element is visible on the page.
        /// ✅ Improves test stability by ensuring the element is ready before interaction.
        /// </summary>
        /// <param name="driver">WebDriver instance</param>
        /// <param name="locator">Locator of the element</param>
        /// <param name="timeout">Optional timeout in seconds (uses default if 0)</param>
        /// <returns>The visible IWebElement</returns>
        public static IWebElement WaitForElementVisible(IWebDriver driver, By locator, int timeout = 0)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout > 0 ? timeout : defaultTimeout));
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        /// <summary>
        /// Waits until an element is clickable.
        /// ✅ Ensures the element can be clicked safely, avoiding ElementNotInteractableException.
        /// </summary>
        public static IWebElement WaitForElementClickable(IWebDriver driver, By locator, int timeout = 0)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout > 0 ? timeout : defaultTimeout));
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        /// <summary>
        /// Clicks an element safely, waiting for it to be clickable first.
        /// ✅ Combines wait and click into a reusable method.
        /// </summary>
        public static void SafeClick(IWebDriver driver, By locator)
        {
            WaitForElementClickable(driver, locator).Click();
        }

        /// <summary>
        /// Enters text safely into an element after waiting for it to be visible.
        /// ✅ Clears existing text before sending new text for reliability.
        /// </summary>
        public static void SafeEnterText(IWebDriver driver, By locator, string text)
        {
            var element = WaitForElementVisible(driver, locator);
            element.Clear();
            element.SendKeys(text);
        }
    }
}
