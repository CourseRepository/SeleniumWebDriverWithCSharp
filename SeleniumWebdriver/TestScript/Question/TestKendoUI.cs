using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumWebdriver.TestScript.Question
{
    [TestClass]
    public class TestKendoUI
    {
        private readonly string UserSetting = "//button[@role='menu']";
        [TestMethod]
        public void TestUi()
        {
            // Navigate to the Url
            NavigationHelper.NavigateToUrl("https://www.telerik.com/kendo-angular-ui/components/buttons/dropdownbutton/");
            // Wait for the Iframe
            GenericHelper.WaitForWebElement(By.Id("example-basic-usage"), TimeSpan.FromSeconds(30));
            // Switch to the frame
            ObjectRepository.Driver.SwitchTo().Frame(ObjectRepository.Driver.FindElement(By.Id("example-basic-usage")));
            // Wait for User Setting button
            GenericHelper.WaitForWebElement(By.XPath(UserSetting),TimeSpan.FromSeconds(60));
            // Click on User Setting
            ButtonHelper.ClickButton(By.XPath(UserSetting));
            Thread.Sleep(3000);
            // Wait for Menu item
            GenericHelper.WaitForWebElementInPage(By.CssSelector(".k-list.k-reset > [role='menuItem']:nth-child(2)"), TimeSpan.FromSeconds(60));
            // Click on the item based index
            ButtonHelper.ClickButton(By.CssSelector(".k-list.k-reset > [role='menuItem']:nth-child(2)"));
            Thread.Sleep(3000);
        }
    }
}
