using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SeleniumWebdriver.TestScript.WebDriverWaiter
{
    [TestClass]
    public class TestWebDeriverWait
    {
        

        [TestMethod]
        public void TestWait()
        {
            
            NavigationHelper.NavigateToUrl("https://www.udemy.com/courses/");
            TextBoxHelper.TypeInTextBox(By.XPath("//input[@class='search-input ui-autocomplete-input quick-search']"),
               "C#");
           
        }

        [TestMethod]
        public void TestDynamciWait()
        {
            NavigationHelper.NavigateToUrl("https://www.udemy.com/");
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(1));
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver,TimeSpan.FromSeconds(50));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException),typeof(ElementNotVisibleException));
            // Console.WriteLine(wait.Until(waitforTitle()));
            //IWebElement element = wait.Until(waitforElement());
            //element.SendKeys("java");
            wait.Until(waitforElement()).SendKeys("health");
            ButtonHelper.ClickButton(By.CssSelector(".home-search-btn"));
            wait.Until(waitforLastElemet()).Click();
            Console.WriteLine("Title : {0}",wait.Until(waitforpageTitle()));
        }


        [TestMethod]
        public void TestExpCondition()
        {
            NavigationHelper.NavigateToUrl("https://www.udemy.com/");
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(1));
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(50));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@type='search']"))).SendKeys("HTML");
            ButtonHelper.ClickButton(By.CssSelector(".home-search-btn"));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='courses']/li[12]/a/div[2]/div[1]/div/span"))).Click();
            Console.WriteLine("Title : {0}",wait.Until(ExpectedConditions.TitleContains("u")));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//a[contains(text(),'Login')]"))).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='loginbox-v4 js-signin-box']")));
        }
       
        //acc -spe fun<in,out> { () => {}}

        private Func<IWebDriver, bool> waitforSearchbox()
        {
            return ((x) =>
            {
                Console.WriteLine("Waiting for Search Box");
                return x.FindElements(By.XPath("//input[@type='search']")).Count == 1;
            });
        }

        private Func<IWebDriver, string> waitforTitle()
        {
            return ((x) =>
            {
                if (x.Title.Contains("Main"))
                    return x.Title;
                return null;
            });
        }

        private Func<IWebDriver, IWebElement> waitforElement()
        {
            return ((x) =>
            {
                Console.WriteLine("Waiting for Search Text box");
                Console.WriteLine("Waiting for element");
                if (x.FindElements(By.XPath("//input[@type='search']")).Count == 1)
                    return x.FindElement(By.XPath("//input[@type='search']"));
                return null;
            });
        }

        private Func<IWebDriver, IWebElement> waitforLastElemet()
        {
            return ((x) =>
            {
                Console.WriteLine("Waiting for Last Element");
                if (
                    x.FindElements(
                        By.XPath("//span[contains(text(),'These 5 Habits Will Help You Improve Your Health')]")).Count ==
                    1)
                    return
                        x.FindElement(
                            By.XPath("//span[contains(text(),'These 5 Habits Will Help You Improve Your Health')]"));
                return null;
            });
        }

        private Func<IWebDriver, string> waitforpageTitle()
        {
            return ((x) =>
            {
                Console.WriteLine("Waiting for Title");
                if (
                    x.FindElements(By.CssSelector(".course-title")).Count == 1)
                    return x.FindElement(By.CssSelector(".course-title")).Text;
                return null;
            });
        } 
    }
}

