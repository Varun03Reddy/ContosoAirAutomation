using InterfaceClass;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities; // ✅ Added utilities

namespace WebAdapterClass
{
    /// <summary>
    /// Class for performing flight listing functionalities, including login and searching for available flights.
    /// </summary>
    public class FlightListingPage : IFlightListing
    {
        private IWebDriver driver;

        public FlightListingPage()
        {
            driver = DriverFactory.CreateDriver("chrome"); // ✅ Use DriverFactory
        }

        public void Login(string username, string password)
        {
            driver.Navigate().GoToUrl(ConfigManager.GetAppUrl()); // ✅ Use ConfigManager
            driver.Manage().Window.Size = new System.Drawing.Size(1296, 688);

            SeleniumHelpers.ClickElement(driver, By.LinkText("Login")); // ✅ Use SeleniumHelpers
            SeleniumHelpers.EnterText(driver, By.Id("username"), username);
            SeleniumHelpers.EnterText(driver, By.Id("password"), password);
            SeleniumHelpers.ClickElement(driver, By.CssSelector(".btn"));
        }

        public void SearchFlights(string from, string to, DateTime departureDate, int passengers, DateTime returnDate)
        {
            SeleniumHelpers.ClickElement(driver, By.LinkText("Book"));

            SeleniumHelpers.SelectDropdownByText(driver, By.Id("fromCode"), from);
            SeleniumHelpers.SelectDropdownByText(driver, By.Id("toCode"), to);

            // Departure date
            SeleniumHelpers.ClickElement(driver, By.Id("dpa"));
            var departureDateCell = WaitHelper.WaitForElement(driver, By.XPath($"//td[contains(text(), '{departureDate.Day}')]"));
            departureDateCell.Click();

            // Passengers
            SeleniumHelpers.SelectDropdownByText(driver, By.Id("passengers"), passengers.ToString());

            // Return date
            SeleniumHelpers.ClickElement(driver, By.Id("dpb"));
            var returnDateCell = WaitHelper.WaitForElement(driver, By.XPath($"//td[contains(text(), '{returnDate.Day}')]"));
            returnDateCell.Click();

            // Click Find Flights
            SeleniumHelpers.ClickElement(driver, By.XPath("/html/body/main/section/div/div/div[3]/div/form/fieldset/button"));
        }

        public List<IWebElement> ListAvailableFlights()
        {
            var flightListings = driver.FindElements(By.CssSelector(".block-flights-results-list-item")).ToList();
            if (flightListings.Count == 0)
                Console.WriteLine("No flights available.");
            return flightListings;
        }

        public void Close()
        {
            driver.Quit();
        }
    }
}