using OpenQA.Selenium;

namespace Selenium.core.browsers
{
    public interface IBrowser
    {
        IPage Page { get; }
        IJavaScript JavaScript { get; }
    }

    public interface IBrowser<out T> : IBrowser where T : IWebDriver
    {
        BrowserType Type { get; }
        T Driver { get; }
    }
}