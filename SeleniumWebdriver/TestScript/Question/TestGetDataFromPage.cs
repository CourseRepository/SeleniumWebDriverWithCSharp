using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.TestScript.Question
{
    [TestClass]
    public class TestGetDataFromPage
    {
        //Base xpath for the grid
        private const string BaseXpathOfGrid = "//div[@id='approved']//div[@class='durandal-wrapper']//ol[@class='contentList medium ui-sortable']";

        [TestInitialize]
        public void TestSetup()
        {
            NavigationHelper.NavigateToUrl("https://internal.mem.com/sso/v2/internal");
            GenericHelper.WaitForWebElementVisisble(By.Id("UserName"), TimeSpan.FromSeconds(60));
            TextBoxHelper.TypeInTextBox(By.Id("UserName"), "AutoTester");
            TextBoxHelper.TypeInTextBox(By.Id("Password"), "AutoTester123");
            ButtonHelper.ClickButton(By.XPath("//span[text()='LOGIN']"));
            GenericHelper.WaitForWebElementVisisble(By.XPath("//label[text()='MeM Internal']"), TimeSpan.FromSeconds(70));
            ButtonHelper.ClickButton(By.XPath("//label[text()='MeM Internal']"));
        }

        [TestMethod]
        public void TestGetData()
        {
            NavigationHelper.NavigateToUrl("https://admin.mem.com/sso/newde/7851114#contententry/condolences");
            GenericHelper.WaitForWebElementVisisble(By.XPath(BaseXpathOfGrid), TimeSpan.FromSeconds(70));
            var index = 2; // index for the item in un-ordered list
            while(GenericHelper.IsElemetPresent(By.XPath(BaseXpathOfGrid + "//li[" + index + "]"))) // To check if there are more item present
            {
                IWebElement heading =  ObjectRepository.Driver.FindElement(By.XPath(BaseXpathOfGrid + "//li[" + index + "]//section//div[@class='thumbview']//div[@class='heading']")); // xpath of heading using index 2 -for 1st li , 3 - 2nd li...
                Console.WriteLine(heading.Text);
                heading = ObjectRepository.Driver.FindElement(By.XPath(BaseXpathOfGrid + "//li[" + index + "]//section//div[@class='thumbview']//div[@class='text']")); // xpath of description using index 2 -for 1st li , 3 - 2nd li...
                Console.WriteLine(heading.Text);
                index = index + 1;
            }
        }

    }
}
