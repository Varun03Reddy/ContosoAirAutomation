using InterfaceClass;
using OpenQA.Selenium;
using Utilities;   // 🔹 Added Utilities reference
using System;

namespace WebAdapterClass
{
    /// <summary>
    /// Provides the implementation of the IHomepage interface for interacting with the homepage using Selenium WebDriver.
    /// </summary>
    public class Homepage : IHomepage
    {
        private readonly IWebDriver driver;
        private readonly WaitHelper waitHelper;   // 🔹 Use WaitHelper

        public Homepage(IWebDriver webDriver)
        {
            driver = webDriver ?? throw new ArgumentNullException(nameof(webDriver));
            waitHelper = new WaitHelper(driver, 10); // 🔹 init WaitHelper with 10 sec timeout
        }

        public void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void getLogo()
        {
            IWebElement logoImage = waitHelper.WaitForElementVisible(By.XPath("//img[@class='block-navbar-left-logo']"));
            if (!logoImage.Displayed)
            {
                throw new Exception("Logo image is not displayed on the homepage.");
            }
        }

        public string getTitle()
        {
            IWebElement headingElement = waitHelper.WaitForElementVisible(
                By.XPath("//span[normalize-space()='Where do youwant to go?']")
            );
            return headingElement.Text;
        }

        public string subTitle()
        {
            IWebElement subtitleElement = waitHelper.WaitForElementVisible(
                By.XPath("//h2[normalize-space()='Flight deals']")
            );
            return subtitleElement.Text;
        }

        public string getSuggestTitle()
        {
            IWebElement suggestTitleElement = waitHelper.WaitForElementVisible(
                By.XPath("//h2[normalize-space()='Recommended for you']")
            );
            return suggestTitleElement.Text;
        }

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