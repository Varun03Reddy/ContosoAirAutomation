
/*
 * Copyright (c) 2025 Varun Reddy
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
    /// Defines the contract for a homepage interface that includes navigation, login functionality, 
    /// and retrieval of various elements like titles, subtitles, and images.
    /// </summary>
    public interface IHomepage
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
        /// Checks and retrieves the homepage logo.
        /// </summary>
        void getLogo();

        /// <summary>
        /// Retrieves the text of the title element.
        /// </summary>
        /// <returns>The text of the title element.</returns>
        string getTitle();

        /// <summary>
        /// Retrieves the text of the subtitle element.
        /// </summary>
        /// <returns>The text of the subtitle element.</returns>
        string subTitle();

        /// <summary>
        /// Retrieves the text of the suggestion title element.
        /// </summary>
        /// <returns>The text of the suggestion title.</returns>
        string getSuggestTitle();

        /// <summary>
        /// Verifies the presence of the Hawaii image on the homepage.
        /// </summary>
        void checkHawaiiImage();

        /// <summary>
        /// Retrieves the caption for the Hawaii image.
        /// </summary>
        /// <returns>The caption text for the Hawaii image.</returns>
        string checkHawaiiCaption();

        /// <summary>
        /// Verifies the presence of the Paris image on the homepage.
        /// </summary>
        void checkParisImage();

        /// <summary>
        /// Retrieves the caption for the Paris image.
        /// </summary>
        /// <returns>The caption text for the Paris image.</returns>
        string checkParisCaption();

        /// <summary>
        /// Verifies the presence of the Barcelona image on the homepage.
        /// </summary>
        void checkBarcelonaImage();

        /// <summary>
        /// Retrieves the caption for the Barcelona image.
        /// </summary>
        /// <returns>The caption text for the Barcelona image.</returns>
        string checkBarcelonaCaption();
    }
}
