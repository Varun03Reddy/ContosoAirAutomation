using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Utilities
{
    /// <summary>
    /// Provides reusable Selenium helper methods for WebDriver operations.
    /// ✅ Follows Single Responsibility Principle: only handles WebDriver element interactions.
    /// ✅ Promotes code reuse and reduces duplication in page object classes.
    /// </summary>
    public static class SeleniumHelpers
    {
        /// <summary>
        /// Waits for an element to be present in the DOM and visible on the page, then returns it.
        /// ✅ Uses explicit waits to improve test stability.
        /// </summary>
        /// <param name="driver">WebDriver instance</param>
        /// <param name="by">Locator to find the element</param>
        /// <param name="timeoutInSeconds">Maximum wait time in seconds</param>
        /// <returns>The visible IWebElement</returns>
        public static IWebElement WaitForElement(IWebDriver driver, By by, int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(drv => drv.FindElement(by));
        }

        /// <summary>
        /// Clicks an element after waiting for it to be visible.
        /// ✅ Ensures element is ready before interaction, reducing flaky tests.
        /// </summary>
        public static void ClickElement(IWebDriver driver, By by, int timeoutInSeconds = 10)
        {
            WaitForElement(driver, by, timeoutInSeconds).Click();
        }

        /// <summary>
        /// Enters text into an element after waiting for it to be visible.
        /// ✅ Clears existing text before sending new text for reliable input.
        /// </summary>
        public static void EnterText(IWebDriver driver, By by, string text, int timeoutInSeconds = 10)
        {
            var element = WaitForElement(driver, by, timeoutInSeconds);
            element.Clear();
            element.SendKeys(text);
        }

        /// <summary>
        /// Selects a dropdown option by visible text after waiting for the dropdown element.
        /// ✅ Encapsulates dropdown interaction logic for cleaner page object methods.
        /// </summary>
        public static void SelectDropdownByText(IWebDriver driver, By by, string text, int timeoutInSeconds = 10)
        {
            var element = WaitForElement(driver, by, timeoutInSeconds);
            var select = new SelectElement(element);
            select.SelectByText(text);
        }
    }
}
