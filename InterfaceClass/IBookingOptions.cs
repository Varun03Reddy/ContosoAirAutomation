/*
 * Copyright (c) 2025 keyur
 * All rights reserved.
 *
 * This source code is licensed under the terms specified by the owner.
 */
using System;

namespace InterfaceClass
{
    /// <summary>
    /// Defines methods for interacting with the flight booking trip options.
    /// </summary>
    public interface IBookingOptions
    {
        void Login(string username, string password);
        /// <summary>
        /// Navigates to the booking page.
        /// </summary>
        void NavigateToBookingPage();

        /// <summary>
        /// Clicks the "One way" booking option.
        /// </summary>
        void ClickOneWay();

        /// <summary>
        /// Clicks the "Multi-city" booking option.
        /// </summary>
        void ClickMultiCity();

        /// <summary>
        /// Checks if the "Return Date" field is visible on the page.
        /// </summary>
        /// <returns>True if the return date field is visible, otherwise false.</returns>
        bool IsReturnDateVisible();

        /// <summary>
        /// Cleans up resources and closes the browser session.
        /// </summary>
        void Close();
    }
}
