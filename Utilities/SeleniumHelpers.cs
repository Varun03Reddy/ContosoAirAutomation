using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Utilities
{
    /// <summary>
    /// Provides reusable Selenium helper methods for WebDriver operations.
    /// </summary>
    public static class SeleniumHelpers
    {
        /// <summary>
        /// Waits for an element to be visible and returns it.
        /// </summary>
        public static IWebElement WaitForElement(IWebDriver driver, By by, int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(drv => drv.FindElement(by));
        }

        /// <summary>
        /// Clicks an element after waiting for it to be visible.
        /// </summary>
        public static void ClickElement(IWebDriver driver, By by, int timeoutInSeconds = 10)
        {
            WaitForElement(driver, by, timeoutInSeconds).Click();
        }

        /// <summary>
        /// Enters text into an element after waiting for it to be visible.
        /// </summary>
        public static void EnterText(IWebDriver driver, By by, string text, int timeoutInSeconds = 10)
        {
            var element = WaitForElement(driver, by, timeoutInSeconds);
            element.Clear();
            element.SendKeys(text);
        }

        /// <summary>
        /// Selects a dropdown value by text.
        /// </summary>
        public static void SelectDropdownByText(IWebDriver driver, By by, string text, int timeoutInSeconds = 10)
        {
            var element = WaitForElement(driver, by, timeoutInSeconds);
            var select = new SelectElement(element);
            select.SelectByText(text);
        }
    }
}