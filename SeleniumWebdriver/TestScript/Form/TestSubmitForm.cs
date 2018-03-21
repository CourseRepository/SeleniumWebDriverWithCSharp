using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumWebdriver.TestScript.Form
{
    [TestClass]
    public class TestSubmitForm
    {
        [TestMethod]
        public void TestSubmit()
        {
            NavigationHelper.NavigateToUrl("https://www.w3schools.com/html/tryit.asp?filename=tryhtml_form_submit");
            WebDriverWait wait = GetWait();
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(OpenQA.Selenium.By.Id("iframeResult")));
            TextBoxHelper.TypeInTextBox(By.CssSelector("[name='firstname']"), "Testing");
            Thread.Sleep(2000);
            Assert.AreEqual("MickeyTesting", GenericHelper.GetElement(By.CssSelector("[name='firstname']")).GetAttribute("value"));

        }

        private WebDriverWait GetWait()
        {
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(60))
            {
                PollingInterval = TimeSpan.FromMilliseconds(250)
            };
            return wait;
        }
    }
}
