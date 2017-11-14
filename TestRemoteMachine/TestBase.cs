using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumTests
{
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManagerTest()
        {
            app =  ApplicationManager.GetInstance();
        }

    }

}
