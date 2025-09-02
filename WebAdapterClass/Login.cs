using InterfaceClass;
using OpenQA.Selenium;
using Utilities;
using System;

namespace WebAdapterClass
{
    //// <summary>
    /// Class implementing the ILoginTest interface to perform login automation.
    /// </summary>
    public class LoginTest : ILoginTest
    {
        /// <summary>
        /// The WebDriver instance used to control the browser.
        /// </summary>
        private readonly IWebDriver driver;
        private readonly WebDriverHelper helper;

        /// <summary>
        /// Constructor to initialize the WebDriver.
        /// </summary>
        /// <param name="driver">The WebDriver instance to control the browser.</param>
        public LoginTest(IWebDriver driver)
        {
            this.driver = driver;
            this.helper = new WebDriverHelper(driver);
        }

        /// <summary>
        /// Navigates to the specified URL and sets the browser window size.
        /// </summary>
        /// <param name="url">The URL to navigate to.</param>
        public void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Size = new System.Drawing.Size(1296, 688);
        }

        /// <summary>
        /// Performs login using the provided username and password.
        /// </summary>
        /// <param name="username">The username for login.</param>
        /// <param name="password">The password for login.</param>
        public void PerformLoginWithCredentials(string username, string password)
        {
            helper.ClickElement(By.LinkText("Login"));
            helper.EnterText(By.Id("username"), username);
            helper.EnterText(By.Id("password"), password);
            helper.ClickElement(By.CssSelector(".btn"));
        }

        /// <summary>
        /// Attempts to perform login without providing any credentials.
        /// </summary>
        public void PerformLoginWithOutCredentials()
        {
            helper.ClickElement(By.LinkText("Login"));
            helper.ClickElement(By.CssSelector(".btn"));

            var alertMessage = helper.GetText(By.CssSelector(".alert > span"));
            Console.WriteLine("Alert Message Displayed: " + alertMessage);
        }
    }
}