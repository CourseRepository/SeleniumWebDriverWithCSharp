using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;

namespace SeleniumWebdriver.TestScript.HandleDropDown
{
    [TestClass]
    public class DropDownList
    {
        [TestMethod]
        public void TestList()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            LinkHelper.ClickLink(By.LinkText("File a Bug"));
            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_login"), ObjectRepository.Config.GetUsername());
            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_password"), ObjectRepository.Config.GetPassword());
            ButtonHelper.ClickButton(By.Id("log_in"));
            LinkHelper.ClickLink(By.LinkText("Testng"));
            //IWebElement element = ObjectRepository.Driver.FindElement(By.Id("bug_severity"));
            //SelectElement select = new SelectElement(element);
            //select.SelectByIndex(2);
            //select.SelectByValue("normal");
            //select.SelectByText("blocker");
            //Console.WriteLine("Selected value : {0}",select.SelectedOption.Text);
            //IList<IWebElement> list = select.Options;
            //foreach (IWebElement ele in list)
            //{
            //    Console.WriteLine("Value : {0}, Text : {1}",ele.GetAttribute("value"),ele.Text);
            //}
            ComboBoxHelper.SelectElement(By.Id("bug_severity"),2);
            ComboBoxHelper.SelectElement(By.Id("bug_severity"), "blocker");
            foreach (string str in ComboBoxHelper.GetAllItem(By.Id("bug_severity")))
            {
                Console.WriteLine("Text : {0}",str);
            }
        }
    }
}
