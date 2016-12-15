using OpenQA.Selenium;

namespace Selenium.core.browsers
{
    public interface IBrowserWebDriver<out T> where T : IWebDriver
    {
        IBrowser<T> Create();
    }
}