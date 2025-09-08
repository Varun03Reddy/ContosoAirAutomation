/*
 * Copyright (c) 2025 Vamsi Krishna
 * All rights reserved.
 *
 * This source code is licensed under the terms specified by the owner.
 */
using System.Collections.Generic;

namespace InterfaceClass
{
    /// <summary>
    /// Interface for the "Available flights" departing-flight selector.
    /// </summary>
    public interface IAvailableFlights
    {
        /// <summary>
        /// Clicks a departing-flight date card by its visible text
        /// (e.g., "Tuesday Sep 23").
        /// </summary>
        void SelectDepartingFlightByDate(string dateText);

        /// <summary>
        /// Returns all visible departing-flight prices (e.g., "$614").
        /// </summary>
        List<string> GetAllDepartingFlightPrices();
    }
}
