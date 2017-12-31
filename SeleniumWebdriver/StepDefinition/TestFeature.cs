using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.PageObject;
using SeleniumWebdriver.Settings;
using TechTalk.SpecFlow;

namespace SeleniumWebdriver.StepDefinition
{
    [Binding]
    public sealed class TestFeature
    {

        private HomePage hPage;
        private LoginPage lPage;
        private EnterBug ePage;
        private BugDetail bPage;

        #region Given

        [Given(@"User is at Home Page")]
        public void GivenUserIsAtHomePage()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
        }

        [Given(@"File a Bug should be visible")]
        public void GivenFileABugShouldBeVisible()
        {
            Assert.IsTrue(GenericHelper.IsElemetPresent(By.Id("enter_bug")));
        }

        #endregion

        #region When

        [When(@"I click on File a Bug Link")]
        public void WhenIClickOnFileABugLink()
        {
            ObjectRepository.hPage = new HomePage(ObjectRepository.Driver);
            ObjectRepository.lPage = ObjectRepository.hPage.NavigateToLogin();
        }

        [When(@"I provide the username, password and click on Login button")]
        public void WhenIProvideTheUsernamePasswordAndClickOnLoginButton()
        {
            ePage = lPage.Login(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
        }

        [When(@"I click on Logout button")]
        public void WhenIClickOnLogoutButton()
        {
            ObjectRepository.ePage.Logout();
        }

        [When(@"I click on  Testng link")]
        public void WhenIClickOnTestngLink()
        {
            bPage = ePage.NavigateToDetail();
        }


        [When(@"I provide the severity , harware , platform and summary")]
        public void WhenIProvideTheSeverityHarwarePlatformAndSummary()
        {
            bPage.SelectFromCombo("critical", "Macintosh", "Other");
            bPage.TypeIn("Summary 1","Desc - 1");
        }

        #endregion

        #region Then

        [Then(@"User should be at Login Page")]
        public void ThenUserShouldBeAtLoginPage()
        {
            Assert.AreEqual("Log in to Bugzilla",ObjectRepository.lPage.Title);
            //AssertHelper.AreEqual("Log in to Bugzilla 1", lPage.Title);
        }

        [Then(@"User Should be at Enter Bug page")]
        public void ThenUserShouldBeAtEnterBugPage()
        {
            Assert.AreEqual("Enter Bug",ObjectRepository.ePage.Title);
        }

        [Then(@"User should be logged out and should be at Home Page")]
        public void ThenUserShouldBeLoggedOutAndShouldBeAtHomePage()
        {
            Assert.IsTrue(GenericHelper.IsElemetPresent(By.Id("welcome")));
        }

        [Then(@"User Should be at Bug Detail page")]
        public void ThenUserShouldBeAtBugDetailPage()
        {
            Assert.AreEqual("Enter Bug: Testng",ObjectRepository.bPage.Title);
        }


        [Then(@"Bug should get created")]
        public void ThenBugShouldGetCreated()
        {
            Assert.IsTrue(GenericHelper.IsElemetPresent(By.Id("commit_top")));
        }


        #endregion

        #region And

        [When(@"click on Submit button")]
        public void WhenClickOnSubmitButton()
        {
           bPage.ClickSubmit();
        }

        [Then(@"User should be at Search page")]
        public void ThenUserShouldBeAtSearchPage()
        {
        }

        #endregion


    }
}
