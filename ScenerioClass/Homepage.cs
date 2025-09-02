using Utilities;   // 🔹 Added Utilities reference
using NUnit.Framework;
using OpenQA.Selenium;
using WebAdapterClass;

namespace ScenerioClass
{
    [TestFixture]
    public class HomepageTests
    {
        private Homepage homepage;
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            // 🔹 Use DriverFactory instead of hardcoding ChromeDriver
            driver = DriverFactory.CreateDriver("chrome");
            homepage = new Homepage(driver);
            homepage.NavigateToUrl("http://localhost:3000/");
        }

        [Test]
        public void getLogo()
        {
            homepage.PerformLogin("Vijay", "Vijay");
            Assert.DoesNotThrow(() => homepage.getLogo(), "Logo image is not displayed using Relative XPath.");
        }

        [Test]
        public void getTitle()
        {
            homepage.PerformLogin("Vijay", "Vijay");
            string actual = homepage.getTitle();
            Assert.That(actual, Is.EqualTo("Where do you\r\nwant to go?"));
        }

        [Test]
        public void GetSubtitle()
        {
            homepage.PerformLogin("Vijay", "Vijay");
            string actualSubtitle = homepage.subTitle();
            Assert.That(actualSubtitle, Is.EqualTo("Flight deals"));
        }

        [Test]
        public void GetSuggestedTitle()
        {
            homepage.PerformLogin("Vijay", "Vijay");
            string actualSuggestedTitle = homepage.getSuggestTitle();
            Assert.That(actualSuggestedTitle, Is.EqualTo("Recommended for you"));
        }

        [Test]
        public void checkHawaiiImage()
        {
            homepage.PerformLogin("Vijay", "Vijay");
            Assert.DoesNotThrow(() => homepage.checkHawaiiImage(), "Hawaii image is not displayed using Relative XPath.");
        }

        [Test]
        public void checkHawaiiCaption()
        {
            homepage.PerformLogin("Vijay", "Vijay");
            string actualName = homepage.checkHawaiiCaption();
            Assert.That(actualName, Is.EqualTo("Hawaii"));
        }

        [Test]
        public void checkParisImageTest()
        {
            homepage.PerformLogin("Vijay", "Vijay");
            Assert.DoesNotThrow(() => homepage.checkParisImage(), "Paris image is not displayed using Relative XPath.");
        }

        [Test]
        public void checkParisCaption()
        {
            homepage.PerformLogin("Vijay", "Vijay");
            string actualName = homepage.checkParisCaption();
            Assert.That(actualName, Is.EqualTo("Paris"));
        }

        [Test]
        public void checkBarcelonaImage()
        {
            homepage.PerformLogin("Vijay", "Vijay");
            Assert.DoesNotThrow(() => homepage.checkBarcelonaImage(), "Barcelona image is not displayed using Relative XPath.");
        }

        [Test]
        public void checkBarcelonaCaption()
        {
            homepage.PerformLogin("Vijay", "Vijay");
            string actualName = homepage.checkBarcelonaCaption();
            Assert.That(actualName, Is.EqualTo("Barcelona"));
        }

        [Test]
        public void PerformLoginTest()
        {
            Assert.DoesNotThrow(() => homepage.PerformLogin("Vijay", "Vijay"));
        }

        [TearDown]
        public void TearDown()
        {
            driver?.Quit();
            driver?.Dispose();
            driver = null;
        }
    }
}