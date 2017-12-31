using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;

namespace SeleniumWebdriver.TestScript.MultipleBrowser
{
    [TestClass]
    public class TestMultipleBrowserWindow
    {
        [TestMethod]
        public void TestMutipleBrowserWindow()
        {
            NavigationHelper.NavigateToUrl("http://www.w3schools.com/js/js_popup.asp");
            GenericHelper.TakeScreenShot();
            ButtonHelper.ClickButton(By.XPath("//div[@id='main']/descendant::a[position()=3]"));
            GenericHelper.TakeScreenShot();
            BrowserHelper.SwitchToWindow(1);
            NavigationHelper.NavigateToUrl("http://www.w3schools.com/js/js_popup.asp");
            GenericHelper.TakeScreenShot();
            ButtonHelper.ClickButton(By.XPath("//div[@id='main']/descendant::a[position()=3]"));
            BrowserHelper.SwitchToWindow(2);
            GenericHelper.TakeScreenShot();
            ButtonHelper.ClickButton(By.XPath("//div[@class='textarea']/descendant::button"));
            GenericHelper.TakeScreenShot();
            BrowserHelper.SwitchToParent();
        }

        [TestMethod]
        public void TestFrame()
        {
            NavigationHelper.NavigateToUrl("http://www.w3schools.com/js/js_popup.asp");
            ButtonHelper.ClickButton(By.XPath("//div[@id='main']/descendant::a[position()=3]"));
            BrowserHelper.SwitchToWindow(1);
            ButtonHelper.ClickButton(By.XPath("//div[@class='textarea']/descendant::button"));
            BrowserHelper.SwitchToFrame(By.Id("iframeResult"));
            ButtonHelper.ClickButton(By.XPath("//button[text()='Try it']"));
            var a = ObjectRepository.Driver.SwitchTo().Alert().Text;
            ObjectRepository.Driver.SwitchTo().Alert().Accept();
            ObjectRepository.Driver.SwitchTo().DefaultContent();
            TextBoxHelper.ClearTextBox(By.Id("textareaCode"));
            TextBoxHelper.TypeInTextBox(By.Id("textareaCode"), a);

        }
    }
}
