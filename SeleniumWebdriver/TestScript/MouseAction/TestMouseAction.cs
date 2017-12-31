using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;

namespace SeleniumWebdriver.TestScript.MouseAction
{
    [TestClass]
    public class TestMouseAction
    {
        [TestMethod]
        public void TestContextClick()
        {
            NavigationHelper.NavigateToUrl("http://demos.telerik.com/kendo-ui/dragdrop/events");
            Actions act = new Actions(ObjectRepository.Driver);
            IWebElement ele = ObjectRepository.Driver.FindElement(By.Id("draggable"));
            

            act.ContextClick(ele)
                .Build()
                .Perform();

            Thread.Sleep(5000);
        }

        [TestMethod]
        public void DranNDrop()
        {
            NavigationHelper.NavigateToUrl("http://demos.telerik.com/kendo-ui/dragdrop/events");
            Actions act = new Actions(ObjectRepository.Driver);
            IWebElement src = ObjectRepository.Driver.FindElement(By.Id("draggable"));
            IWebElement tar = ObjectRepository.Driver.FindElement(By.Id("droptarget"));

            act.DragAndDrop(src,tar)
                .Build()
                .Perform();

            Thread.Sleep(4000);
        }


        [TestMethod]
        public void TestClicknHold()
        {
            NavigationHelper.NavigateToUrl("http://demos.telerik.com/kendo-ui/sortable/index");
            Actions act = new Actions(ObjectRepository.Driver);
            IWebElement ele = ObjectRepository.Driver.FindElement(By.XPath("//ul[@id='sortable-basic']/li[12]"));
            IWebElement tar = ObjectRepository.Driver.FindElement(By.XPath("//ul[@id='sortable-basic']/li[2]/span"));
            act.ClickAndHold(ele)
                .MoveToElement(tar,0,30)
                .Release()
                .Build()
                .Perform();

            Thread.Sleep(10000);
        }

        [TestMethod]
        public void TestKeyBoard()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            Actions act = new Actions(ObjectRepository.Driver);
            // ctrl + t
            //act.KeyDown(Keys.LeftControl)
            //    .SendKeys("t")
            //    .KeyUp(Keys.LeftControl)
            //    .Build()
            //    .Perform();

            // ctrl + shift +a

            //act.KeyDown(Keys.LeftControl)
            //    .KeyDown(Keys.LeftShift)
            //    .SendKeys("a")
            //    .KeyUp(Keys.LeftShift)
            //    .KeyUp(Keys.LeftControl)
            //    .Build()
            //    .Perform();

            // alt + f + x

            //act.KeyDown(Keys.LeftAlt)
            //    .SendKeys("f")
            //    .SendKeys("x")
            //    .Build()
            //    .Perform();

            IWebElement ele1 = ObjectRepository.Driver.FindElement(By.Id("quicksearch_top"));
            IWebElement ele2 = ObjectRepository.Driver.FindElement(By.Id("quicksearch_main"));
            ele1.SendKeys("fx");

            act.KeyDown(ele2,Keys.LeftShift)
                .SendKeys(ele2,"f")
                .SendKeys(ele2,"x")
                .KeyUp(ele2,Keys.LeftShift)
                .Build()
                .Perform();
            Thread.Sleep(5000);

        }

    }
}
