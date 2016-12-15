using System;
using System.Configuration;
using Selenium.core.browsers;

namespace Selenium.config
{
    public class Config
    {
        public static bool RemoteBrowser => bool.Parse(ConfigurationManager.AppSettings["RemoteBrowser"]);

        public static BrowserType Browser
            => (BrowserType) Enum.Parse(typeof(BrowserType), ConfigurationManager.AppSettings["Browser"]);

        public static string Platform => ConfigurationManager.AppSettings["Platform"];
        public static string BaseUrl => ConfigurationManager.AppSettings["BaseUrl"];
        public static string Username => ConfigurationManager.AppSettings["Username"];
        public static string Password => ConfigurationManager.AppSettings["Password"];

        public static bool UseSeleniumGrid => bool.Parse(ConfigurationManager.AppSettings["UseSeleniumGrid"]);
        public static string GridHubUri => ConfigurationManager.AppSettings["GridHubUrl"];

        public static bool UseSauceLabs => bool.Parse(ConfigurationManager.AppSettings["UseSauceLabs"]);
        public static string SauceLabsHubUri => ConfigurationManager.AppSettings["SauceLabsHubUrl"];
        public static string SauceLabsUsername => ConfigurationManager.AppSettings["SauceLabsUsername"];
        public static string SauceLabsAccessKey => ConfigurationManager.AppSettings["SauceLabsAccessKey"];

        public static bool UseBrowserstack => bool.Parse(ConfigurationManager.AppSettings["BrowserStack"]);
        public static string BrowserStackHubUrl => ConfigurationManager.AppSettings["BrowserStackHubUrl"];
        public static string BrowserStackUsername => ConfigurationManager.AppSettings["BrowserStackUsername"];
        public static string BrowserStackAccessKey => ConfigurationManager.AppSettings["BrowserStackAccessKey"];
    }
}