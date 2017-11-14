using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Remote;

namespace SeleniumTests
{
    public class ApplicationManager
    {
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();
        protected RemoteWebDriver driver;
        protected NavigationHelper navigator;
        protected string baseURL;
        private StringBuilder verificationErrors;
        protected DesiredCapabilities capability;
        private WebHelper web;
        private KafkaMachineHelper kafka;


        private ApplicationManager()
        {
            capability = new DesiredCapabilities();
            capability.SetCapability(CapabilityType.BrowserName, "internet explorer");
            capability.SetCapability(CapabilityType.Version, "11.447.14393.0");
            driver = new RemoteWebDriver(new Uri("http://10.0.189.14:2346/wd/hub"), capability);
            baseURL = "http://dlptest.com/";
            verificationErrors = new StringBuilder();
            navigator = new NavigationHelper(this, baseURL);
            web = new WebHelper(this);
            kafka = new KafkaMachineHelper(this);
            

        }

        
        


        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }




        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.GoToDLPTestPage();
                app.Value = newInstance;
            }

            return app.Value;

        }

        public RemoteWebDriver Driver { get { return driver; } }
        public StringBuilder VerificationErrors { get; private set; }
        public NavigationHelper Navigator { get { return navigator; } }

        public WebHelper Web {get { return web; } }

        internal KafkaMachineHelper Kafka
        {
            get
            {
                return kafka;
            }
        }
    }
}
