using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System;

namespace Utilities
{
    /// <summary>
    /// Factory class for creating WebDriver instances for different browsers.
    /// ✅ Follows the Factory design pattern.
    /// ✅ Adheres to Open/Closed principle: easy to extend with new browsers without modifying existing code.
    /// </summary>
    public static class DriverFactory
    {
        /// <summary>
        /// Creates a new IWebDriver instance based on the browser name.
        /// </summary>
        /// <param name="browserName">Name of the browser (chrome, firefox, edge)</param>
        /// <returns>IWebDriver instance for the requested browser</returns>
        /// <exception cref="ArgumentException">Thrown if the browser is not supported</exception>
        public static IWebDriver CreateDriver(string browserName)
        {
            return browserName.ToLower() switch
            {
                "chrome" => new ChromeDriver(),   // ✅ Chrome driver
                "firefox" => new FirefoxDriver(), // ✅ Firefox driver
                "edge" => new EdgeDriver(),       // ✅ Edge driver
                _ => throw new ArgumentException($"Browser '{browserName}' is not supported.") // ❌ Error handling for unsupported browsers
            };
        }
    }

    /// <summary>
    /// Helper class to encapsulate common Selenium WebDriver actions.
    /// ✅ Follows Single Responsibility Principle: only handles WebDriver interactions.
    /// ✅ Promotes code reuse and avoids repeating FindElement logic in tests.
    /// </summary>
    public class WebDriverHelper
    {
        private readonly IWebDriver driver;

        /// <summary>
        /// Constructor accepts a WebDriver instance.
        /// ✅ Supports Dependency Injection.
        /// </summary>
        /// <param name="driver">IWebDriver instance to wrap</param>
        public WebDriverHelper(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
        }

        /// <summary>
        /// Clicks an element identified by the locator.
        /// </summary>
        /// <param name="locator">By locator to find the element</param>
        public void ClickElement(By locator)
        {
            driver.FindElement(locator).Click();
        }

        /// <summary>
        /// Enters text into an input element after clearing its content.
        /// </summary>
        /// <param name="locator">By locator to find the element</param>
        /// <param name="text">Text to enter</param>
        public void EnterText(By locator, string text)
        {
            var element = driver.FindElement(locator);
            element.Clear();       // ✅ Clear existing text
            element.SendKeys(text); // ✅ Enter new text
        }

        /// <summary>
        /// Returns the visible text of an element.
        /// </summary>
        /// <param name="locator">By locator to find the element</param>
        /// <returns>Text content of the element</returns>
        public string GetText(By locator)
        {
            return driver.FindElement(locator).Text;
        }
    }
}
