using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumWebdriver.ComponentHelper;
using OpenQA.Selenium;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace SeleniumWebdriver.TestScript.Question.Frameset
{
    [TestClass]
    public class TestFrameSet
    {
        [TestMethod]
        public void TestFrameInFrameSet()
        {
            NavigationHelper.NavigateToUrl("https://www.w3schools.com/tags/tryit.asp?filename=tryhtml_frame_cols");
            GenericHelper.WaitForWebElementVisisble(By.Id("tryhome"), TimeSpan.FromSeconds(60));
            ObjectRepository.Driver.SwitchTo().Frame(ObjectRepository.Driver.FindElement(By.Id("iframeResult")));
            ReadOnlyCollection<IWebElement> list =  ObjectRepository.Driver.FindElements(By.XPath("//frame"));
            foreach(IWebElement webElement in list)
            {
                Console.WriteLine(webElement.ToString());
            }


        }



    }
}
