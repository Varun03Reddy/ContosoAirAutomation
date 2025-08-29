

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceClass
{
    /// <summary>
    /// Defines the contract for login automation functionality.
    /// </summary>
    public interface ILoginTest
    {
        /// <summary>
        /// Navigates to the specified URL.
        /// </summary>
        /// <param name="url">The URL to navigate to.</param>
        void NavigateToUrl(string url);

        /// <summary>
        /// Performs login with the provided username and password.
        /// </summary>
        /// <param name="username">The username for login.</param>
        /// <param name="password">The password for login.</param>
        void PerformLoginWithCredentials(string username, string password);

        /// <summary>
        /// Attempts to perform login without providing any credentials.
        /// </summary>
        void PerformLoginWithOutCredentials();
    }
}