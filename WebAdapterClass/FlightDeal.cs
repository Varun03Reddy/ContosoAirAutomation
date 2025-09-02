using InterfaceClass;
using OpenQA.Selenium;
using Utilities; // ✅ Added utilities

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
            // Initialize the WebDriver using DriverFactory
            driver = DriverFactory.CreateDriver("chrome");
        }

        public void PerformLogin(string username, string password)
        {
            driver.Navigate().GoToUrl(ConfigManager.GetAppUrl()); // ✅ use ConfigManager
            driver.Manage().Window.Size = new System.Drawing.Size(1296, 688);

            SeleniumHelpers.ClickElement(driver, By.LinkText("Login")); // ✅ use SeleniumHelpers
            SeleniumHelpers.EnterText(driver, By.Id("username"), username);
            SeleniumHelpers.EnterText(driver, By.Id("password"), password);
            SeleniumHelpers.ClickElement(driver, By.CssSelector(".btn"));
        }

        public string Title()
        {
            var titleElement = WaitHelper.WaitForElement(driver, By.XPath("//h2[normalize-space()='Flight deals']"));
            return titleElement.Text;
        }

        public (string, string) BoxSourceToDestination(int boxIndex)
        {
            string sourceXPath = $"/html/body/main/main/div/div/div[2]/deals/ul/li[{boxIndex}]/span/span/span[1]/span[1]";
            string destinationXPath = $"/html/body/main/main/div/div/div[2]/deals/ul/li[{boxIndex}]/span/span/span[1]/span[2]";

            var boxSource = WaitHelper.WaitForElement(driver, By.XPath(sourceXPath));
            var boxDestination = WaitHelper.WaitForElement(driver, By.XPath(destinationXPath));

            return (boxSource.Text, boxDestination.Text);
        }

        public string BoxEndDate(int boxIndex)
        {
            string endDateXPath = $"/html/body/main/main/div/div/div[2]/deals/ul/li[{boxIndex}]/span/span/span[1]/span[3]";
            var boxEndDate = WaitHelper.WaitForElement(driver, By.XPath(endDateXPath));
            return boxEndDate.Text;
        }

        public string BoxDescription(int boxIndex)
        {
            string descriptionXPath = $"/html/body/main/main/div/div/div[2]/deals/ul/li[{boxIndex}]/span/span/span[2]";
            var boxDescription = WaitHelper.WaitForElement(driver, By.XPath(descriptionXPath));
            return boxDescription.Text;
        }

        public void Close()
        {
            driver.Quit();
        }
    }
}