using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenerioClass
{
    /// <summary>
    /// Contains test cases for verifying the functionality of the Homepage class.
    /// </summary>
    public class HomepageTests
    {
        private WebAdapterClass.Homepage homepage;
        private IWebDriver driver;

        /// <summary>
        /// Sets up the test environment by initializing the WebDriver and the Homepage instance.
        /// </summary>
        [SetUp] // Marks this method to run before each test
        public void Setup()
        {
            // Initialize WebDriver and Homepage instance
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            homepage = new WebAdapterClass.Homepage(driver);
            homepage.NavigateToUrl("http://localhost:3000/");
        }

        /// <summary>
        /// Verifies that the logo image is displayed on the homepage.
        /// </summary>
        [Test]
        public void getLogo()
        {
            string username = "Vijay";
            string password = "Vijay";

            homepage.PerformLogin(username, password);
            Thread.Sleep(2000);

            Assert.DoesNotThrow(() => homepage.getLogo(), "Logo image is not displayed using Relative XPath.");
        }

        [Test]
        public void getTitle()
        {
            string username = "Vijay";
            string password = "Vijay";

            homepage.PerformLogin(username, password);

            string actual = homepage.getTitle();
            Assert.That(actual, Is.EqualTo("Where do you\r\nwant to go?"));
        }

        [Test]
        public void GetSubtitle()
        {
            string username = "Vijay";
            string password = "Vijay";

            homepage.PerformLogin(username, password);

            string expectedSubtitle = "Flight deals";
            string actualSubtitle = homepage.subTitle();

            Assert.That(actualSubtitle, Is.EqualTo(expectedSubtitle));
        }

        [Test]
        public void GetSuggestedTitle()
        {
            string username = "Vijay";
            string password = "Vijay";

            homepage.PerformLogin(username, password);

            string expectedSuggestedTitle = "Recommended for you";
            string actualSuggestedTitle = homepage.getSuggestTitle();

            Assert.That(actualSuggestedTitle, Is.EqualTo(expectedSuggestedTitle));
        }

        [Test]
        public void checkHawaiiImage()
        {
            string username = "Vijay";
            string password = "Vijay";

            homepage.PerformLogin(username, password);

            Assert.DoesNotThrow(() => homepage.checkHawaiiImage(), "Hawaii image is not displayed using Relative XPath.");
        }

        [Test]
        public void checkHawaiiCaption()
        {
            string username = "Vijay";
            string password = "Vijay";

            homepage.PerformLogin(username, password);

            string expectedName = "Hawaii";
            string actualName = homepage.checkHawaiiCaption();

            Assert.That(actualName, Is.EqualTo(expectedName));
            Assert.DoesNotThrow(() => homepage.checkParisCaption(), "The Hawaii caption is not displayed on the homepage.");
        }

        [Test]
        public void checkParisImageTest()
        {
            string username = "Vijay";
            string password = "Vijay";

            homepage.PerformLogin(username, password);

            Assert.DoesNotThrow(() => homepage.checkParisImage(), "Paris image is not displayed using Relative XPath.");
        }

        [Test]
        public void checkParisCaption()
        {
            string username = "Vijay";
            string password = "Vijay";

            homepage.PerformLogin(username, password);

            string expectedName = "Paris";
            string actualName = homepage.checkParisCaption();

            Assert.That(actualName, Is.EqualTo(expectedName));
            Assert.DoesNotThrow(() => homepage.checkParisCaption(), "The Paris caption is not displayed on the homepage.");
        }

        [Test]
        public void checkBarcelonaImage()
        {
            string username = "Vijay";
            string password = "Vijay";

            homepage.PerformLogin(username, password);

            Assert.DoesNotThrow(() => homepage.checkBarcelonaImage(), "Barcelona image is not displayed using Relative XPath.");
        }

        [Test]
        public void checkBarcelonaCaption()
        {
            string username = "Vijay";
            string password = "Vijay";

            homepage.PerformLogin(username, password);

            string expectedName = "Barcelona";
            string actualName = homepage.checkBarcelonaCaption();

            Assert.That(actualName, Is.EqualTo(expectedName));
            Assert.DoesNotThrow(() => homepage.checkBarcelonaCaption(), "The Barcelona caption is not displayed on the homepage.");
        }

        [Test]
        public void PerformLoginTest()
        {
            string username = "Vijay";
            string password = "Vijay";

            homepage.PerformLogin(username, password);
        }

        /// <summary>
        /// Cleans up the test environment by closing and disposing WebDriver.
        /// </summary>
        [TearDown] // Marks this method to run after each test
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();      // Close browser
                driver.Dispose();   // Dispose properly to avoid warnings
                driver = null;
            }
        }
    }
}
