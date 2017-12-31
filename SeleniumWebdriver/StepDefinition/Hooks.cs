using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace SeleniumWebdriver.StepDefinition
{
    [Binding]
    public sealed class Hooks
    {
        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            //ScenarioContext.Current.Pending();
            //Assert.Fail();
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            //ScenarioContext.Current.Pending();
        }
        [When(@"I press sub")]
        public void WhenIPressSub()
        {
            // ScenarioContext.Current.Pending();
            //Assert.Fail();
        }

    }
}
