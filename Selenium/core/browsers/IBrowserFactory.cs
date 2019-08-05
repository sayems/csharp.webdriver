using OpenQA.Selenium;

namespace Selenium.core.browsers
{
    public interface IBrowserFactory
    {
        IBrowser Create<T>() where T : IWebDriver;
    }
}