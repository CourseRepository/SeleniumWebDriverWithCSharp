using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;

namespace SeleniumWebdriver.TestScript.HyperLink
{
    [TestClass]
    public class TestHyperLink
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof (TestHyperLink));

        [TestMethod,TestCategory("Smoke")]
        public void ClickLink()
        {
            try
            {
                NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
                //IWebElement element =  ObjectRepository.Driver.FindElement(By.LinkText("File a Bug"));
                //  element.Click();

                //  IWebElement pelement = ObjectRepository.Driver.FindElement(By.PartialLinkText("File"));
                //  pelement.Click();
                LinkHelper.ClickLink(By.LinkText("File a Bug"));
                LinkHelper.ClickLink(By.PartialLinkText("File"));
            }
            catch (Exception exception)
            {
                Logger.Error(exception.StackTrace);
                GenericHelper.TakeScreenShot();
                throw;
            }
                
            
        }
    }
}
