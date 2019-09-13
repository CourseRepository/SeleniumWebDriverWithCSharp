using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.TestScript.Question
{
    [TestClass]
    public class MinMax
    {
        [TestMethod]
        public void TestArrayList()
        {

            ArrayList arrayList = new ArrayList();
            arrayList.Add(double.Parse("181255.00"));
            arrayList.Add(double.Parse("181255.00"));
            arrayList.Add(double.Parse("181255.21"));
            Console.WriteLine(arrayList[0]);
            Console.WriteLine(arrayList[arrayList.Count - 1]);

        }
    }
}
