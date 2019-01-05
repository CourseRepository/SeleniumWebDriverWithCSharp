using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumWebdriver.BaseClasses;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;

namespace SeleniumWebdriver.PageObject
{
    public class HomePage : PageBase
    {
        private IWebDriver driver;
        #region WebElement

        [FindsBy(How = How.Id, Using = "quicksearch_main")]
        public IWebElement QuickSearchTextBox;
        //private IWebElement QuickSearchTextBox => driver.FindElement(By.Id("quicksearch_main"));

        [FindsBy(How = How.Id, Using = "find")]
        [CacheLookup]
        public IWebElement QuickSearchBtn;
        //private IWebElement QuickSearchBtn => driver.FindElement(By.Id("find"));

        [FindsBy(How = How.LinkText, Using = "File a Bug")]
        private IWebElement FileABugLink;
        //private IWebElement FileABugLink => driver.FindElement(By.LinkText("File a Bug"));

        #endregion

        public HomePage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region Actions

        public void QuickSearch(string text)
        {
            QuickSearchTextBox.SendKeys(text);
            QuickSearchBtn.Click();
        }

        #endregion

        #region Navigation

        public LoginPage NavigateToLogin()
        {
            FileABugLink.Click();
            GenericHelper.WaitForWebElementInPage(By.Id("log_in"), TimeSpan.FromSeconds(30));
            return new LoginPage(driver);
        }

        #endregion
    }
}
