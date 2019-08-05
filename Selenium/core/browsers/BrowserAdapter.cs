using OpenQA.Selenium;

namespace Selenium.core.browsers
{
    public sealed class BrowserAdapter<T> : IBrowser<T> where T : IWebDriver
    {
        private readonly JavaScriptAdapter<T> _javaScript;
        private readonly PageAdapter<T> _page;

        public BrowserAdapter(T driver, BrowserType type)
        {
            Type = type;
            Driver = driver;
            _page = new PageAdapter<T>(this);
            _javaScript = new JavaScriptAdapter<T>(this);
        }

        public BrowserType Type { get; }
        public T Driver { get; }

        public IPage Page => _page;
        public IJavaScript JavaScript => _javaScript;
    }
}