/*
 * Copyright (c) 2025 Vamsi Krishna
 * All rights reserved.
 *
 * This source code is licensed under the terms specified by the owner.
 */
using InterfaceClass;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using Utilities;

namespace WebAdapterClass
{
    /// <summary>
    /// Page object for the "Available flights" date/price carousel.
    /// SRP (Single Responsibility Principle):
    /// This class only handles interactions with the Available Flights page (date selection and price fetching).
    /// </summary>
    public class AvailableFlightsPage : IAvailableFlights
    {
        private readonly IWebDriver driver;

        public AvailableFlightsPage(IWebDriver driver)
        {
            // DIP (Dependency Inversion Principle):
            // The class depends on the IWebDriver abstraction, not a concrete driver (like ChromeDriver).
            this.driver = driver;
        }

        /// <summary>
        /// Clicks a departing date button by its visible text.
        /// SRP: Method only responsible for selecting a flight date.
        /// OCP (Open/Closed Principle): New locators or date formats can be supported 
        /// by extending logic, without modifying core structure.
        /// </summary>
        public void SelectDepartingFlightByDate(string dateText)
        {
            var locator = By.XPath(
                "//div[contains(@class,'available') and contains(@class,'flights')]" +
                $"//div[contains(normalize-space(text()),'{dateText}')]"
            );

            // LSP (Liskov Substitution Principle):
            // Any driver (ChromeDriver, EdgeDriver, etc.) implementing IWebDriver can be substituted here
            // without breaking functionality.

            // ISP (Interface Segregation Principle):
            // Relies on SeleniumHelpers which exposes small, focused methods like ClickElement,
            // instead of one bloated interface.

            // Uses helper for action encapsulation (ClickElement), adhering to DRY and SRP.
            SeleniumHelpers.ClickElement(driver, locator);
        }

        /// <summary>
        /// Collects all visible prices from the date cards.
        /// SRP: Method focuses only on retrieving flight prices.
        /// OCP: If additional currencies/formats are introduced, 
        /// logic can be extended without changing method signature.
        /// </summary>
        public List<string> GetAllDepartingFlightPrices()
        {
            var locator = By.XPath(
                "//div[contains(@class,'available') and contains(@class,'flights')]" +
                "//div[contains(text(),'$')]"
            );
            var elements = driver.FindElements(locator);

            // LINQ usage makes code concise and follows SRP — 
            // transformation (IWebElement → string) is separate from collection.

            return elements.Select(e => e.Text.Trim()).ToList();
        }
    }
}
