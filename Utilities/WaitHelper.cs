using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Utilities
{
    /// <summary>
    /// Provides explicit wait utilities for Selenium WebDriver operations.
    /// ✅ Single Responsibility Principle (SRP): This class only handles waits for elements.
    /// ✅ Promotes reusability and avoids duplicated wait code across page objects or tests.
    /// </summary>
    public class WaitHelper
    {
        private readonly IWebDriver driver;   // The WebDriver instance
        private readonly WebDriverWait wait;  // Reusable WebDriverWait instance

        /// <summary>
        /// Constructor to initialize the WaitHelper with a WebDriver and timeout.
        /// </summary>
        /// <param name="driver">Selenium WebDriver instance</param>
        /// <param name="timeoutInSeconds">Optional timeout, default is 10 seconds</param>
        public WaitHelper(IWebDriver driver, int timeoutInSeconds = 10)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        }

        /// <summary>
        /// Waits for an element to be visible (static method, can be used without instantiating WaitHelper)
        /// ✅ Useful for one-off waits outside of page objects.
        /// </summary>
        public static IWebElement WaitForElementVisible(IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        /// <summary>
        /// Waits for an element to be visible using the instance WebDriverWait.
        /// ✅ Preferred for repeated waits within page objects (avoids creating new WebDriverWait each time).
        /// </summary>
        public IWebElement WaitForElementVisible(By locator)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        /// <summary>
        /// Waits for an element to be clickable using the instance WebDriverWait.
        /// ✅ Ensures element can be safely clicked without causing ElementNotInteractableException.
        /// </summary>
        public IWebElement WaitForElementClickable(By locator)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }

        /// <summary>
        /// Waits for any element to exist in the DOM using a lambda expression.
        /// ✅ Flexible for custom conditions where visibility is not required.
        /// </summary>
        public static IWebElement WaitForElement(IWebDriver driver, By by, int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(drv => drv.FindElement(by));
        }
    }
}
