using NUnit.Framework;
using Selenium.core;
using Selenium.pages;

namespace Selenium.tests
{
    [TestFixture]
    [Parallelizable]
    public class GoogleSearch : TestBase
    {
        [Test]
        public void TestMethod()
        {
            var page = new HomePage(Driver);
            page.Register().CreateAccount();
        }
    }
}