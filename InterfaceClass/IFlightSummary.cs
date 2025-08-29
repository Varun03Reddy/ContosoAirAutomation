using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceClass
{
    /// <summary>
    /// Defines the contract for interacting with a flight summary page or functionality.
    /// </summary>
    public interface IFlightSummary
    {
        /// <summary>
        /// Navigates to the specified URL.
        /// </summary>
        /// <param name="url">The URL to navigate to.</param>
        void NavigateToUrl(string url);

        /// <summary>
        /// Logs in with the provided username and password.
        /// </summary>
        /// <param name="username">The username for login.</param>
        /// <param name="password">The password for login.</param>
        void PerformLogin(string username, string password);

        /// <summary>
        /// Books a flight with the specified details. Implementation should include selecting flight options, providing passenger details, and confirming the booking.
        /// </summary>
        void BookFlight();

        /// <summary>
        /// Validates or retrieves the passenger name associated with the flight booking.
        /// </summary>
        void checkPassengerName();

        /// <summary>
        /// Checks the functionality to cancel a flight booking. Implementation should validate that cancellation is processed correctly.
        /// </summary>
        void checkCancelBooking();
    }
}