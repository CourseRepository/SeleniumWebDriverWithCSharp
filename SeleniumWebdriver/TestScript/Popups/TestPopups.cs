using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using log4net;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SeleniumWebdriver.TestScript.Popups
{
    [TestClass]
    [DeploymentItem(@"Resources")]
    public class TestPopups
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(TestPopups));
        public TestContext TestContext { get; set; }


        [TestMethod]
        public void TestAlert()
        {
            NavigationHelper.NavigateToUrl("http://www.w3schools.com/js/js_popup.asp");
            ButtonHelper.ClickButton(By.XPath("//div[@id='main']/descendant::a[position()=3]"));
            BrowserHelper.SwitchToWindow(1);
            IWebElement textarea = ObjectRepository.Driver.FindElement(By.Id("textareaCode"));
            JavaScriptExecutor.ExecuteScript("document.getElementById('textareaCode').setAttribute('style','display: inline;')");
            TextBoxHelper.ClearTextBox(By.CssSelector("#textareawrapper"));
            BrowserHelper.SwitchToFrame(By.Id("iframeResult"));
           // ButtonHelper.ClickButton(By.XPath("//button[text()='Try it']"));
            var text = JavaScriptPopHelper.GetPopUpText();
            JavaScriptPopHelper.ClickOkOnPopup();
            //IAlert alert = ObjectRepository.Driver.SwitchTo().Alert();
            //var text = alert.Text;
            //alert.Accept();
            ObjectRepository.Driver.SwitchTo().DefaultContent();
            GenericHelper.WaitForWebElement(By.Id("textareaCode"), TimeSpan.FromSeconds(60));
            //TextBoxHelper.ClearTextBox(By.Id("textareaCode"));
            //TextBoxHelper.TypeInTextBox(By.Id("textareaCode"),text);
            Logger.Info("Test Alert Complete");
            GenericHelper.Wait(ExpectedConditions.ElementIsVisible(By.Id("id")), TimeSpan.FromSeconds(60));

        }


        [TestMethod]
        public void TestConfimPopup()
        {
            NavigationHelper.NavigateToUrl("http://www.w3schools.com/js/tryit.asp?filename=tryjs_confirm");
            BrowserHelper.SwitchToFrame(By.Id("iframeResult"));
            ButtonHelper.ClickButton(By.XPath("//button[text()='Try it']"));
            var text = JavaScriptPopHelper.GetPopUpText();
            JavaScriptPopHelper.ClickOkOnPopup();
            //IAlert confirm = ObjectRepository.Driver.SwitchTo().Alert();
            //confirm.Accept();
            ButtonHelper.ClickButton(By.XPath("//button[text()='Try it']"));
            JavaScriptPopHelper.ClickCancelOnPopup();
            ObjectRepository.Driver.SwitchTo().DefaultContent();
            GenericHelper.WaitForWebElement(By.Id("textareaCode"), TimeSpan.FromSeconds(60));
            //TextBoxHelper.ClearTextBox(By.Id("textareaCode"));
            //TextBoxHelper.TypeInTextBox(By.Id("textareaCode"), text);
            //confirm = ObjectRepository.Driver.SwitchTo().Alert();
            //confirm.Dismiss();
            Logger.Info("Test Confirm Popup Complete");
        }

        [TestMethod]
        public void TestPrompt()
        {
            NavigationHelper.NavigateToUrl("http://www.w3schools.com/js/tryit.asp?filename=tryjs_prompt");
            BrowserHelper.SwitchToFrame(By.Id("iframeResult"));
            ButtonHelper.ClickButton(By.XPath("//button[text()='Try it']"));
            var text = JavaScriptPopHelper.GetPopUpText();
            JavaScriptPopHelper.SendKeys(text);
            JavaScriptPopHelper.ClickOkOnPopup();
            BrowserHelper.RefreshPage();
            BrowserHelper.SwitchToFrame(By.Id("iframeResult"));
            ButtonHelper.ClickButton(By.XPath("//button[text()='Try it']"));
            text = JavaScriptPopHelper.GetPopUpText();
            JavaScriptPopHelper.SendKeys(text + "abc");
            JavaScriptPopHelper.ClickCancelOnPopup();
            ObjectRepository.Driver.SwitchTo().DefaultContent();
            GenericHelper.WaitForWebElement(By.Id("textareaCode"), TimeSpan.FromSeconds(60));
            //TextBoxHelper.ClearTextBox(By.Id("textareaCode"));
            //TextBoxHelper.TypeInTextBox(By.Id("textareaCode"), text);
            //IAlert prompt = ObjectRepository.Driver.SwitchTo().Alert();
            //prompt.SendKeys("This is automation");
            //prompt.Accept();

            // ButtonHelper.ClickButton(By.XPath("//button[text()='Try it']"));
            //prompt = ObjectRepository.Driver.SwitchTo().Alert();
            //prompt.SendKeys("This is automation");
            //prompt.Dismiss();
            Logger.Info("Test Prompt Complete");
        }

        [TestCleanup]
        public void TearDown()
        {
            Logger.Info($"Test Method Name - {TestContext.TestName}, Status - {TestContext.CurrentTestOutcome}");
        }

    }
}
