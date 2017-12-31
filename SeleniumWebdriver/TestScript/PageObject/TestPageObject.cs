using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.PageObject;
using SeleniumWebdriver.Settings;

namespace SeleniumWebdriver.TestScript.PageObject
{
    [TestClass]
   public class TestPageObject
    {
        [TestMethod]
        public void TestPage()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            HomePage homePage = new HomePage(ObjectRepository.Driver);
            LoginPage loginPage = homePage.NavigateToLogin();
            EnterBug enterBug = loginPage.Login(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
            BugDetail bugDetail = enterBug.NavigateToDetail();
            bugDetail.SelectFromSeverity("trivial");
            ButtonHelper.ClickButton(By.XPath("//div[@id='header']/ul[1]/li[11]/a"));
        }

        
       
    }
}
