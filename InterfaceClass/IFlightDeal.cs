/*
 * Copyright (c) 2025 Vamsi Krishna
 * All rights reserved.
 *
 * This source code is licensed under the terms specified by the owner.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceClass
{
    /// <summary>
    /// Represents an interface for a flight deal system.
    /// Defines methods for performing login, retrieving flight details, and interacting with the UI elements.
    /// </summary>
    public interface IFlightDeal
    {
        /// <summary>
        /// Performs login action with the provided username and password.
        /// </summary>
        /// <param name="username">The username of the user attempting to log in.</param>
        /// <param name="password">The password associated with the username.</param>
        void PerformLogin(string username, string password);

        /// <summary>
        /// Retrieves the title of the flight deal.
        /// </summary>
        /// <returns>A string representing the title of the flight deal.</returns>
        string Title();

        /// <summary>
        /// Retrieves the source and destination airports for a particular flight deal, based on the provided index.
        /// </summary>
        /// <param name="i">The index of the flight deal.</param>
        /// <returns>A tuple containing the source and destination airports for the flight deal.</returns>
        (string, string) BoxSourceToDestination(int i);

        /// <summary>
        /// Retrieves the end date of the flight deal, based on the provided index.
        /// </summary>
        /// <param name="i">The index of the flight deal.</param>
        /// <returns>A string representing the end date of the flight deal.</returns>
        string BoxEndDate(int i);

        /// <summary>
        /// Retrieves the description of the flight deal, based on the provided index.
        /// </summary>
        /// <param name="i">The index of the flight deal.</param>
        /// <returns>A string representing the description of the flight deal.</returns>
        string BoxDescription(int i);
        /// <summary>
        /// Closes the WebDriver and shuts down the browser session.
        /// </summary>
        void Close();

    }
}