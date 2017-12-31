using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumWebdriver.TestScript.RadAutoCompleteBox
{
    [TestClass]
    public class TC_AutoSuggestComboBox
    {
        private readonly string url = "https://demos.telerik.com/aspnet-ajax/autocompletebox/examples/default/defaultcs.aspx";

        public object WaitHelper { get; private set; }

        [TestMethod]
        public void TestAutSuggestComboBox()
        {
            NavigationHelper.NavigateToUrl(url);
            GenericHelper.WaitForWebElement(By.Id("ctl00_ContentPlaceholder1_RadAutoCompleteBox2_Input"), TimeSpan.FromSeconds(60));
            Dictionary<string, string> data = new Dictionary<string, string>
            {
                { "a", "Nancy" },
                { "b", "Robert" }
            };
            EnterAndSelect(data);

        }

        private void EnterAndSelect(Dictionary<string,string> data)
        {
            foreach(string key in data.Keys)
            {
                TextBoxHelper.TypeInTextBox(By.Id("ctl00_ContentPlaceholder1_RadAutoCompleteBox2_Input"), key);
                GenericHelper.WaitForWebElementVisisble(getName(data[key]),TimeSpan.FromSeconds(60));
                ButtonHelper.ClickButton(getName(data[key]));
                Thread.Sleep(2000);
            }

            
        }

        private By getName(string name)
        {
            return By.XPath(string.Format("//li[text()='{0}']", name));
        }
    }
}
