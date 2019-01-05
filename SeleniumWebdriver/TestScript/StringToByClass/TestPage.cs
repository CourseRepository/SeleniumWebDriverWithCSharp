using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.TestScript.StringToByClass
{
    public class TestPage
    {
        private IWebDriver webDriver;

        protected static string FileABug = "(By.Id(\"enter_bug\")), fileabug";
        protected static string aFileABug = "By.Id,enter_bug,fileabug";

        public static List<string> GetElementAndValue(string ele)
        {
            return ele.Split(',').ToList();
        }

        public static void ClickButton(string locator)
        {
            List<string> LocatorAndValue = GetElementAndValue(locator);
            By aLocator = GetLocator(LocatorAndValue);
        }

        private static By GetLocator(List<string> aLocatorAndValue)
        {
            if (aLocatorAndValue[0].Equals("By.Id"))
                return By.Id(aLocatorAndValue[1]);
            else
                throw new Exception("Invalid Locator");
        }
    }
}
