using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.TestScript.Question
{
    public class SubString
    {
        public object Webdriverwait { get; private set; }

        public static String GetSubString(String sentance,int begIndex,int endIndex)
        {
            if (endIndex > sentance.Length || begIndex < 0)
                throw new Exception(string.Format("Index value is not proper {0},{1}", begIndex, endIndex));
            return sentance.Substring(begIndex, (endIndex - begIndex));
        }


        private static Func<IWebDriver, IWebElement> GetAllElements(By locator)
        {
            return ((x) =>
            {
                var list = x.FindElements(locator);
                return list[list.Count - 1];

               


            });
        }

        public void Click()
        {
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(60))
            {
                PollingInterval = TimeSpan.FromMilliseconds(250),
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            IWebElement element = wait.Until(GetAllElements(By.ClassName("")));

            JavaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.Click();
        }
    }
}
