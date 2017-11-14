using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Remote;

namespace SeleniumTests
{
    public class NavigationHelper : HelpBase
    {
        private string baseURL;



        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }
        public void GoToDLPTestPage()
        {
            if (driver.Url == baseURL)
                return;
            driver.Navigate().GoToUrl(baseURL + "http -post/");
            if (driver.Url != baseURL + "http -post/")
                GoToReserverDLPSite();
           
        }

        private void GoToReserverDLPSite()
        {
            baseURL = "http://dataleaktest.com";
            driver.Navigate().GoToUrl(baseURL + "/post-test.aspx");

        }



        public string BaseURL
        {
            get
            {
                return baseURL;
            }

            set
            {
                baseURL = value;
            }
        }
    }
}
