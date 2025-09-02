using InterfaceClass;
using OpenQA.Selenium;
using Utilities;   // <-- For WaitHelper

namespace WebAdapterClass
{
    /// <summary>
    /// Implements footer validations for ContosoAir
    /// </summary>
    public class FooterPage : IFooterPage
    {
        private readonly IWebDriver _driver;

        // Locators for footer sections
        private readonly By aboutContoso = By.XPath("//h5[contains(text(),'ABOUT CONTOSO')]");
        private readonly By customerService = By.XPath("//h5[contains(text(),'CUSTOMER SERVICE')]");
        private readonly By contact = By.XPath("//h5[contains(text(),'CONTACT')]");
        private readonly By socialMedia = By.XPath("//h5[contains(text(),'SOCIAL MEDIA')]");

        public FooterPage(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Helper to check if section is displayed
        /// </summary>
        private bool IsSectionDisplayed(By locator)
        {
            try
            {
                var element = WaitHelper.WaitForElementVisible(_driver, locator, 10);
                return element.Displayed;
            }
            catch
            {
                return false;
            }
        }

        public bool IsAboutContosoDisplayed() => IsSectionDisplayed(aboutContoso);
        public bool IsCustomerServiceDisplayed() => IsSectionDisplayed(customerService);
        public bool IsContactDisplayed() => IsSectionDisplayed(contact);
        public bool IsSocialMediaDisplayed() => IsSectionDisplayed(socialMedia);
    }
}