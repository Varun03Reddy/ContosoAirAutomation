
using InterfaceClass;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebAdapterClass
{
    /// <summary>
    /// This class implements the <see cref="IFlightDeal"/> interface and provides methods for interacting with the flight deal page.
    /// It uses Selenium WebDriver to perform actions such as logging in, retrieving flight details, and interacting with various elements on the page.
    /// </summary>
    public class FlightDeal : IFlightDeal
    {
        private IWebDriver driver;

        /// <summary>
        /// Initializes a new instance of the <see cref="FlightDeal"/> class and sets up a Chrome WebDriver instance.
        /// </summary>
        public FlightDeal()
        {
            // Initialize the WebDriver using ChromeDriver
            driver = new ChromeDriver();
        }

        /// <summary>
        /// Performs the login action on the flight deals page using the provided username and password.
        /// </summary>
        /// <param name="username">The username to use for login.</param>
        /// <param name="password">The password to use for login.</param>
        public void PerformLogin(string username, string password)
        {
            // Navigate to the flight deal website
            driver.Navigate().GoToUrl("http://localhost:3000/");
            driver.Manage().Window.Size = new System.Drawing.Size(1296, 688);  // Set browser window size

            // Locate the login link and click it
            driver.FindElement(By.LinkText("Login")).Click();

            // Locate the username and password fields and enter the provided credentials
            driver.FindElement(By.Id("username")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);

            // Locate and click the login button
            driver.FindElement(By.CssSelector(".btn")).Click();
        }

        /// <summary>
        /// Retrieves the title of the flight deals page after performing login.
        /// </summary>
        /// <returns>The title of the page as a string.</returns>
        public string Title()
        {
            // Find the title element by XPath and return its text
            IWebElement titleElement = driver.FindElement(By.XPath("//h2[normalize-space()='Flight deals']"));
            return titleElement.Text;
        }

        /// <summary>
        /// Retrieves the source and destination values of the specified flight deal box.
        /// </summary>
        /// <param name="boxIndex">The index of the flight deal box to inspect.</param>
        /// <returns>A tuple containing the source and destination values of the deal box.</returns>
        public (string, string) BoxSourceToDestination(int boxIndex)
        {
            // Construct XPath for source and destination based on the box index
            string sourceXPath = $"/html/body/main/main/div/div/div[2]/deals/ul/li[{boxIndex}]/span/span/span[1]/span[1]";
            string destinationXPath = $"/html/body/main/main/div/div/div[2]/deals/ul/li[{boxIndex}]/span/span/span[1]/span[2]";

            // Find the source and destination elements and retrieve their text values
            IWebElement boxSource = driver.FindElement(By.XPath(sourceXPath));
            IWebElement boxDestination = driver.FindElement(By.XPath(destinationXPath));

            // Return the source and destination values as a tuple
            return (boxSource.Text, boxDestination.Text);
        }

        /// <summary>
        /// Retrieves the end date of the specified flight deal box.
        /// </summary>
        /// <param name="boxIndex">The index of the flight deal box to inspect.</param>
        /// <returns>The end date text for the specified box.</returns>
        public string BoxEndDate(int boxIndex)
        {
            // Construct XPath for the end date based on the box index
            string endDateXPath = $"/html/body/main/main/div/div/div[2]/deals/ul/li[{boxIndex}]/span/span/span[1]/span[3]";

            // Find the end date element and retrieve its text value
            IWebElement boxEndDate = driver.FindElement(By.XPath(endDateXPath));
            return boxEndDate.Text;
        }

        /// <summary>
        /// Retrieves the description of the specified flight deal box.
        /// </summary>
        /// <param name="boxIndex">The index of the flight deal box to inspect.</param>
        /// <returns>The description text for the specified box.</returns>
        public string BoxDescription(int boxIndex)
        {
            // Construct XPath for the description based on the box index
            string descriptionXPath = $"/html/body/main/main/div/div/div[2]/deals/ul/li[{boxIndex}]/span/span/span[2]";

            // Find the description element and retrieve its text value
            IWebElement boxDescription = driver.FindElement(By.XPath(descriptionXPath));
            return boxDescription.Text;
        }

        /// <summary>
        /// Closes the WebDriver and shuts down the browser session.
        /// This method is typically called after all tests have been completed to ensure the browser is properly closed.
        /// </summary>
        public void Close()
        {
            // Quit the WebDriver and close the browser
            driver.Quit();
        }
    }
}