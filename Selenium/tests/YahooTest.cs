using NUnit.Framework;
using Selenium.core;
using Selenium.pages;

namespace Selenium.tests
{
    [TestFixture]
    [Parallelizable]
    public class YahooTest : TestBase
    {
        [Test]
        public void TestMethod()
        {
            var page = new HomePage(Driver);
            page.OpenYahooPage();
        }
    }
}