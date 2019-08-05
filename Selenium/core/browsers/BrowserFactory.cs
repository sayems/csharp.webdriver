using System;
using System.IO;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace Selenium.core.browsers
{
    public sealed class BrowserFactory :
        AbstractFactory,
        IBrowserWebDriver<FirefoxDriver>,
        IBrowserWebDriver<ChromeDriver>,
        IBrowserWebDriver<RemoteWebDriver>
    {
        IBrowser<ChromeDriver> IBrowserWebDriver<ChromeDriver>.Create()
        {
            var dirName = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin", StringComparison.Ordinal));
            var fileInfo = new FileInfo(dirName);
            var parentDirName = fileInfo?.FullName;
            return new BrowserAdapter<ChromeDriver>(new ChromeDriver(parentDirName + @"libs"), BrowserType.Chrome);
        }

        IBrowser<FirefoxDriver> IBrowserWebDriver<FirefoxDriver>.Create()
        {
            var dirName = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin", StringComparison.Ordinal));
            var fileInfo = new FileInfo(dirName);
            var parentDirName = fileInfo?.FullName;
            var service = FirefoxDriverService.CreateDefaultService(parentDirName + @"\libs");
            service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
            return new BrowserAdapter<FirefoxDriver>(new FirefoxDriver(service), BrowserType.Firefox);
        }

        // TODO - Fix Remote WebDriver
        IBrowser<RemoteWebDriver> IBrowserWebDriver<RemoteWebDriver>.Create()
        {
            DesiredCapabilities capabilities;
            var gridUrl = Config.GridHubUri;

            switch (Config.Browser)
            {
                case BrowserType.Chrome:
                    capabilities = new DesiredCapabilities();
                    break;
                case BrowserType.Firefox:
                    capabilities = new DesiredCapabilities();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (Config.RemoteBrowser && Config.UseSauceLabs)
            {
                capabilities.SetCapability(CapabilityType.Version, "50");
                capabilities.SetCapability(CapabilityType.Platform, "Windows 10");
                capabilities.SetCapability("username", Config.SauceLabsUsername);
                capabilities.SetCapability("accessKey", Config.SauceLabsAccessKey);
                gridUrl = Config.SauceLabsHubUri;
            }
            else if (Config.RemoteBrowser && Config.UseBrowserstack)
            {
                capabilities.SetCapability(CapabilityType.Version, "50");
                capabilities.SetCapability(CapabilityType.Platform, "Windows 10");
                capabilities.SetCapability("username", Config.BrowserStackUsername);
                capabilities.SetCapability("accessKey", Config.BrowserStackAccessKey);
                gridUrl = Config.BrowserStackHubUrl;
            }

            return
                new BrowserAdapter<RemoteWebDriver>(
                    new RemoteWebDriver(new Uri(gridUrl), capabilities), BrowserType.Remote);
        }
    }
}