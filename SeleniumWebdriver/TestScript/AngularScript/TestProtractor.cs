using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Protractor;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumWebdriver.TestScript.AngularScript
{
    [TestClass]
    public class TestProtractor
    {
        [TestMethod]
        public void TestMethod()
        {
            ObjectRepository.Driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(60);
            ObjectRepository.Driver.Navigate().GoToUrl("https://www.copaair.com/en/web/us");
            var ngDriver = new NgWebDriver(ObjectRepository.Driver);
            var list = ngDriver.FindElements(NgBy.Repeater("item in desktopBookingTabs"));
            var element = list.First((x) =>
            {
               return x.Text.Contains("Manage your booking");
            });

            element.Click();
            ngDriver.WaitForAngular();

            ngDriver.FindElement(NgBy.Model("remoteSearchCriteria.travelerLastName")).SendKeys("Thisistest");
            ngDriver.FindElement(NgBy.Model("bookingReference")).SendKeys("121421445252");
            ngDriver.FindElement(By.Id("sendReservationForm")).Click();

         





            Thread.Sleep(TimeSpan.FromSeconds(5));

        }
    }
}
