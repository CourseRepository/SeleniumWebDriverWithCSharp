using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;

namespace SeleniumWebdriver.TestScript.DefaultWait
{
    [TestClass]
    public class HandleDefaultWait
    {
        [TestMethod]
        public void TestDefaultWait()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            LinkHelper.ClickLink(By.LinkText("File a Bug"));
            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_login"), ObjectRepository.Config.GetUsername());
            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_password"), ObjectRepository.Config.GetPassword());
            ButtonHelper.ClickButton(By.Id("log_in"));
            LinkHelper.ClickLink(By.LinkText("Testng"));
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(1));

            GenericHelper.WaitForWebElement(By.Id("bug_severity"), TimeSpan.FromSeconds(50));
            IWebElement ele = GenericHelper.WaitForWebElementInPage(By.Id("bug_severity"), TimeSpan.FromSeconds(50));

            DefaultWait<IWebElement> wait = new DefaultWait<IWebElement>(ObjectRepository.Driver.FindElement(By.Id("bug_severity")));
            wait.PollingInterval = TimeSpan.FromMilliseconds(200);
            wait.Timeout = TimeSpan.FromSeconds(50);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException),typeof(ElementNotVisibleException));
            Console.WriteLine("After wait : {0}",wait.Until(changeofvalue()));
        }

        private Func<IWebElement, string> changeofvalue()
        {
            return ((x) =>
            {
                Console.WriteLine("Waiting for value change");
                SelectElement select = new SelectElement(x);
                if (select.SelectedOption.Text.Equals("major"))
                    return select.SelectedOption.Text;
                return null;
            });
        }

        [TestMethod]
        public void TestFreeCharge()
        {
            NavigationHelper.NavigateToUrl("https://www.freecharge.in/#");
            LinkHelper.ClickLink(By.XPath("//ul[@id='couponTypes']/descendant::a[text()='Mobile']"));
            Assert.IsTrue(GenericHelper.WaitForWebElement(By.XPath("//legend[contains(text(),'Enter your mobile number')]"), TimeSpan.FromSeconds(50)));
            Thread.Sleep(3000);
            LinkHelper.ClickLink(By.XPath("//a[contains(text(),'Dth')]"));
            Assert.IsTrue(GenericHelper.WaitForWebElement(By.XPath("//legend[contains(text(),'Pay your DTH bill. Which operator?')]"), TimeSpan.FromSeconds(50)));
            Thread.Sleep(3000);
            LinkHelper.ClickLink(By.XPath("//a[contains(text(),'Datacard')]"));
            Assert.IsTrue(GenericHelper.WaitForWebElement(By.XPath("//legend[contains(text(),'Enter your datacard number')]"), TimeSpan.FromSeconds(50)));
            Thread.Sleep(3000);
            LinkHelper.ClickLink(By.XPath("//a[contains(text(),'Metro')]"));
            Assert.IsTrue(GenericHelper.WaitForWebElement(By.XPath("//legend[contains(text(),'Which Operator?')]"), TimeSpan.FromSeconds(50)));
        }
    }
}
