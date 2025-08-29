

using InterfaceClass;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAdapterClass
{

    /// <summary>
    /// Provides the implementation of the IHomepage interface for interacting with the homepage using Selenium WebDriver.
    /// </summary>
    public class Homepage : IHomepage
    {
        private readonly IWebDriver driver;

        /// <summary>
        /// Initializes a new instance of the Homepage class.
        /// </summary>
        /// <param name="webDriver">An instance of IWebDriver for browser interaction.</param>
        /// <exception cref="ArgumentNullException">Thrown if webDriver is null.</exception>
        public Homepage(IWebDriver webDriver)
        {
            driver = webDriver ?? throw new ArgumentNullException(nameof(webDriver));
        }

        /// <summary>
        /// Navigates to the specified URL.
        /// </summary>
        /// <param name="url">The URL to navigate to.</param>
        public void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Checks and retrieves the homepage logo.
        /// </summary>
        /// <exception cref="Exception">Thrown if the logo image is not displayed.</exception>
        public void getLogo()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement LogoImage = wait.Until(d => d.FindElement(By.XPath("//img[@class='block-navbar-left-logo']")));

            if (!LogoImage.Displayed)
            {
                throw new Exception("logo image is not displayed on the homepage.");
            }
        }

        /// <summary>
        /// Retrieves the text of the title element.
        /// </summary>
        /// <returns>The text of the title element.</returns>
        public string getTitle()
        {
            // Create WebDriverWait instance
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // Wait for up to 10 seconds

            // Wait for the element to be visible (we use the standard WebDriverWait here)
            IWebElement headingElement = wait.Until(d => d.FindElement(By.XPath("//span[normalize-space()='Where do youwant to go?']")));

            // Return the text of the element
            return headingElement.Text;
        }

        /// <summary>
        /// Retrieves the text of the subtitle element.
        /// </summary>
        /// <returns>The text of the subtitle element.</returns>
        public string subTitle()
        {
            IWebElement subtitleElement = driver.FindElement(By.XPath("//h2[normalize-space()='Flight deals']"));
            return subtitleElement.Text;
        }

        /// <summary>
        /// Retrieves the text of the suggestion title element.
        /// </summary>
        /// <returns>The text of the suggestion title.</returns>
        public string getSuggestTitle()
        {
            IWebElement suggestTitleElement = driver.FindElement(By.XPath("//h2[normalize-space()='Recommended for you']"));
            return suggestTitleElement.Text;
        }

        /// <summary>
        /// Verifies the presence of the Hawaii image on the homepage.
        /// </summary>
        /// <exception cref="Exception">Thrown if the Hawaii image is not displayed.</exception>
        public void checkHawaiiImage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement HawaiiImage = wait.Until(d => d.FindElement(By.XPath("/html/body/main/main/div/div/div[1]/ul/li[1]/figure/img[1]")));

            if (!HawaiiImage.Displayed)
            {
                throw new Exception("Paris image is not displayed on the homepage.");
            }
        }

        /// <summary>
        /// Retrieves the caption for the Hawaii image.
        /// </summary>
        /// <returns>The caption text for the Hawaii image.</returns>
        /// <exception cref="Exception">Thrown if the Hawaii caption is not displayed.</exception>
        public string checkHawaiiCaption()
        {
            IWebElement hawaiiCaption = driver.FindElement(By.XPath("//figcaption[normalize-space()='Hawaii']"));
            if (hawaiiCaption == null || !hawaiiCaption.Displayed)
            {
                throw new Exception("Hawaii caption is not displayed on the homepage.");
            }
            return hawaiiCaption.Text; // Return the caption text if it's found and displayed.
        }

        /// <summary>
        /// Verifies the presence of the Paris image on the homepage.
        /// </summary>
        /// <exception cref="Exception">Thrown if the Paris image is not displayed.</exception>
        public void checkParisImage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement parisImage = wait.Until(d => d.FindElement(By.XPath("/html/body/main/main/div/div/div[1]/ul/li[2]/figure/img[1]")));

            if (!parisImage.Displayed)
            {
                throw new Exception("Paris image is not displayed on the homepage.");
            }
        }

        /// <summary>
        /// Retrieves the caption for the Paris image.
        /// </summary>
        /// <returns>The caption text for the Paris image.</returns>
        /// <exception cref="Exception">Thrown if the Paris caption is not displayed.</exception>
        public string checkParisCaption()
        {
            IWebElement ParisCaption = driver.FindElement(By.XPath("//figcaption[normalize-space()='Paris']"));
            if (ParisCaption == null || !ParisCaption.Displayed)
            {
                throw new Exception("Paris caption is not displayed on the homepage.");
            }
            return ParisCaption.Text; // Return the caption text if it's found and displayed.
        }

        /// <summary>
        /// Verifies the presence of the Barcelona image on the homepage.
        /// </summary>
        /// <exception cref="Exception">Thrown if the Barcelona image is not displayed.</exception>
        public void checkBarcelonaImage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement BarcelonaImage = wait.Until(d => d.FindElement(By.XPath("/html/body/main/main/div/div/div[1]/ul/li[3]/figure/img[1]")));

            if (!BarcelonaImage.Displayed)
            {
                throw new Exception("Paris image is not displayed on the homepage.");
            }
        }

        /// <summary>
        /// Retrieves the caption for the Barcelona image.
        /// </summary>
        /// <returns>The caption text for the Barcelona image.</returns>
        /// <exception cref="Exception">Thrown if the Barcelona caption is not displayed.</exception>
        public string checkBarcelonaCaption()
        {
            IWebElement BarcelonaCaption = driver.FindElement(By.XPath("//figcaption[normalize-space()='Barcelona']"));
            if (BarcelonaCaption == null || !BarcelonaCaption.Displayed)
            {
                throw new Exception("Barcelona caption is not displayed on the homepage.");
            }
            return BarcelonaCaption.Text; // Return the caption text if it's found and displayed.
        }

        /// <summary>
        /// Logs in with the provided username and password.
        /// </summary>
        /// <param name="username">The username for login.</param>
        /// <param name="password">The password for login.</param>
        /// <exception cref="ArgumentException">Thrown if the username or password is null or empty.</exception>
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