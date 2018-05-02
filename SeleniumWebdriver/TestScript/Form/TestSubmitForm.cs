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
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

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
            AssertData(By.CssSelector("[name='firstname']"), "MickeyTesting");

            Dictionary<By, string> data = new Dictionary<By, string>();
            data.Add(By.CssSelector("[name='firstname']"), "MickeyTesting");
            data.Add(By.CssSelector("[name='firstname']"), "MickeyTesting");
            data.Add(By.CssSelector("[name='firstname']"), "MickeyTesting");

            AssertData(data);
        }

        private void AssertData(By locator,string expectedvalue)
        {
            Assert.AreEqual(expectedvalue, GenericHelper.GetElement(locator).GetAttribute("value"));
        }

        private void AssertData(Dictionary<By,string> expectedDataSet)
        {
            foreach(By locator in expectedDataSet.Keys)
            {
                try
                {
                    Assert.AreEqual(expectedDataSet[locator], GenericHelper.GetElement(locator).GetAttribute("value"));
                }
                catch(AssertFailedException)
                {
                    //Can be replace by logger
                    Console.Write(String.Format($"Data mismatch for locator {0} and value {1}"), locator, expectedDataSet[locator]);
                }
                
            }
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
