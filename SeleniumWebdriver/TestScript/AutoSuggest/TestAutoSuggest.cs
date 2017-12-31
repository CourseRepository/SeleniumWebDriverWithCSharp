using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;

namespace SeleniumWebdriver.TestScript.AutoSuggest
{
    [TestClass]
    public class TestAutoSuggest
    {
        [TestMethod]
        public void TestAutoSug()
        {
            NavigationHelper.NavigateToUrl("http://demos.telerik.com/kendo-ui/autocomplete/index");
            //step - 1 to supply the initial string
            IWebElement ele = ObjectRepository.Driver.FindElement(By.Id("countries"));
            ele.SendKeys("a");
            Thread.Sleep(1000);
            //step -2 wait for auto suggest list

            var wait = GenericHelper.GetWebdriverWait(TimeSpan.FromSeconds(40));
            IList<IWebElement> elements =  wait.Until(GetAllElements(By.XPath("//ul[@id='countries_listbox']/child::li")));
            foreach (var ele1 in elements)
            {
                if (ele1.Text.Equals("Austria"))
                {
                    ele1.Click();
                }
            }

            Thread.Sleep(5000);
        }

        [TestMethod]
        public void MultiSelect()
        {
            NavigationHelper.NavigateToUrl("http://demos.telerik.com/kendo-ui/multiselect/index");
            //step - 1 to click on the text box
            IWebElement ele = ObjectRepository.Driver.FindElement(By.XPath("//div[@id='example']/child::div/descendant::div[position()=2]"));
            List<int> eleList = new List<int>() { 10,12,14 };
            //step - 2 wait for list
            ele.Click();
            var wait = GenericHelper.GetWebdriverWait(TimeSpan.FromSeconds(40));
            var dropdownlist = wait.Until(GetAllElement(By.XPath("//ul[@id='required_listbox']/child::li")));
            foreach (var str in eleList)
            {
                ele.Click();
               
                dropdownlist = wait.Until(GetAllElement(By.XPath("//ul[@id='required_listbox']/child::li[position()="+ str + "]")));
                Thread.Sleep(1000);

                dropdownlist.Click();
            }

            Thread.Sleep(5000);

        }
        private Func<IWebDriver, IWebElement> GetAllElement(By locator)
        {
            return ((x) =>
            {
                return x.FindElement(locator);
            });
        }

        private Func<IWebDriver, IList<IWebElement>> GetAllElements(By locator)
        {
            return ((x) =>
            {
                return x.FindElements(locator);
            });
        } 
    }
}
