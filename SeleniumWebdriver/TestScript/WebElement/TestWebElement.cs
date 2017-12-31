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

namespace SeleniumWebdriver.TestScript.WebElement
{
    [TestClass]
    public class TestWebElement
    {
        [TestMethod]
        public void GetElement()
        {
            NavigationHelper.NavigateToUrl(@"http://localhost:5001/editparams.cgi");
            try
            {
               ReadOnlyCollection<IWebElement> col = ObjectRepository.Driver.FindElements(By.TagName("input"));
                Console.WriteLine("Size : {0}", col.Count);
                Console.WriteLine("Size : {0}", col.ElementAt(0));
                //ObjectRepository.Driver.FindElement(By.LinkText("File a Bug")).Click();
                var a = ObjectRepository.Driver.FindElement(By.Name("showmybugslink")).GetAttribute("checked");
               
                
                //ObjectRepository.Driver.FindElement(By.TagName("input"));
                //ObjectRepository.Driver.FindElement(By.ClassName("btn"));
                //ObjectRepository.Driver.FindElement(By.CssSelector("#find"));
                //ObjectRepository.Driver.FindElement(By.LinkText("File a Bug"));
                //ObjectRepository.Driver.FindElement(By.PartialLinkText("File"));
                //ObjectRepository.Driver.FindElement(By.Name("quicksearch"));
                //ObjectRepository.Driver.FindElement(By.Id("find_bottom"));
                //ObjectRepository.Driver.FindElement(By.XPath("//input[@id='find']"));
                ////ObjectRepository.Driver.FindElement(By.XPath("//input[@id='find1']"));
                //IList<string> list = new List<string>();
                //list.Add("Task 1");
                //list.Add("Task 2");
                //list.Add("Task 3");
                //Console.WriteLine("Size : {0}",list.Count);
                //list.Remove("Task 2");
                //Console.WriteLine("Size : {0}", list.Count);
                //Console.WriteLine("Value : {0}",list[0]);
                //list.Clear();
                //Console.WriteLine("Size : {0}", list.Count);
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e);
            }
            
        }
    }
}
