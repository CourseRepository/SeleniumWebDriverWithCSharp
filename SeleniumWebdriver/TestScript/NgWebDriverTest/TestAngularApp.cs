using Microsoft.VisualStudio.TestTools.UnitTesting;
using Protractor;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.TestScript.NgWebDriverTest
{
    [TestClass]
    public class TestAngularApp
    {
        private NgWebDriver ngWebDriver;

        [TestInitialize]
        public void SetUp()
        {
            ngWebDriver = new NgWebDriver(ObjectRepository.Driver);
        }

        [TestCleanup]
        public void TearDown()
        {
            if(null != ngWebDriver)
            {
                ngWebDriver.Close();
                ngWebDriver.Quit();
            }
        }

        [TestMethod]
        public void TestAjApps()
        {
            ngWebDriver.Navigate().GoToUrl("https://hello-angularjs.appspot.com/sorttablecolumn");
            NgWebElement element = ngWebDriver.FindElement(NgBy.Model("searchKeyword"));
            element.SendKeys("Angular");

        }

    }
}
