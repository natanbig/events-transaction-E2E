
using System;
using OpenQA.Selenium;


namespace SeleniumTests
{
    public class WebHelper: HelpBase
    {
        private bool acceptNextAlert = true;

        public WebHelper(ApplicationManager manager):base(manager)
        {

        }

        public WebHelper SendProximoEvent()
        {
            
            driver.FindElement(By.Id("ff_elem28")).Clear();
            driver.FindElement(By.Id("ff_elem28")).SendKeys("test");
            driver.FindElement(By.Id("bfSubmitButton")).Click();
            return this;
        }

        public WebHelper SendProximoEventFromReservedSite()
        {
            driver.FindElement(By.Name("sData")).Clear();
            driver.FindElement(By.Name("sData")).SendKeys("test");
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            return this;
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }


    }
}
