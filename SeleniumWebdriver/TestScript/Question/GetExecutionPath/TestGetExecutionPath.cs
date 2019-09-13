using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.TestScript.Question.GetExecutionPath
{
   [TestClass]
   public class TestGetExecutionPath
    {
        [TestMethod]
        public void TestGetPath()
        {
            // Also Refer to Lecture 132. TC - Deployment Item

            var assembly = Assembly.GetExecutingAssembly();
            var location = Path.GetDirectoryName(assembly.Location) + @"\Resources\SampleFile.txt";
            Console.WriteLine(location);
            Assert.IsTrue(File.Exists(location),"The File Should Exist");
        }
    }
}
