using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Remote;

namespace SeleniumTests
{
    public class HelpBase
    {
        protected ApplicationManager manager;
        protected RemoteWebDriver driver;


        public HelpBase(ApplicationManager manager)
        {
            this.manager = manager;
            driver = manager.Driver;
            
        }

        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }

    
}
