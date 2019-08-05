using NUnit.Framework;
using Selenium.core;
using Selenium.pages;

namespace Selenium.tests
{
    [TestFixture]
    [Parallelizable]
    public class GithubTest : TestBase
    {
        [Test]
        public void TestMethod()
        {
            var page = new HomePage(Driver);
            page.OpenGithubPage();
        }
    }
}