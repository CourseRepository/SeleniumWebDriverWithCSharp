using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumWebdriver.TestScript.TestClassContext
{
    [TestClass]
    public class TestClassContext
    {
        private TestContext _testContext;

        public TestContext TestContext
        {
            get { return _testContext; }
            set { _testContext = value; }
        }

        [TestMethod]
        public void TestCase1()
        {
            Console.WriteLine("Test Name :{0}",TestContext.TestName);
        }

        [TestMethod]
        public void TestCase2()
        {
            Console.WriteLine("Test Name :{0}", TestContext.TestName);
        }

        [TestCleanup]
        public void AfterTest()
        {
            Console.WriteLine("Result :{0}", TestContext.CurrentTestOutcome);
        }
    }
}
