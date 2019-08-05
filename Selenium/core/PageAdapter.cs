using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using Selenium.core.browsers;

namespace Selenium.core
{
    public sealed class PageAdapter<T> : IPage where T : IWebDriver
    {
        private readonly BrowserAdapter<T> _browser;
        private readonly T _driver;

        public PageAdapter(BrowserAdapter<T> browser)
        {
            _browser = browser;
            _driver = browser.Driver;
        }

        public string Title => _driver.Title;
        public string PageSource => _driver.PageSource;
        public string CurrentWindowHandle => _driver.CurrentWindowHandle;
        public ReadOnlyCollection<string> WindowHandles => _driver.WindowHandles;

        public void GoToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public IEnumerable<IWebElement> FindElements(By by)
        {
            return _driver.FindElements(by);
        }

        public void NavigateBack()
        {
            _driver.Navigate().Back();
        }

        public void Refresh()
        {
            _driver.Navigate().Refresh();
        }

        public void Close()
        {
            _driver.Close();
        }

        public void Quit()
        {
            _driver.Quit();
        }

        public IWebElement FindElement(By by)
        {
            return _driver.FindElement(by);
        }

        ReadOnlyCollection<IWebElement> ISearchContext.FindElements(By by)
        {
            return _driver.FindElements(by);
        }

        public IOptions Manage()
        {
            return _driver.Manage();
        }

        public INavigation Navigate()
        {
            return _driver.Navigate();
        }

        public ITargetLocator SwitchTo()
        {
            return _driver.SwitchTo();
        }

        public string Url { get; set; }

        public void Dispose()
        {
            _driver.SwitchTo();
        }
    }
}