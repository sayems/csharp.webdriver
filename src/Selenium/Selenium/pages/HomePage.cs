using System;
using Selenium.core.browsers;

namespace Selenium.pages
{
    public class HomePage
    {
        private readonly IBrowser _browser;

        public HomePage(IBrowser browser)
        {
            _browser = browser;
        }

        public RegisterPage Register()
        {
            Console.WriteLine("Navigating to Register page");
            _browser.Page.GoToUrl("http://www.google.com");
            return new RegisterPage(_browser);
        }
    }
}