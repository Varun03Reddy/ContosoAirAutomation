/*
 * Copyright (c) 2025 Vamsi Krishna
 * All rights reserved.
 *
 * This source code is licensed under the terms specified by the owner.
 */
using InterfaceClass; // ISP: IFlightDeal contains only flight deal-related methods
using OpenQA.Selenium; // Selenium WebDriver for browser automation
using Utilities; // Helpers like SeleniumHelpers, WaitHelper, and DriverFactory

namespace WebAdapterClass
{
    /// <summary>
    /// This class implements the <see cref="IFlightDeal"/> interface and provides methods 
    /// for interacting with the flight deal page.
    /// It uses Selenium WebDriver to perform actions such as logging in, retrieving flight details, 
    /// and interacting with various elements on the page.
    /// </summary>
    public class FlightDeal : IFlightDeal // DIP: Depends on interface, not the consumer code
    {
        private IWebDriver driver; // LSP: Any IWebDriver implementation can be used

        /// <summary>
        /// Initializes a new instance of the <see cref="FlightDeal"/> class and sets up a Chrome WebDriver instance.
        /// </summary>
        public FlightDeal()
        {
            // Factory pattern: Centralized driver creation
            driver = DriverFactory.CreateDriver("chrome");
        }

        /// <summary>
        /// Performs login action with the provided username and password.
        /// </summary>
        /// <param name="username">Username for login</param>
        /// <param name="password">Password for login</param>
        public void PerformLogin(string username, string password)
        {
            driver.Navigate().GoToUrl(ConfigManager.GetAppUrl()); // Navigate to application URL
            driver.Manage().Window.Size = new System.Drawing.Size(1296, 688); // Set consistent window size

            // Encapsulate Selenium actions using helpers
            SeleniumHelpers.ClickElement(driver, By.LinkText("Login"));
            SeleniumHelpers.EnterText(driver, By.Id("username"), username);
            SeleniumHelpers.EnterText(driver, By.Id("password"), password);
            SeleniumHelpers.ClickElement(driver, By.CssSelector(".btn")); // Submit login
        }

        /// <summary>
        /// Retrieves the title of the flight deals page.
        /// </summary>
        /// <returns>Text of the page title</returns>
        public string Title()
        {
            var titleElement = WaitHelper.WaitForElement(driver, By.XPath("//h2[normalize-space()='Flight deals']")); // Wait for element
            return titleElement.Text;
        }

        /// <summary>
        /// Retrieves the source and destination text for a specific flight deal box.
        /// </summary>
        /// <param name="boxIndex">Index of the flight deal box</param>
        /// <returns>Tuple containing source and destination strings</returns>
        public (string, string) BoxSourceToDestination(int boxIndex)
        {
            // Construct dynamic XPath for source and destination
            string sourceXPath = $"/html/body/main/main/div/div/div[2]/deals/ul/li[{boxIndex}]/span/span/span[1]/span[1]";
            string destinationXPath = $"/html/body/main/main/div/div/div[2]/deals/ul/li[{boxIndex}]/span/span/span[1]/span[2]";

            var boxSource = WaitHelper.WaitForElement(driver, By.XPath(sourceXPath));
            var boxDestination = WaitHelper.WaitForElement(driver, By.XPath(destinationXPath));

            return (boxSource.Text, boxDestination.Text); // Return tuple
        }

        /// <summary>
        /// Retrieves the end/purchase date text for a specific flight deal box.
        /// </summary>
        /// <param name="boxIndex">Index of the flight deal box</param>
        /// <returns>Text of the end date</returns>
        public string BoxEndDate(int boxIndex)
        {
            string endDateXPath = $"/html/body/main/main/div/div/div[2]/deals/ul/li[{boxIndex}]/span/span/span[1]/span[3]";
            var boxEndDate = WaitHelper.WaitForElement(driver, By.XPath(endDateXPath));
            return boxEndDate.Text;
        }

        /// <summary>
        /// Retrieves the description text (including price) for a specific flight deal box.
        /// </summary>
        /// <param name="boxIndex">Index of the flight deal box</param>
        /// <returns>Description text of the flight deal</returns>
        public string BoxDescription(int boxIndex)
        {
            string descriptionXPath = $"/html/body/main/main/div/div/div[2]/deals/ul/li[{boxIndex}]/span/span/span[2]";
            var boxDescription = WaitHelper.WaitForElement(driver, By.XPath(descriptionXPath));
            return boxDescription.Text;
        }

        /// <summary>
        /// Closes the browser session.
        /// </summary>
        public void Close()
        {
            driver.Quit(); // SRP: Responsible for cleanup of the WebDriver session
        }
    }
}
