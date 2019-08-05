using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Selenium.core.browsers
{
    public class Config
    {
        public static bool RemoteBrowser => bool.Parse(GetValue("RemoteBrowser"));

        public static BrowserType Browser
            => (BrowserType) Enum.Parse(typeof(BrowserType), GetValue("Browser"));

        public static string Platform => GetValue("Platform");
        public static string BaseUrl => GetValue("BaseUrl");
        public static string Username => GetValue("Username");
        public static string Password => GetValue("Password");

        public static bool UseSeleniumGrid => bool.Parse(GetValue("UseSeleniumGrid"));
        public static string GridHubUri => GetValue("GridHubUrl");

        public static bool UseSauceLabs => bool.Parse(GetValue("UseSauceLabs"));
        public static string SauceLabsHubUri => GetValue("SauceLabsHubUrl");
        public static string SauceLabsUsername => GetValue("SauceLabsUsername");
        public static string SauceLabsAccessKey => GetValue("SauceLabsAccessKey");

        public static bool UseBrowserstack => bool.Parse(GetValue("BrowserStack"));
        public static string BrowserStackHubUrl => GetValue("BrowserStackHubUrl");
        public static string BrowserStackUsername => GetValue("BrowserStackUsername");
        public static string BrowserStackAccessKey => GetValue("BrowserStackAccessKey");

        private static string GetValue(string value)
        {
            var dirName = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
            var fileInfo = new FileInfo(dirName);
            var parentDirName = fileInfo?.FullName;

            var builder = new ConfigurationBuilder()
                .SetBasePath(parentDirName)
                .AddJsonFile("appsettings.json");
            return builder.Build()[value];
        }
    }
}