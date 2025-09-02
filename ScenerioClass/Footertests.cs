
using NUnit.Framework;
using OpenQA.Selenium;
using Utilities;
using WebAdapterClass;

namespace ScenarioClass
{
    [TestFixture]
    public class FooterTests
    {
        private IWebDriver driver;
        private FooterPage footer;

        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.CreateDriver("chrome");
            driver.Navigate().GoToUrl("http://localhost:3000");
            driver.Manage().Window.Maximize();
            footer = new FooterPage(driver);
        }

        [Test]
        public void VerifyFooterSections()
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(footer.IsAboutContosoDisplayed(), "About Contoso section not found.");
                Assert.IsTrue(footer.IsCustomerServiceDisplayed(), "Customer Service section not found.");
                Assert.IsTrue(footer.IsContactDisplayed(), "Contact section not found.");
                Assert.IsTrue(footer.IsSocialMediaDisplayed(), "Social Media section not found.");
            });
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