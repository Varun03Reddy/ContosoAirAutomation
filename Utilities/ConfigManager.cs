using System.Configuration;

namespace Utilities
{
    /// <summary>
    /// Manages configuration values from App.config or default values.
    /// </summary>
    public static class ConfigManager
    {
        public static string BaseUrl => GetConfig("BaseUrl", "http://localhost:3000");
        public static string Browser => GetConfig("Browser", "chrome");
        public static string Username => GetConfig("Username", "testuser");
        public static string Password => GetConfig("Password", "password123");

        private static string GetConfig(string key, string defaultValue)
        {
            string value = ConfigurationManager.AppSettings[key];
            return string.IsNullOrEmpty(value) ? defaultValue : value;
        }

        // ✅ Universal config fetcher
        public static string GetConfigValue(string key, string defaultValue = "")
        {
            string value = ConfigurationManager.AppSettings[key];
            return string.IsNullOrEmpty(value) ? defaultValue : value;
        }

        // ✅ Only ONE method for AppUrl
        public static string GetAppUrl()
        {
            string url = ConfigurationManager.AppSettings["AppUrl"];
            if (string.IsNullOrEmpty(url))
                url = "http://localhost:3000/";   // fallback
            return url;
        }
    }
}