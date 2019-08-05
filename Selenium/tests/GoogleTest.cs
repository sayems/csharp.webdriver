using NUnit.Framework;
using Selenium.core;
using Selenium.pages;

namespace Selenium.tests
{
    [TestFixture]
    [Parallelizable]
    public class GoogleTest : TestBase
    {
        [Test]
        public void TestMethod()
        {
            var page = new HomePage(Driver);
            page.OpenGooglePage();
        }
    }
}