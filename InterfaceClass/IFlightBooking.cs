

using System;

namespace InterfaceClass
{
    /// <summary>
    /// Interface for implementing flight booking functionality.
    /// Provides methods for login, selecting flight details, booking flights, and closing the session.
    /// </summary>
    public interface IFlightBooking
    {
        /// <summary>
        /// Logs in to the flight booking system with the given username and password.
        /// </summary>
        /// <param name="username">The username for authentication.</param>
        /// <param name="password">The password for authentication.</param>
        void Login(string username, string password);

        /// <summary>
        /// Selects flight details including departure and arrival locations, 
        /// dates for departure and return, and the number of passengers.
        /// </summary>
        /// <param name="from">The departure location code (e.g., "JFK").</param>
        /// <param name="to">The arrival location code (e.g., "LAX").</param>
        /// <param name="departureDate">The date of departure.</param>
        /// <param name="passengers">The number of passengers traveling.</param>
        /// <param name="returnDate">The date of return.</param>
        void SelectFlightDetails(string from, string to, DateTime departureDate, int passengers, DateTime returnDate);

        /// <summary>
        /// Books the selected flight based on previously provided details.
        /// </summary>
        void BookFlight();

        /// <summary>
        /// Closes the flight booking session and releases browser resources.
        /// </summary>
        void Close();
    }
}