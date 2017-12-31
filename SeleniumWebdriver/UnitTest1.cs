using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Configuration;
using SeleniumWebdriver.Interfaces;
using SeleniumWebdriver.Keyword;
using SeleniumWebdriver.PageObject;
using SeleniumWebdriver.Settings;


namespace SeleniumWebdriver
{
  
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestKeyword()
        {
            DataEngine engine = new DataEngine();
            engine.ExecuteScript(@"C:\Users\rahul.rathore\Desktop\Cucumber\Keyword.xlsx", "TC01");
        }
    }
}
