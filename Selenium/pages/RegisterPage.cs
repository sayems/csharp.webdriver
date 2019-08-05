using System;
using Selenium.core.browsers;

namespace Selenium.pages
{
    public class RegisterPage
    {
        private readonly IBrowser _browser;

        public RegisterPage(IBrowser browser)
        {
            _browser = browser;
        }

        public void CreateAccount()
        {
            Console.WriteLine("Creating an account");
        }
    }
}