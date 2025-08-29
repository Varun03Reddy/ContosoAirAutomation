

using InterfaceClass;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAdapterClass;

namespace ScenerioClass
{
    // Scenario class for executing the login test
    [TestFixture]
    public class LoginScenario
    {
        private IWebDriver driver;
        private ILoginTest loginTest;

        /// <summary>
        /// Initializes the WebDriver and login test setup before each test.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            // Initialize the WebDriver (e.g., ChromeDriver or any other driver)
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            // Initialize the login test interface with the driver.
            loginTest = new LoginTest(driver);
        }

        /// <summary>
        /// Test to perform login with valid credentials.
        /// </summary>
        [Test]
        public void PerformLoginWithCredentials()
        {
            // Define test URL, username, and password
            string url = "http://localhost:3000/";
            string username = "Vijay";
            string password = "Vijay";

            // Perform login steps
            loginTest.NavigateToUrl(url);
            loginTest.PerformLoginWithCredentials(username, password);
            // Pause execution to observe results (optional).
            Thread.Sleep(2000);
        }

        /// <summary>
        /// Test to perform login without providing any credentials.
        /// </summary>
        [Test]
        public void PerformLoginWithOutCredentials()
        {
            // Define the test URL.
            string url = "http://localhost:3000/";

            // Step 1: Navigate to URL
            loginTest.NavigateToUrl(url);

            // Step 2: Perform login without credentials
            loginTest.PerformLoginWithOutCredentials();

            Thread.Sleep(2000); // Allow time for UI validation (optional)
        }

        /// <summary>
        /// Cleans up the WebDriver after each test execution.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            // Close the browser and dispose of the WebDriver instance.
            driver.Dispose();
        }
    }
}