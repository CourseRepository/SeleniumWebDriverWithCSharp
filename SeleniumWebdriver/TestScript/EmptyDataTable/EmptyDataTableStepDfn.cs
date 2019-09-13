using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SeleniumWebdriver.TestScript.EmptyDataTable
{
    [Binding]
    public sealed class EmptyDataTableStepDfn
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;

        public EmptyDataTableStepDfn(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [Given(@"User read ""(.*)"" and ""(.*)"" from examples")]
        public void GivenUserReadAndFromExamples(string user, string password)
        {
            NavigationHelper.NavigateToUrl("https://www.udemy.com");
            var title = ObjectRepository.Driver.Title;
            Console.WriteLine(string.Format("Name : {0} and Password : {1}", user, password));
            Console.WriteLine("Title : " + title);
        }


    }
}
