using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumWebdriver.BaseClasses;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;

namespace SeleniumWebdriver.PageObject
{
    public class LoginPage : PageBase
    {
        private IWebDriver driver;


        #region WebElement
        [FindsBy(How = How.Id, Using = "Bugzilla_login")]
        private IWebElement LoginTextBox;
        //private IWebElement LoginTextBox => driver.FindElement(By.Id("Bugzilla_login"));

        [FindsBy(How = How.Id, Using = "Bugzilla_password")]
        private IWebElement PassTextBox;
        //private IWebElement PassTextBox => driver.FindElement(By.Id("Bugzilla_password"));

        [FindsBy(How = How.Id, Using = "log_in")]
        [CacheLookup]
        private IWebElement LoginButton;
        //private IWebElement LoginButton => driver.FindElement(By.Id ("log_in"));

        [FindsBy(How = How.LinkText, Using = "Home")]
        private IWebElement HomeLink;
        //private IWebElement HomeLink => driver.FindElement(By.LinkText("Home"));


        #endregion

        public LoginPage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
           
        }

        #region Actions

        public EnterBug Login(string usename, string password)
        {
            LoginTextBox.SendKeys(usename);
            PassTextBox.SendKeys(password);
            LoginButton.Click();
            GenericHelper.WaitForWebElementInPage(By.LinkText("Testng"), TimeSpan.FromSeconds(30));
            return new EnterBug(driver);
            
        }

        #endregion

        #region Navigation

        public void NavigateToHome()
        {
            HomeLink.Click();
        }

        #endregion
    }
}
