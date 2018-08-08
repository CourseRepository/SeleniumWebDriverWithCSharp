using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumWebdriver.TestScript.Question
{
    [TestClass]
    public class TestFileDownload
    {
        private IWebDriver driver;
        private const string Download_Dir = @"D:\DownloadFile\";


        private FirefoxOptions GetFirefoxptions()
        {
            FirefoxOptions options = new FirefoxOptions();

            FirefoxProfile firefoxProfile = new FirefoxProfile();
            firefoxProfile.SetPreference("browser.download.folderList", 2);
            //firefoxProfile.SetPreference("browser.download.manager.showWhenStarting", false);
            firefoxProfile.SetPreference("browser.download.dir", Download_Dir);
            firefoxProfile.SetPreference("browser.helperApps.neverAsk.saveToDisk",
    "text/csv,application/x-msexcel,application/excel,application/x-excel,application/vnd.ms-excel,image/png,image/jpeg,text/html,text/plain,application/msword,application/xml");
            options.Profile = firefoxProfile;
            return options;

        }

        [TestInitialize]
        public void Setup()
        {
            driver = new FirefoxDriver(@"C:\Users\rathr1\Downloads\geckodriver-v0.20.1-win64\", GetFirefoxptions());
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.Navigate().GoToUrl(@"https://www.sample-videos.com/download-sample-xls.php");
            driver.Manage().Window.Maximize();
            
        }

        [TestCleanup]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Close();
                driver.Quit();
            }
        }

        [TestMethod]
        public void TestDownload()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60))
            {
                PollingInterval = TimeSpan.FromMilliseconds(250)
            };

            IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@download='SampleXLSFile_19kb.xls']")));
            element.Click();
            int count = 0;

            while (count < 10)
            {
                string[] files = Directory.GetFiles(Download_Dir);
                if(files.Length != 0)
                {
                    if (files.Contains(Download_Dir + "SampleXLSFile_19kb.xls"))
                    {
                        Console.Write(files[0]);
                        break;
                    }
                    Thread.Sleep(1000);
                    count++;
                }
            }
        }
    }
}
