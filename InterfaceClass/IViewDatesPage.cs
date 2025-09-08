/*
 * Copyright (c) 2025 Arpita
 * All rights reserved.
 *
 * This source code is licensed under the terms specified by the owner.
 */
using System;
using OpenQA.Selenium;

namespace InterfaceClass
{
    /// <summary>
    /// Represents the page after a user logs in.
    /// Defines methods for interacting with the View Dates buttons on the page.
    /// </summary>
    public interface IViewDatesPage
    {
        /// <summary>
        /// Clicks the "View Dates" button for a specific flight deal.
        /// </summary>
        /// <param name="dealIndex">The index of the flight deal (1-based).</param>
        void ClickViewDates(int dealIndex);

        /// <summary>
        /// Retrieves the title of the page that is loaded after clicking "View Dates".
        /// </summary>
        /// <returns>A string representing the new page's title.</returns>
        string GetPageTitle();

        /// <summary>
        /// Closes the WebDriver and shuts down the browser session.
        /// </summary>
        void Close();
    }
}