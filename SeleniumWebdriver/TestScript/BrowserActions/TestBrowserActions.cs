using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;

namespace SeleniumWebdriver.TestScript.BrowserActions
{
    [TestClass]
    public class TestBrowserActions
    {
        [TestMethod]
        public void TestActions()
        {
            NavigationHelper.NavigateToUrl("https://www.udemy.com/bdd-with-selenium-webdriver-and-speckflow-using-c/");
            ButtonHelper.ClickButton(By.XPath("//div[@id='related']/descendant::a[position()=1]"));
            BrowserHelper.GoBack();
            BrowserHelper.Forward();
            BrowserHelper.RefreshPage();


        }
    }
}
