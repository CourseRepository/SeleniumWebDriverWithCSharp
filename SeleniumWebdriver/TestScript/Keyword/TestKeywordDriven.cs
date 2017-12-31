using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumWebdriver.Keyword;

namespace SeleniumWebdriver.TestScript.Keyword
{
    [TestClass]
    public class TestKeywordDriven
    {
        [TestMethod]
        public void TestKeyWord()
        {
            var keyDataEngine = new DataEngine();
            keyDataEngine.ExecuteScript(@"C:\Users\rahul.rathore\Desktop\Cucumber\Keyword2.xlsx", "TC01");
        }
    }

}
