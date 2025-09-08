using System.Configuration;

namespace Utilities
{
    /// <summary>
    /// Manages configuration values from App.config or provides default values.
    /// ✅ Centralizes all application configuration settings.
    /// ✅ Follows Single Responsibility Principle (SRP) – only handles config retrieval.
    /// </summary>
    public static class ConfigManager
    {
        /// <summary>
        /// Base URL of the application.
        /// ✅ Uses App.config value if present, otherwise defaults to a specified URL.
        /// </summary>
        public static string BaseUrl => GetConfig("BaseUrl", "http://contosoairline.southindia.cloudapp.azure.com:3000/");

        /// <summary>
        /// Default browser to use for automation (e.g., Chrome, Firefox).
        /// </summary>
        public static string Browser => GetConfig("Browser", "chrome");

        /// <summary>
        /// Default username for login.
        /// </summary>
        public static string Username => GetConfig("Username", "Varun Reddy");

        /// <summary>
        /// Default password for login.
        /// </summary>
        public static string Password => GetConfig("Password@145", "vgg@544");

        /// <summary>
        /// Fetches a configuration value by key with a fallback default.
        /// ✅ Ensures code does not break if key is missing.
        /// </summary>
        private static string GetConfig(string key, string defaultValue)
        {
            string value = ConfigurationManager.AppSettings[key];
            return string.IsNullOrEmpty(value) ? defaultValue : value;
        }

        /// <summary>
        /// Universal method to fetch any config value with optional default.
        /// ✅ Promotes reuse and avoids repetitive GetConfig calls in code.
        /// </summary>
        /// <param name="key">AppSettings key</param>
        /// <param name="defaultValue">Fallback value if key is missing</param>
        /// <returns>Config value or default</returns>
        public static string GetConfigValue(string key, string defaultValue = "")
        {
            string value = ConfigurationManager.AppSettings[key];
            return string.IsNullOrEmpty(value) ? defaultValue : value;
        }

        /// <summary>
        /// Retrieves the application URL.
        /// ✅ Single method for AppUrl ensures consistency across tests.
        /// ✅ Supports default fallback URL.
        /// </summary>
        /// <returns>Application URL</returns>
        public static string GetAppUrl()
        {
            string url = ConfigurationManager.AppSettings["AppUrl"];
            if (string.IsNullOrEmpty(url))
                url = "http://contosoairline.southindia.cloudapp.azure.com:3000/";   // fallback
            return url;
        }
    }
}
