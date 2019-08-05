using System;
using System.Diagnostics.Contracts;
using OpenQA.Selenium;
using Selenium.core.browsers;

namespace Selenium.core
{
    internal sealed class JavaScriptAdapter<T> : IJavaScript where T : IWebDriver
    {
        private readonly BrowserAdapter<T> _browser;
        private readonly T _driver;
        private readonly IJavaScriptExecutor _js;

        public JavaScriptAdapter(BrowserAdapter<T> browser)
        {
            _browser = browser;
            _driver = browser.Driver;
            _js = (IJavaScriptExecutor) _driver;
        }

        public object Execute(string javaScript, params object[] args)
        {
            return _js.ExecuteScript(javaScript, args);
        }

        public void WaitReadyState()
        {
            Contract.Assume(_browser != null);
            var ready = new Func<bool>(() => (bool) Execute("return document.readyState == 'complete'"));
            Contract.Assert(Waiter.SpinWait(ready, TimeSpan.FromSeconds(60), TimeSpan.FromMilliseconds(100)));
        }

        public void WaitAjax()
        {
            Contract.Assume(_browser != null);
            var ready = new Func<bool>(() => (bool) Execute("return (typeof($) === 'undefined') ? true : !$.active;"));
            Contract.Assert(Waiter.SpinWait(ready, TimeSpan.FromSeconds(60), TimeSpan.FromMilliseconds(100)));
        }

        public void FireJQueryEvent(IWebElement element, JavaScriptEvent javaScriptEvent)
        {
            var eventName = javaScriptEvent.Name;
            Execute(string.Format("$(arguments[0]).{0}();", eventName), element);
        }
    }

    public interface IJavaScript
    {
        object Execute(string javaScript, params object[] args);
        void WaitAjax();
        void WaitReadyState();
        void FireJQueryEvent(IWebElement element, JavaScriptEvent javaScriptEvent);
    }
}