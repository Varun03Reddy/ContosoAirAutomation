using OpenQA.Selenium;

namespace InterfaceClass
{
    /// <summary>
    /// Defines contract for Footer Page operations
    /// </summary>
    public interface IFooterPage
    {
        bool IsAboutContosoDisplayed();
        bool IsCustomerServiceDisplayed();
        bool IsContactDisplayed();
        bool IsSocialMediaDisplayed();
    }
}