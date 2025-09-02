using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System;

namespace Utilities
{
    /// <summary>
    /// Factory class for creating WebDriver instances for different browsers.
    /// </summary>
    public static class DriverFactory
    {
        public static IWebDriver CreateDriver(string browserName)
        {
            return browserName.ToLower() switch
            {
                "chrome" => new ChromeDriver(),
                "firefox" => new FirefoxDriver(),
                "edge" => new EdgeDriver(),
                _ => throw new ArgumentException($"Browser '{browserName}' is not supported.")
            };
        }
    }
    public class WebDriverHelper
    {
        private readonly IWebDriver driver;

        public WebDriverHelper(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickElement(By locator)
        {
            driver.FindElement(locator).Click();
        }

        public void EnterText(By locator, string text)
        {
            var element = driver.FindElement(locator);
            element.Clear();
            element.SendKeys(text);
        }

        public string GetText(By locator)
        {
            return driver.FindElement(locator).Text;
        }
    }
}