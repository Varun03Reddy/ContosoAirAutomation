/*
 * Copyright (c) 2025 Arpita
 * All rights reserved.
 *
 * This source code is licensed under the terms specified by the owner.
 */
using OpenQA.Selenium;
using InterfaceClass;

namespace WebAdapterClass
{
    /// <summary>
    /// Page object for the "View by" and "Filter results" section.
    /// Implements IBookingFilters interface using Selenium locators.
    /// </summary>
    public class BookingFiltersPage : IBookingFilters
    {
        private readonly IWebDriver driver;

        public BookingFiltersPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region Locators
        private By PriceCheckbox => By.XPath("//label[contains(text(),'Price')]/preceding-sibling::input");
        private By CalendarCheckbox => By.XPath("//label[contains(text(),'Calendar')]/preceding-sibling::input");
        private By ScheduleCheckbox => By.XPath("//label[contains(text(),'Schedule')]/preceding-sibling::input");

        private By NonstopCheckbox => By.XPath("//label[contains(text(),'Nonstop')]/preceding-sibling::input");
        private By OneStopCheckbox => By.XPath("//label[contains(text(),'1 stop')]/preceding-sibling::input");
        private By TwoPlusStopsCheckbox => By.XPath("//label[contains(text(),'2+ stops')]/preceding-sibling::input");
        #endregion

        #region Click Actions
        public void ClickPrice() => driver.FindElement(PriceCheckbox).Click();
        public void ClickCalendar() => driver.FindElement(CalendarCheckbox).Click();
        public void ClickSchedule() => driver.FindElement(ScheduleCheckbox).Click();

        public void ClickNonstop() => driver.FindElement(NonstopCheckbox).Click();
        public void ClickOneStop() => driver.FindElement(OneStopCheckbox).Click();
        public void ClickTwoPlusStops() => driver.FindElement(TwoPlusStopsCheckbox).Click();
        #endregion

        #region State Checkers
        public bool IsPriceSelected() => driver.FindElement(PriceCheckbox).Selected;
        public bool IsCalendarSelected() => driver.FindElement(CalendarCheckbox).Selected;
        public bool IsScheduleSelected() => driver.FindElement(ScheduleCheckbox).Selected;

        public bool IsNonstopSelected() => driver.FindElement(NonstopCheckbox).Selected;
        public bool IsOneStopSelected() => driver.FindElement(OneStopCheckbox).Selected;
        public bool IsTwoPlusStopsSelected() => driver.FindElement(TwoPlusStopsCheckbox).Selected;
        #endregion

        public void Close() => driver.Quit();
    }
}
